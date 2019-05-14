using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SieuThiDienThoai.Data;
using SieuThiDienThoai.Models;

namespace SieuThiDienThoai.Controllers
{
    public class BillDeliveryController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDelivery/Details/id
        [HttpGet]
        public async Task<IActionResult> BillDeliveryDetails(int id)
        {
            var billDelivery = await _context.BillDeliveries
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(billDelivery);
        }

        //POST: BillDelivery/Create
        [HttpPost]
        public IActionResult BillDeliveryCreate([FromBody] BillDelivery billDelivery)
        {
            BillDelivery test = new BillDelivery();
            test = billDelivery;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

            // DELETE: BillDelivery/Delete/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryDelete(int id)
        {
            var billDelivery = await _context.BillDeliveries.FindAsync(id);
            if (billDelivery == null)
            {
                return NotFound();
            }
            _context.BillDeliveries.Remove(billDelivery);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: BillDelivery/Edit/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryEdit(int id,[FromBody] BillDelivery billDelivery)
        {
            if (id != billDelivery.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billDelivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillDeliveryExists(billDelivery.Id))
                    {
                        return Json("Not found");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json("Success");
        }

        // GETALL: BillDelivery/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryIndex()
        {
            return Json(await _context.BillDeliveries.ToListAsync());
        }

        private bool BillDeliveryExists(int id)
        {
            return _context.BillDeliveries.Any(e => e.Id == id);
        }
    }
}
