using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreVideo.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreVideo
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        //constructor added--not part of the original
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");//.AddJsonFile("appsettings.json", optional: true); ;

            if (env.IsDevelopment())
                builder.AddUserSecrets<Startup>();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var conn = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<VideoDbContext>(options =>
            options.UseSqlServer(conn));

            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService,
                ConfigurationMessageService>();
            
            services.AddScoped<IVideoData, SqlVideoData>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<VideoDbContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
                        
            });

            app.Run(async (context) =>
            {
                //var message = Configuration["Message"];
                await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}
