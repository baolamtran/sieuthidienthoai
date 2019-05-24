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
    public class BillDeliveryController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDelivery/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> BillDeliveryDetails(int id)
        {
            var billDelivery = await _context.BillDeliveries
                .FirstOrDefaultAsync(m => m.Id == id);

            if (billDelivery == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(billDelivery);
        }

        //POST: BillDelivery/Create
        [HttpPost]
        public IActionResult BillDeliveryCreate([FromBody] BillDelivery billDelivery)
        {
            try
            {
                BillDelivery test = new BillDelivery();
                test = billDelivery;
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

        // DELETE: BillDelivery/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> BillDeliveryDelete(int id)
        {
            var billDelivery = await _context.BillDeliveries.FindAsync(id);
            if (billDelivery == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.BillDeliveries.Remove(billDelivery);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: BillDelivery/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillDeliveryEdit(int id, [FromBody] BillDelivery billDelivery)
        {
            if (id != billDelivery.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(billDelivery);
        }

        // GETALL: BillDelivery/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryIndex()
        {
            return Ok(await _context.BillDeliveries.ToListAsync());
        }

        private bool BillDeliveryExists(int id)
        {
            return _context.BillDeliveries.Any(e => e.Id == id);
        }
    }
}
