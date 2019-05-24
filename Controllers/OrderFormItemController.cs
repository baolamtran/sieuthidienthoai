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

            if (orderFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(orderFormItem);
        }

        //POST: OrderFormItem/Create
        [HttpPost]
        public IActionResult OrderFormItemCreate([FromBody] OrderFormItem orderFormItem)
        {
            try
            {
                OrderFormItem test = new OrderFormItem();
                test = orderFormItem;
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

        // DELETE: OrderFormItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormItemDelete(int id)
        {
            var orderFormItem = await _context.OrderFormItems.FindAsync(id);
            if (orderFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.OrderFormItems.Remove(orderFormItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: OrderFormItem/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormItemEdit(int id, [FromBody] OrderFormItem orderFormItem)
        {
            if (id != orderFormItem.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(orderFormItem);
        }

        // GETALL: OrderFormItem/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormItemIndex()
        {
            return Ok(await _context.OrderFormItems.ToListAsync());
        }

        private bool OrderFormItemExists(int id)
        {
            return _context.OrderFormItems.Any(e => e.Id == id);
        }
    }
}
