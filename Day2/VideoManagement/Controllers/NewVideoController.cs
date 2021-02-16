using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoManagement.Models;

namespace VideoManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewVideoController : ControllerBase
    {
        private readonly IVideoRepository _repository;

        public NewVideoController(IVideoRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return _repository.GetAllVideos();
        }

        [HttpGet("{category}")]
        public IEnumerable<Video> Get(string category)
        {
            return _repository.GetVideosByCategory(category);
        }
    }

}
