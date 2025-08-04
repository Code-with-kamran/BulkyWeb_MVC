using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        // CategoryController constructor


        //private readonly ApplicationDbContext _db;   
        private readonly ICategoryRepository _categoryRepo;
        //public CategoryController(ApplicationDbContext db)
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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
            if (obj.Name.ToLower() == obj.DisplayOrder.ToString())
           {
                ModelState.AddModelError("name", "Description and name cannot be same");
                return View();
            }
            _categoryRepo.Add(obj);
            _categoryRepo.Save();
            return RedirectToAction("Index", "Category");

        }


        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //  One way of retrieving category 
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id== id);  // only work with primary key 
            //Category? catergoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id); // can find base on ay condition(fiels)
            //Category? catergoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();// another way of finding any field
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
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
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
            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);  // only work with primary key 
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
            Category? obj = _categoryRepo.Get(u => u.Id == id);

            if (obj == null)
            {
                return NotFound();
              
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
           
            return RedirectToAction("Index");





        }
    }
}
