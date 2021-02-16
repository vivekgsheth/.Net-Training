using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VideoManagement.Models
{
    public class VideoDataContext : DbContext
    {
        // Will be used during migrations
        public VideoDataContext(DbContextOptions<VideoDataContext> options)
            :base(options)
        {

        }

        public DbSet<Video> Videos { get; set; }
    }
}
