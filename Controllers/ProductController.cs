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
    public class ProductController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ProductController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Product/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(product);
        }

        //POST: Product/Create
        [HttpPost]
        public IActionResult ProductCreate([FromBody] Product product)
        {
            try
            {
                Product test = new Product();
                test = product;
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

        // DELETE: Product/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Product/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> ProductEdit(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return Ok(product);
        }

        // GETALL: Product/Index
        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
