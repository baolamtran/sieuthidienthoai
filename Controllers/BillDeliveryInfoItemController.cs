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
    public class BillDeliveryInfoItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryInfoItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDeliveryInfoItem/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> BillDeliveryInfoItemDetails(int id)
        {
            var billDeliveryInfoItem = await _context.BillDeliveryInfoItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (billDeliveryInfoItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(billDeliveryInfoItem);
        }

        //POST: BillDeliveryInfoItem/Create
        [HttpPost]
        public IActionResult BillDeliveryInfoItemCreate([FromBody] BillDeliveryInfoItem billDeliveryInfoItem)
        {
            try
            {
                BillDeliveryInfoItem test = new BillDeliveryInfoItem();
                test = billDeliveryInfoItem;
                if (ModelState.IsValid)
                {
                    _context.Add(test);
                    _context.SaveChangesAsync();
                    return Ok(test);
                }
                else
                {
                    Console.WriteLine("Không đúng định dạng");
                    return BadRequest();
                }

            }
            catch (ArgumentException err)
            {
                Console.WriteLine("Không đúng định dạng", err);
                return NotFound();
            }
        }

        // DELETE: BillDeliveryInfoItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> BillDeliveryInfoItemDelete(int id)
        {
            var billDeliveryInfoItem = await _context.BillDeliveryInfoItems.FindAsync(id);
            if (billDeliveryInfoItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.BillDeliveryInfoItems.Remove(billDeliveryInfoItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: BillDeliveryInfoItem/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillDeliveryInfoItemEdit(int id, [FromBody] BillDeliveryInfoItem billDeliveryInfoItem)
        {
            if (id != billDeliveryInfoItem.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(billDeliveryInfoItem);
        }

        // GETALL: BillDeliveryInfoItem/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoItemIndex()
        {
            return Ok(await _context.BillDeliveryInfoItems.ToListAsync());
        }

        private bool BillDeliveryInfoItemExists(int id)
        {
            return _context.BillDeliveryInfoItems.Any(e => e.Id == id);
        }
    }
}
