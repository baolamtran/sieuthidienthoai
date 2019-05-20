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

            return Ok(guaranteeFormItem);
        }

        //POST: GuaranteeFormItem/Create
        [HttpPost]
        public IActionResult GuaranteeFormItemCreate([FromBody] GuaranteeFormItem guaranteeFormItem)
        {
            GuaranteeFormItem test = new GuaranteeFormItem();
            test = guaranteeFormItem;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: GuaranteeFormItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> GuaranteeFormItemDelete(int id)
        {
            var guaranteeFormItem = await _context.GuaranteeFormItems.FindAsync(id);
            if (guaranteeFormItem == null)
            {
                return NotFound();
            }
            _context.GuaranteeFormItems.Remove(guaranteeFormItem);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: GuaranteeFormItem/Edit/id
       [HttpPut("{id}")]
        public async Task<IActionResult> GuaranteeFormItemEdit(int id,[FromBody] GuaranteeFormItem guaranteeFormItem)
        {
            if (id != guaranteeFormItem.Id)
            {
                return Json("Fail");
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

        // GETALL: GuaranteeFormItem/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormItemIndex()
        {
            return Json(await _context.GuaranteeFormItems.ToListAsync());
        }

        private bool GuaranteeFormItemExists(int id)
        {
            return _context.GuaranteeFormItems.Any(e => e.Id == id);
        }
    }
}
