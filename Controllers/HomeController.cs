using EgyptBYU.Models;
using Microsoft.AspNetCore.Authorization;
﻿using EgyptBYU.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptBYU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private ApplicationDbContext newContext { get; set; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
            newContext = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Burials(int? pageNumber, string searchString)
        {
            int pageSize = 10;

            ViewData["CurrentFilter"] = searchString;


            var li = from s in _db.burialmain
                     select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                li = li.Where(s => s.length.Contains(searchString) ||
                                    s.area.Contains(searchString) ||
                                    s.depth.Contains(searchString) ||
                                    s.headdirection.Contains(searchString) ||
                                    s.northsouth.Contains(searchString) ||
                                    s.eastwest.Contains(searchString) ||
                                    s.squareeastwest.Contains(searchString) ||
                                    s.squarenorthsouth.Contains(searchString) ||
                                    s.sex.Contains(searchString) ||
                                    s.ageatdeath.Contains(searchString));
            }

            return View(PaginatedList<MummyEntity>.Create(li.ToList(),
                pageNumber ?? 1, pageSize));
        }


        [HttpGet][Authorize(Roles ="Admin")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(MummyEntity me)
        {
            if (ModelState.IsValid)
            {
                newContext.Add(me);
                newContext.SaveChanges();

                int lastPageNumber = (int)Math.Ceiling((decimal)newContext.burialmain.Count() / 10);
                return RedirectToAction("Burials", new { pageNumber = lastPageNumber });
            }
            else
            {
                return View(me);
            }
        }
        public IActionResult UnAnalysis()
        {
            return View();
        }
        public IActionResult SupAnalysis()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet][Authorize(Roles="Admin")]
        public IActionResult Delete(long id)
        {
            var record = newContext.burialmain.Single(m => m.id == id);
            return View(record);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(MummyEntity me)
        {
            // identifying and deleting the correct record

            newContext.burialmain.Remove(me);
            newContext.SaveChanges();
            int lastPageNumber = (int)Math.Ceiling((decimal)newContext.burialmain.Count() / 10);
            return RedirectToAction("Burials", new { pageNumber = lastPageNumber });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(long id)
        {
            var burial = newContext.burialmain.Single(m => m.id == id);

            return View("Edit", burial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(MummyEntity editME)
        {
            // identifying and editing the correct record

            newContext.Update(editME);
            newContext.SaveChanges();
            int lastPageNumber = (int)Math.Ceiling((decimal)newContext.burialmain.Count() / 10);
            return RedirectToAction("Burials", new { pageNumber = lastPageNumber });
        }
    }
}
