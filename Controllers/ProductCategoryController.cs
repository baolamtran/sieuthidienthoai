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
    public class ProductCategoryController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ProductCategoryController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: ProductCategory/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductCategoryDetails(int id)
        {
            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productCategory == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(productCategory);
        }

        //POST: ProductCategory/Create
        [HttpPost]
        public IActionResult ProductCategoryCreate([FromBody] ProductCategory productCategory)
        {
            try
            {
                ProductCategory test = new ProductCategory();
                test = productCategory;
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

        // DELETE: ProductCategory/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductCategoryDelete(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: ProductCategory/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> ProductCategoryEdit(int id, [FromBody] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategoryExists(productCategory.Id))
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
            return Ok(productCategory);
        }

        // GETALL: ProductCategory/Index
        [HttpGet]
        public async Task<IActionResult> ProductCategoryIndex()
        {
            return Ok(await _context.ProductCategories.ToListAsync());
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
