using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work_01.Models;

namespace work_01.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ExpenseDbContext db;
        public CategoriesController(ExpenseDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.Categories.ToList());
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Categories categories)
        {
            var cat = categories.CategoryName;
            var duplicate = (from c in db.Categories where c.CategoryName == cat select c).ToList();
            if (duplicate.Count >= 1)
            {
                return PartialView("_duplicate");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(categories);
                db.SaveChanges();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var category = db.Categories.FirstOrDefault(x=>x.Id==id);
            return View(category);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Categories categories)
        {
            var cat = categories.CategoryName;
            var duplicate = (from c in db.Categories where c.CategoryName == cat select c).ToList();
            if (duplicate.Count >= 1)
            {
                return PartialView("_duplicate");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(categories);
                db.SaveChanges();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }

        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.Id == id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
