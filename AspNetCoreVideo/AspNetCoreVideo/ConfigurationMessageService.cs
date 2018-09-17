using AspNetCoreVideo.Services;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreVideo
{
    internal class ConfigurationMessageService : IMessageService
    {
        private IConfiguration _configuration;
        public ConfigurationMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetMessage()
        {
            return _configuration["Message"];
        }
    }
}