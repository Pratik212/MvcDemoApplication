using DemoApplication.Data;
using DemoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly DemoContext _context;

        public ExpenseController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _context.Expenses;

            return View(objList);
        }


        public IActionResult Create()
        {
            return View();
        }


        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {

            if(ModelState.IsValid)
            {
                _context.Expenses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }



        //GET Delete 
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _context.Expenses.Find(id);
            if(obj == null)
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
                var obj = _context.Expenses.Find(id);

                if(obj == null)
                {
                    return NotFound();
                }

                _context.Expenses.Remove(obj);
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

            var obj = _context.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {

            if (ModelState.IsValid)
            {
                _context.Expenses.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


    }
}
