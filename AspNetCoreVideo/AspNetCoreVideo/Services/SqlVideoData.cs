using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Entities;

namespace AspNetCoreVideo.Services
{
    public class SqlVideoData : IVideoData
    {
        private VideoDbContext _db;
        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }
        public void Add(Video newVideo)
        {
            _db.Add(newVideo);
        }


        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }
        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }

        Video IVideoData.Get(int id)
        {
           return _db.Find<Video>(id);
        }

        IEnumerable<Video> IVideoData.GetAll()
        {
            return _db.Videos;
        }

        public int Commit()
        {
            return _db.SaveChanges() ;
        }
    }
}
