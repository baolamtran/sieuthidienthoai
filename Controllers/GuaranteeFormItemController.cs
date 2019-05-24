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
    public class GuaranteeFormItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public GuaranteeFormItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: GuaranteeFormItem/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GuaranteeFormItemDetails(int id)
        {
            var guaranteeFormItem = await _context.GuaranteeFormItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (guaranteeFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(guaranteeFormItem);
        }

        //POST: GuaranteeFormItem/Create
        [HttpPost]
        public IActionResult GuaranteeFormItemCreate([FromBody] GuaranteeFormItem guaranteeFormItem)
        {
            try
            {
                GuaranteeFormItem test = new GuaranteeFormItem();
                test = guaranteeFormItem;
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

        // DELETE: GuaranteeFormItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> GuaranteeFormItemDelete(int id)
        {
            var guaranteeFormItem = await _context.GuaranteeFormItems.FindAsync(id);
            if (guaranteeFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.GuaranteeFormItems.Remove(guaranteeFormItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: GuaranteeFormItem/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> GuaranteeFormItemEdit(int id, [FromBody] GuaranteeFormItem guaranteeFormItem)
        {
            if (id != guaranteeFormItem.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guaranteeFormItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuaranteeFormItemExists(guaranteeFormItem.Id))
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
            return Ok(guaranteeFormItem);
        }

        // GETALL: GuaranteeFormItem/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormItemIndex()
        {
            return Ok(await _context.GuaranteeFormItems.ToListAsync());
        }

        private bool GuaranteeFormItemExists(int id)
        {
            return _context.GuaranteeFormItems.Any(e => e.Id == id);
        }
    }
}
