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
    public class BillDeliveryInfoController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryInfoController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDeliveryInfo/Details/id
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoDetails(int id)
        {
            var billDeliveryInfo = await _context.BillDeliveryInfoes
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(billDeliveryInfo);
        }

        //POST: BillDeliveryInfo/Create
        [HttpPost]
        public IActionResult BillDeliveryInfoCreate([FromBody] BillDeliveryInfo billDeliveryInfo)
        {
            BillDeliveryInfo test = new BillDeliveryInfo();
            test = billDeliveryInfo;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: BillDeliveryInfo/Delete/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryInfoDelete(int id)
        {
            var billDeliveryInfo = await _context.BillDeliveryInfoes.FindAsync(id);
            if (billDeliveryInfo == null)
            {
                return NotFound();
            }
            _context.BillDeliveryInfoes.Remove(billDeliveryInfo);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: BillDeliveryInfo/Edit/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryInfoEdit(int id,[FromBody] BillDeliveryInfo billDeliveryInfo)
        {
            if (id != billDeliveryInfo.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billDeliveryInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillDeliveryInfoExists(billDeliveryInfo.Id))
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

        // GETALL: BillDeliveryInfo/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoIndex()
        {
            return Json(await _context.BillDeliveryInfoes.ToListAsync());
        }

        private bool BillDeliveryInfoExists(int id)
        {
            return _context.BillDeliveryInfoes.Any(e => e.Id == id);
        }
    }
}
