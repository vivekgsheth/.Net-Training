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

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int? id)
        {
            Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
            return View(video);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, Video model)
        {
            if (ModelState.IsValid)
            {
                Video v = _db.Videos.FirstOrDefault(x => x.Id == model.Id);
                if (v == default(Video))
                {
                    return NotFound();
                }
                else
                {
                    v.Category = model.Category;
                    v.Format = model.Format;
                    v.Title = model.Title;
                    v.Length = model.Length;
                    _db.SaveChanges();
                }
               
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int? id)
        {
            Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
            return View(video);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int? id, Video v)
        {
            if (v != null)
            {
                _db.Remove(v);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
