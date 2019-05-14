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
    public class ProductCategoryController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ProductCategoryController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: ProductCategory/Details/id
        [HttpGet]
        public async Task<IActionResult> ProductCategoryDetails(int id)
        {
            var productCategory = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(productCategory);
        }

        //POST: ProductCategory/Create
        [HttpPost]
        public IActionResult ProductCategoryCreate([FromBody] ProductCategory productCategory)
        {
            ProductCategory test = new ProductCategory();
            test = productCategory;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: ProductCategory/Delete/id
        [HttpPost]
        public async Task<IActionResult> ProductCategoryDelete(int id)
        {
            var productCategory = await _context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }
            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: ProductCategory/Edit/id
        [HttpPost]
        public async Task<IActionResult> ProductCategoryEdit(int id,[FromBody] ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return Json("Fail");
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

        // GETALL: ProductCategory/Index
        [HttpGet]
        public async Task<IActionResult> ProductCategoryIndex()
        {
            return Json(await _context.ProductCategories.ToListAsync());
        }

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
