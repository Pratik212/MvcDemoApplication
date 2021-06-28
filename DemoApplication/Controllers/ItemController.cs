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



        //GET Delete 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST Delete 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Items.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _context.Items.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }



        //GET Update 
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
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


        //POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item obj)
        {

            if (ModelState.IsValid)
            {
                _context.Items.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
