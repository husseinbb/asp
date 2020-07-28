using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Models;

namespace PROJECT.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CustomerController(ApplicationDbContext db,IWebHostEnvironment hostEnvironment)
        {
            _db = db;
            this._hostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Customers.ToListAsync());
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id","fname","lname","address","CNIC","contact","ImageFile")]Customer c)
        {
            if (ModelState.IsValid)
            {
                if (c.ImageFile != null)
                {
                    // save image to wwwroot/Images
                    String wwwRootPath = _hostEnvironment.WebRootPath;
                    String fileName = Path.GetFileNameWithoutExtension(c.ImageFile.FileName);
                    String extension = Path.GetExtension(c.ImageFile.FileName);
                    c.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    String path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await c.ImageFile.CopyToAsync(fileStream);
                    }
                }
                _db.Customers.Add(c);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(c);
        }
    }
}
