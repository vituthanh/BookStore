using BookStore.Data;
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
			return View();
		}
	}
}
