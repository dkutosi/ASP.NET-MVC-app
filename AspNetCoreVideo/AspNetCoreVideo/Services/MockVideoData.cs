using AspNetCoreVideo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Services
{
    public class MockVideoData : IVideoData
    {

        //private IEnumerable<Video> _videos;
        private List<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>
            {
             

                new Video { Id = 1, Genre = Models.Genres.Animated, Title = "Shreck" },
                new Video { Id = 2, Genre = Models.Genres.Comedy ,Title = "Despicable Me" },
                new Video { Id = 3, Genre = Models.Genres.Romance , Title = "Megamind" }
            };
        }

        public void Add(Video newVideo)
        {
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);

        }

        public int Commit()
        {
            return 0;
        }

        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos;
            
        }


        
    }
}
