using DemoApplication.Data;
using DemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Controllers
{
    public class ItemController : Controller
    {

        private readonly DemoContext _context;

        public ItemController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _context.Items;

            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }


        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _context.Items.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
