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
    public class OrderFormPaymentController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public OrderFormPaymentController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: OrderFormPayment/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderFormPaymentDetails(int id)
        {
            var orderFormPayment = await _context.OrderFormPayments
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderFormPayment == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(orderFormPayment);
        }

        //POST: OrderFormPayment/Create
        [HttpPost]
        public IActionResult OrderFormPaymentCreate([FromBody] OrderFormPayment orderFormPayment)
        {
            try
            {
                OrderFormPayment test = new OrderFormPayment();
                test = orderFormPayment;
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

        // DELETE: OrderFormPayment/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormPaymentDelete(int id)
        {
            var orderFormPayment = await _context.OrderFormPayments.FindAsync(id);
            if (orderFormPayment == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.OrderFormPayments.Remove(orderFormPayment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: OrderFormPayment/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormPaymentEdit(int id, [FromBody] OrderFormPayment orderFormPayment)
        {
            if (id != orderFormPayment.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderFormPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFormPaymentExists(orderFormPayment.Id))
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
            return Ok(orderFormPayment);
        }

        // GETALL: OrderFormPayment/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormPaymentIndex()
        {
            return Ok(await _context.OrderFormPayments.ToListAsync());
        }

        private bool OrderFormPaymentExists(int id)
        {
            return _context.OrderFormPayments.Any(e => e.Id == id);
        }
    }
}
