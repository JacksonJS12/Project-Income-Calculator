﻿using Income_Calculator.Data;
using Income_Calculator.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;

namespace Income_Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var banks = _context.Banks.ToList();
            return View(banks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Bank student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Banks.Add(student);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(student);
        }

    }
}
