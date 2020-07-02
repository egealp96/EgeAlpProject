using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgeAlpProject.Data;
using EgeAlpProject.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EgeAlpProject.ViewModel;
using System.Data.Entity.Core.Metadata.Edm;
using RestSharp;
using Microsoft.AspNetCore.Authorization;

namespace EgeAlpProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public CarsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cars.Include(c => c.CarBrand).Include(c=> c.CarImages).Include(c=>c.Comments);
            return View(await applicationDbContext.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> UploadImage(ImageUploadViewModel uploadModel)
        {

            //string directory= @"C:\Users\Huseyin\source\repos\CetBookStore\CetBookStore\wwwroot\UserImages\";
            string directory = Path.Combine(hostEnvironment.WebRootPath, "UserImages");
            string fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(uploadModel.ImageFile.FileName);
            string fullPath = Path.Combine(directory, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadModel.ImageFile.CopyToAsync(fileStream);
            }

            CarImage carImage = new CarImage();
            carImage.CarId = uploadModel.CarId;
            carImage.FileName = fileName;

            _context.CarImages.Add(carImage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageImage), new { id = uploadModel.CarId });


        }


        [Authorize]
        public async Task<IActionResult> ManageImage(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var car = await _context.Cars.Include(b => b.CarImages).Include(c=>c.CarBrand)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

       async  Task  AddToVisitedAdds (int Id)
        {
            HttpContext.Session.Set("test", new byte[] {1 });
           var visitedcar = new VisitedCar();
            visitedcar.SessionId = HttpContext.Session.Id;
            visitedcar.CarId = Id;
            visitedcar.VisitedDate = DateTime.Now;
            _context.VisitedCars.Add(visitedcar);
            await _context.SaveChangesAsync();

           // List<int> temp = HttpContext.Session.Get["visited"] as List<int> ?? new List<int>();
       }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            CardDetailsViewModel cardDetailsViewModel = new CardDetailsViewModel();
            if (id == null)
            {
                return NotFound();
            }
           await AddToVisitedAdds(id.Value);
            var car = await _context.Cars
                .Include(c => c.CarBrand).Include(c=>c.CarImages).Include(c=>c.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            cardDetailsViewModel.Car = car;
            return View(cardDetailsViewModel);
        }

        // GET: Cars/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Name,CarBrandId,CarModel,year,VehicleKm,FuelType,AvgCons,Tansmission,Price,Description,city,Location,CreatedDate")] Car car)
        {
            car.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name", car.CarBrandId);
            return View(car);
        }

        // GET: Cars/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name", car.CarBrandId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CarBrandId,CarModel,year,VehicleKm,FuelType,AvgCons,Tansmission,Price,Description,city,Location,CreatedDate")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarBrandId"] = new SelectList(_context.CarBrands, "Id", "Name", car.CarBrandId);
            return View(car);
        }

        // GET: Cars/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarBrand)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
