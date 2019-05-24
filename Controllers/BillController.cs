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
    public class BillController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Bill/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> BillDetails(int id)
        {
            var bill = await _context.Bills
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bill == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(bill);
        }

        //POST: Bill/Create
        [HttpPost]
        public IActionResult BillCreate([FromBody] Bill bill)
        {
            try
            {
                Bill test = new Bill();
                test = bill;
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

        // DELETE: Bill/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> BillDelete(int id)
        {
            var bill = await _context.Bills.FindAsync(id);
            if (bill == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Bill/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillEdit(int id, [FromBody] Bill bill)
        {
            if (id != bill.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
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
            return Ok(bill);
        }

        // GETALL: Bill/Index
        [HttpGet]
        public async Task<IActionResult> BillIndex()
        {
            return Ok(await _context.Bills.ToListAsync());
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}
