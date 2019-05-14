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
    public class ReceiveFormItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ReceiveFormItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: ReceiveFormItem/Details/id
        [HttpGet]
        public async Task<IActionResult> ReceiveFormItemsDetails(int id)
        {
            var receiveFormItem = await _context.ReceiveFormItems
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(receiveFormItem);
        }

        //POST: ReceiveFormItem/Create
        [HttpPost]
        public IActionResult ReceiveFormItemsCreate([FromBody] ReceiveFormItem receiveFormItem)
        {
            ReceiveFormItem test = new ReceiveFormItem();
            test = receiveFormItem;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: ReceiveFormItem/Delete/id
        [HttpPost]
        public async Task<IActionResult> ReceiveFormItemsDelete(int id)
        {
            var receiveFormItem = await _context.ReceiveFormItems.FindAsync(id);
            if (receiveFormItem == null)
            {
                return NotFound();
            }
            _context.ReceiveFormItems.Remove(receiveFormItem);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: ReceiveFormItem/Edit/id
        [HttpPost]
        public async Task<IActionResult> ReceiveFormItemsEdit(int id, [FromBody] ReceiveFormItem receiveFormItem)
        {
            if (id != receiveFormItem.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiveFormItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiveFormItemExists(receiveFormItem.Id))
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

        // GETALL: ReceiveFormItem/Index
        [HttpGet]
        public async Task<IActionResult> ReceiveFormItemsIndex()
        {
            return Json(await _context.ReceiveFormItems.ToListAsync());
        }

        private bool ReceiveFormItemExists(int id)
        {
            return _context.ReceiveFormItems.Any(e => e.Id == id);
        }
    }
}
