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
    public class OrderFormItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public OrderFormItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: OrderFormItem/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderFormItemDetails(int id)
        {
            var orderFormItem = await _context.OrderFormItems
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(orderFormItem);
        }

        //POST: OrderFormItem/Create
        [HttpPost]
        public IActionResult OrderFormItemCreate([FromBody] OrderFormItem orderFormItem)
        {
            OrderFormItem test = new OrderFormItem();
            test = orderFormItem;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: OrderFormItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormItemDelete(int id)
        {
            var orderFormItem = await _context.OrderFormItems.FindAsync(id);
            if (orderFormItem == null)
            {
                return NotFound();
            }
            _context.OrderFormItems.Remove(orderFormItem);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: OrderFormItem/Edit/id
         [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormItemEdit(int id,[FromBody] OrderFormItem orderFormItem)
        {
            if (id != orderFormItem.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderFormItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFormItemExists(orderFormItem.Id))
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

        // GETALL: OrderFormItem/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormItemIndex()
        {
            return Json(await _context.OrderFormItems.ToListAsync());
        }

        private bool OrderFormItemExists(int id)
        {
            return _context.OrderFormItems.Any(e => e.Id == id);
        }
    }
}
