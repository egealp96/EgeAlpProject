using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EgeAlpProject.Models;
using EgeAlpProject.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgeAlpProject.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EgeAlpProject.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Search()
        {
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel searchModel)
        {

            IQueryable<Car> cars = _context.Cars.AsQueryable();

            if (!String.IsNullOrWhiteSpace(searchModel.SearchText))
            {
                if (searchModel.SearchInDescription)
                {
                    cars = cars.Where(b => b.Name.Contains(searchModel.SearchText) || b.Description.Contains(searchModel.SearchText));
                }
                else
                {
                    cars = cars.Where(b => b.Name.Contains(searchModel.SearchText));
                }
            }

            if (searchModel.CarBrandId.HasValue)
            {
                cars = cars.Where(b => b.CarBrandId == searchModel.CarBrandId.Value);
            }
            if (searchModel.MinimumPrice.HasValue)
            {
                cars = cars.Where(b => b.Price >= searchModel.MinimumPrice.Value);
            }

            if (searchModel.MaximumPrice.HasValue)
            {
                cars = cars.Where(b => b.Price <= searchModel.MaximumPrice.Value);
            }

            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name", searchModel.CarBrandId);
            searchModel.Results = await cars.ToListAsync();
            return View(searchModel);
        }
    }
}
