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
    public class ProductController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ProductController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Product/Details/id
        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(product);
        }

        //POST: Product/Create
        [HttpPost]
        public IActionResult ProductCreate([FromBody] Product product)
        {
            Product test = new Product();
            test = product;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: Product/Delete/id
        [HttpPost]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: Product/Edit/id
        [HttpPost]
        public async Task<IActionResult> ProductEdit(int id,[FromBody] Product product)
        {
            if (id != product.Id)
            {
                return Json("Fail");
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

        // GETALL: Product/Index
        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
            return Json(await _context.Products.ToListAsync());
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
