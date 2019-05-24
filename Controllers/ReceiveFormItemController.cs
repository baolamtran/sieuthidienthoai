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
    public class ReceiveFormItemController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ReceiveFormItemController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: ReceiveFormItem/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ReceiveFormItemDetails(int id)
        {
            var receiveFormItem = await _context.ReceiveFormItems
                .FirstOrDefaultAsync(m => m.Id == id);

            if (receiveFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(receiveFormItem);
        }

        //POST: ReceiveFormItem/Create
        [HttpPost]
        public IActionResult ReceiveFormItemCreate([FromBody] ReceiveFormItem receiveFormItem)
        {
            try
            {
                ReceiveFormItem test = new ReceiveFormItem();
                test = receiveFormItem;
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

        // DELETE: ReceiveFormItem/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> ReceiveFormItemDelete(int id)
        {
            var receiveFormItem = await _context.ReceiveFormItems.FindAsync(id);
            if (receiveFormItem == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.ReceiveFormItems.Remove(receiveFormItem);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: ReceiveFormItem/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> ReceiveFormItemEdit(int id, [FromBody] ReceiveFormItem receiveFormItem)
        {
            if (id != receiveFormItem.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(receiveFormItem);
        }

        // GETALL: ReceiveFormItem/Index
        [HttpGet]
        public async Task<IActionResult> ReceiveFormItemIndex()
        {
            return Ok(await _context.ReceiveFormItems.ToListAsync());
        }

        private bool ReceiveFormItemExists(int id)
        {
            return _context.ReceiveFormItems.Any(e => e.Id == id);
        }
    }
}
