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
     [Route("api/[controller]")]
    public class BillItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillItem/Details/id
         [HttpGet("{id}")]
        public async Task<IActionResult> BillItemDetails(int id)
        {
            var billItem = await _context.BillItems
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(billItem);
        }

        //POST: BillItem/Create
        [HttpPost]
        public IActionResult BillItemCreate([FromBody] BillItem billItem)
        {
            BillItem test = new BillItem();
            test = billItem;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: BillItem/Delete/id
         [HttpDelete("{id}")]
        public async Task<IActionResult> BillItemDelete(int id)
        {
            var billItem = await _context.BillItems.FindAsync(id);
            if (billItem == null)
            {
                return NotFound();
            }
            _context.BillItems.Remove(billItem);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: BillItem/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillItemEdit(int id,[FromBody] BillItem billItem)
        {
            if (id != billItem.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillItemExists(billItem.Id))
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

        // GETALL: BillItem/Index
        [HttpGet]
        public async Task<IActionResult> BillItemIndex()
        {
            return Json(await _context.BillItems.ToListAsync());
        }

        private bool BillItemExists(int id)
        {
            return _context.BillItems.Any(e => e.Id == id);
        }
    }
}
