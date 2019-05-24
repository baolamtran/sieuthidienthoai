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
    public class ManufacturerController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ManufacturerController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Manufacturer/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ManufacturerDetails(int id)
        {
            var manufacturer = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(manufacturer);
        }

        //POST: Manufacturer/Create
        [HttpPost]
        public IActionResult ManufacturerCreate([FromBody] Manufacturer manufacturer)
        {
            try
            {
                Manufacturer test = new Manufacturer();
                test = manufacturer;
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

        // DELETE: Manufacturer/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> ManufacturerDelete(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Manufacturer/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> ManufacturerEdit(int id, [FromBody] Manufacturer manufacturer)
        {
            if (id != manufacturer.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerExists(manufacturer.Id))
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
            return Ok(manufacturer);
        }

        // GETALL: Manufacturer/Index
        [HttpGet]
        public async Task<IActionResult> ManufacturerIndex()
        {
            return Ok(await _context.Manufacturers.ToListAsync());
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
