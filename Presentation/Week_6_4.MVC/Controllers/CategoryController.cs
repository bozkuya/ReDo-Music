using Microsoft.AspNetCore.Mvc;
using Week_6_4.Domain.Entities;
using Week_6_4.Persistence.Contexts;

namespace ReDoMusic.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ReDoMusicDbContext _context;

        public CategoryController()
        {
            _context = new();
        }
        [HttpGet]
        public IActionResult CategoryIndex()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(string categoryName, string categoryImageUrl)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryName,
                ImageUrl = categoryImageUrl
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCategory(string id)
        {


            var category = _context.Categories.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.Categories.Remove(category);

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}