using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using work_01.Models;

namespace work_01.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseDbContext db;
        public ExpenseController(ExpenseDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var expenses = (from e in db.Expenditures
                            join c in db.Categories on e.CategoryId equals c.Id
                            select new ExpenseView
                            {
                               Id=e.Id,
                               CategoryName=c.CategoryName,
                               DateOfExpense=e.DateOfExpense,
                               CategoryId=e.CategoryId,
                               TotalAmount=e.TotalAmount
                            }).ToList();
            return View(expenses);
        }
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.categoryList = db.Categories.ToList();
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Expenditures expense)
        {
            ViewBag.categoryList = db.Categories.ToList();
            
            if (expense.DateOfExpense > DateTime.Today.Date)
            {
                return PartialView("_dateerror");
            }
            if(ModelState.IsValid)
            {
                db.Expenditures.Add(expense);
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
            var expenditures = db.Expenditures.FirstOrDefault(x => x.Id == id);
            ViewBag.categoryList = db.Categories.ToList();
            return View(expenditures);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Expenditures expense)
        {
            ViewBag.categoryList = db.Categories.ToList();
            if (expense.DateOfExpense > DateTime.Today.Date)
            {
                return PartialView("_dateerror");
            }
            if (ModelState.IsValid)
            {
                db.Expenditures.Update(expense);
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
            var expenditures = db.Expenditures.FirstOrDefault(x => x.Id == id);
            db.Expenditures.Remove(expenditures);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
