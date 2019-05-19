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

            return Ok(orderFormPayment);
        }

        //POST: OrderFormPayment/Create
        [HttpPost]
        public IActionResult OrderFormPaymentCreate([FromBody] OrderFormPayment orderFormPayment)
        {
            OrderFormPayment test = new OrderFormPayment();
            test = orderFormPayment;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: OrderFormPayment/Delete/id
         [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormPaymentDelete(int id)
        {
            var orderFormPayment = await _context.OrderFormPayments.FindAsync(id);
            if (orderFormPayment == null)
            {
                return NotFound();
            }
            _context.OrderFormPayments.Remove(orderFormPayment);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: OrderFormPayment/Edit/id
         [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormPaymentEdit(int id,[FromBody] OrderFormPayment orderFormPayment)
        {
            if (id != orderFormPayment.Id)
            {
                return Json("Fail");
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

        // GETALL: OrderFormPayment/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormPaymentIndex()
        {
            return Json(await _context.OrderFormPayments.ToListAsync());
        }

        private bool OrderFormPaymentExists(int id)
        {
            return _context.OrderFormPayments.Any(e => e.Id == id);
        }
    }
}
