using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PROJECT.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;
        Cust_Raw cust_Raw;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
            cust_Raw = new Cust_Raw();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Customers.ToListAsync());
        }

        public async Task<IActionResult> Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var cus = await _db.Customers.FindAsync(id);
            if (cus == null)
            {
                return NotFound();
            }
            cust_Raw.customer = cus;
            cust_Raw.rawList = await _db.RawMaterials.ToListAsync();
            return View(cust_Raw);
        } 
        public async Task<IActionResult> Pay(IDictionary<String,String> d)
        {

            String id = d["idCus"];
            int idd = int.Parse(id);
            var cus = await _db.Customers.FindAsync(idd);
            String idR = d["idRaw"];
            int iddR = int.Parse(idR);
            var raw = await _db.RawMaterials.FindAsync(iddR);
            
           
            cust_Raw.rawMaterial = raw;
            cust_Raw.customer = cus;

            return View(cust_Raw);
        }
    }
}
