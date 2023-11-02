using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
		{
			_logger = logger;
            _unitOfWork = unitOfWork;
        }

		public IActionResult Index()
		{
			var productList = _unitOfWork.ProductRepository.GetAll("Category").OrderBy(x=>x.Title).ToList();
			return View(productList);
		}

		public IActionResult Details(int productId)
		{
			var product = _unitOfWork.ProductRepository.Get(x => x.Id == productId, "Category");
			return View(product);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}