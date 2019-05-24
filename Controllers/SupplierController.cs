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
    public class SupplierController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public SupplierController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Supplier/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> SupplierDetails(int id)
        {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (supplier == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(supplier);
        }

        //POST: Supplier/Create
        [HttpPost]
        public IActionResult SupplierCreate([FromBody] Supplier supplier)
        {
            try
            {
                Supplier test = new Supplier();
                test = supplier;
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

        // DELETE: Supplier/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> SupplierDelete(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Supplier/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> SupplierEdit(int id, [FromBody] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
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
            return Ok(supplier);
        }

        // GETALL: Supplier/Index
        [HttpGet]
        public async Task<IActionResult> SupplierIndex()
        {
            return Ok(await _context.Suppliers.ToListAsync());
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}
