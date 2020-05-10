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

namespace EgeAlpProject.Controllers
{
    public class CarBrandsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public CarBrandsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }

        // GET: CarBrands
        public async Task<IActionResult> Index()
        {
            var carBrands = await _context.CarBrands.ToListAsync();
            return View(carBrands);
        }

        public async Task<IActionResult> UploadImage(ImageUploadViewModel2 uploadModel)
        {

            //string directory= @"C:\Users\Huseyin\source\repos\CetBookStore\CetBookStore\wwwroot\UserImages\";
            string directory = Path.Combine(hostEnvironment.WebRootPath, "CarBrandImages");
            string fileName = Guid.NewGuid().ToString() + "_" + uploadModel.ImageFile.FileName;

            string fullPath = Path.Combine(directory, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await uploadModel.ImageFile.CopyToAsync(fileStream);
            }

            CarBrandImage carBrandImage = new CarBrandImage();
            carBrandImage.CarBrandId = uploadModel.CarBrandId;
            carBrandImage.FileName = fileName;

            _context.CarBrandImages.Add(carBrandImage);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ManageImage), new { id = uploadModel.CarBrandId });


        }
        public async Task<IActionResult> ManageImage(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var carBrand = await _context.CarBrands.Include(b => b.CarBrandImages)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }


        // GET: CarBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carbrand = await _context.CarBrands.Include(c => c.Cars)
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (carbrand == null)
            {
                return NotFound();
            }

            return View(carbrand);
        }

        // GET: CarBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarBrands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CarBrand carBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carBrand);
        }

        // GET: CarBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBrand = await _context.CarBrands.FindAsync(id);
            if (carBrand == null)
            {
                return NotFound();
            }
            return View(carBrand);
        }

        // POST: CarBrands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CarBrand carBrand)
        {
            if (id != carBrand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarBrandExists(carBrand.Id))
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
            return View(carBrand);
        }

        // GET: CarBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carBrand = await _context.CarBrands
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carBrand == null)
            {
                return NotFound();
            }

            return View(carBrand);
        }

        // POST: CarBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carBrand = await _context.CarBrands.FindAsync(id);
            _context.CarBrands.Remove(carBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarBrandExists(int id)
        {
            return _context.CarBrands.Any(e => e.Id == id);
        }
    }
}
