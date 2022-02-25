using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFirstApproach.DBFA;

namespace DataBaseFirstApproach.Controllers
{
    public class DefaultController : Controller
    {
        private employeeContext _context = null;
        public DefaultController(employeeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee e)
        {
            _context.Employees.Add(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



       
        public IActionResult Details(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            _context.Employees.Update(e);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.Employees.Find(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteRec(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
