using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoManagement.Models
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoDataContext _ctx;

        public VideoRepository(VideoDataContext ctx)
        {
            this._ctx = ctx;
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _ctx.Videos.OrderBy(p => p.Title).ToList();
        }

        public IEnumerable<Video> GetVideosByCategory(string category)
        {
            return _ctx.Videos.Where(p => p.Category == category).ToList();
        }

    }
}
