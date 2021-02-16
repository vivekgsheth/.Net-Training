using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoManagement.Models;

namespace VideoManagement.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
        private readonly VideoDataContext _db;

        public HomeController(ILogger<HomeController> logger, VideoDataContext context)
        {
            _logger = logger;
            _db = context;
        }

        public IActionResult Index()
        {
            var allVideos = _db.Videos.ToList();
            return View(allVideos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            @ViewBag.Title = "Add New Video";
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Video model)
        {
            if (ModelState.IsValid)
            {
                _db.Videos.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
