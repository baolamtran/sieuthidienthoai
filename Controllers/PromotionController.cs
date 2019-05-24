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

            if (promotion == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(promotion);
        }

        //POST: Promotion/Create
        [HttpPost]
        public IActionResult PromotionCreate([FromBody] Promotion promotion)
        {
            try
            {
                Promotion test = new Promotion();
                test = promotion;
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

        // DELETE: Promotion/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> PromotionDelete(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Promotion/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PromotionEdit(int id, [FromBody] Promotion promotion)
        {
            if (id != promotion.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(promotion);
        }

        // GETALL: Promotion/Index
        [HttpGet]
        public async Task<IActionResult> PromotionIndex()
        {
            return Ok(await _context.Promotions.ToListAsync());
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.Id == id);
        }
    }
}
