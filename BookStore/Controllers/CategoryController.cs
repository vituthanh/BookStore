using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CategoryController(ApplicationDbContext context)
        {
			this._context = context;
		}

        public IActionResult Index()
		{
			var categoryList = _context.Categories.ToList();
			return View(categoryList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
			return View();
		}
	}
}
