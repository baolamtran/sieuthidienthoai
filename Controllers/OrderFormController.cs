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
    public class OrderFormController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public OrderFormController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: OrderForm/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderFormDetails(int id)
        {
            var orderForm = await _context.OrderForms
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(orderForm);
        }

        //POST: OrderForm/Create
        [HttpPost]
        public IActionResult OrderFormCreate([FromBody] OrderForm orderForm)
        {
            try
            {
                OrderForm test = new OrderForm();
                test = orderForm;
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

        // DELETE: OrderForm/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormDelete(int id)
        {
            var orderForm = await _context.OrderForms.FindAsync(id);
            if (orderForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.OrderForms.Remove(orderForm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: OrderForm/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormEdit(int id, [FromBody] OrderForm orderForm)
        {
            if (id != orderForm.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFormExists(orderForm.Id))
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
            return Ok(orderForm);
        }

        // GETALL: OrderForm/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormIndex()
        {
            return Ok(await _context.OrderForms.ToListAsync());
        }

        private bool OrderFormExists(int id)
        {
            return _context.OrderForms.Any(e => e.Id == id);
        }
    }
}
