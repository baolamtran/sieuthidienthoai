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
    public class PromotionController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public PromotionController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Promotion/Details/id
         [HttpGet("{id}")]
        public async Task<IActionResult> PromotionDetails(int id)
        {
            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(promotion);
        }

        //POST: Promotion/Create
        [HttpPost]
        public IActionResult PromotionCreate([FromBody] Promotion promotion)
        {
            Promotion test = new Promotion();
            test = promotion;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: Promotion/Delete/id
         [HttpDelete("{id}")]
        public async Task<IActionResult> PromotionDelete(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }
            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: Promotion/Edit/id
         [HttpPut("{id}")]
        public async Task<IActionResult> PromotionEdit(int id,[FromBody] Promotion promotion)
        {
            if (id != promotion.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(promotion.Id))
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

        // GETALL: Promotion/Index
        [HttpGet]
        public async Task<IActionResult> PromotionIndex()
        {
            return Json(await _context.Promotions.ToListAsync());
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
