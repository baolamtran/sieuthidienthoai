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
    public class BillDeliveryInfoItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryInfoItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDeliveryInfoItem/Details/id
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoItemDetails(int id)
        {
            var billDeliveryInfoItem = await _context.BillDeliveryInfoItems
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(billDeliveryInfoItem);
        }

        //POST: BillDeliveryInfoItem/Create
        [HttpPost]
        public IActionResult BillDeliveryInfoItemCreate([FromBody] BillDeliveryInfoItem billDeliveryInfoItem)
        {
            BillDeliveryInfoItem test = new BillDeliveryInfoItem();
            test = billDeliveryInfoItem;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: BillDeliveryInfoItem/Delete/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryInfoItemDelete(int id)
        {
            var billDeliveryInfoItem = await _context.BillDeliveryInfoItems.FindAsync(id);
            if (billDeliveryInfoItem == null)
            {
                return NotFound();
            }
            _context.BillDeliveryInfoItems.Remove(billDeliveryInfoItem);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: BillDeliveryInfoItem/Edit/id
        [HttpPost]
        public async Task<IActionResult> BillDeliveryInfoItemEdit(int id,[FromBody] BillDeliveryInfoItem billDeliveryInfoItem)
        {
            if (id != billDeliveryInfoItem.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billDeliveryInfoItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillDeliveryInfoItemExists(billDeliveryInfoItem.Id))
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

        // GETALL: BillDeliveryInfoItem/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoItemIndex()
        {
            return Json(await _context.BillDeliveryInfoItems.ToListAsync());
        }

        private bool BillDeliveryInfoItemExists(int id)
        {
            return _context.BillDeliveryInfoItems.Any(e => e.Id == id);
        }
    }
}
