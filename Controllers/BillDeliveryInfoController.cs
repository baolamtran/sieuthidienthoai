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
    public class BillDeliveryInfoController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillDeliveryInfoController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillDeliveryInfo/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> BillDeliveryInfoDetails(int id)
        {
            var billDeliveryInfo = await _context.BillDeliveryInfoes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (billDeliveryInfo == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(billDeliveryInfo);
        }

        //POST: BillDeliveryInfo/Create
        [HttpPost]
        public IActionResult BillDeliveryInfoCreate([FromBody] BillDeliveryInfo billDeliveryInfo)
        {
            try
            {
                BillDeliveryInfo test = new BillDeliveryInfo();
                test = billDeliveryInfo;
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

        // DELETE: BillDeliveryInfo/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> BillDeliveryInfoDelete(int id)
        {
            var billDeliveryInfo = await _context.BillDeliveryInfoes.FindAsync(id);
            if (billDeliveryInfo == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.BillDeliveryInfoes.Remove(billDeliveryInfo);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: BillDeliveryInfo/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillDeliveryInfoEdit(int id, [FromBody] BillDeliveryInfo billDeliveryInfo)
        {
            if (id != billDeliveryInfo.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(billDeliveryInfo);
        }

        // GETALL: BillDeliveryInfo/Index
        [HttpGet]
        public async Task<IActionResult> BillDeliveryInfoIndex()
        {
            return Ok(await _context.BillDeliveryInfoes.ToListAsync());
        }

        private bool BillDeliveryInfoExists(int id)
        {
            return _context.BillDeliveryInfoes.Any(e => e.Id == id);
        }
    }
}
