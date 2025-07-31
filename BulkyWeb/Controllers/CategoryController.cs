using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        // CategoryController constructor


        private readonly ApplicationDbContext _db;   
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            //custom validation
           
            //check for data validation at server side
            if (!ModelState.IsValid) { 
           
                return View();
            }
            if (obj.Name.ToLower() == obj.Description.ToLower())
            {
                ModelState.AddModelError("name", "Description and name cannot be same");
                return View();
            }
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category  Created Successfully";
            return RedirectToAction("Index", "Category");

        }


        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //  One way of retrieving category 
            Category? categoryFromDb = _db.Categories.Find(id);  // only work with primary key 
            Category? catergoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id); // can find base on ay condition(fiels)
            Category? catergoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();// another way of finding any field
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        { 
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category  Updated Successfully";
                return RedirectToAction("Index", "Category");

                
            }
            return View();



        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //  One way of retrieving category 
            Category? categoryFromDb = _db.Categories.Find(id);  // only work with primary key 
            //Category? catergoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id); // can find base on ay condition(fiels)
            //Category? catergoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();// another way of finding any field
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);

            if (obj == null)
            {
                return NotFound();
              
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category  Deleted Successfully";
            return RedirectToAction("Index");





        }
    }
}
