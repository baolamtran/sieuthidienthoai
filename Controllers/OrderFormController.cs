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

            return Ok(orderForm);
        }

        //POST: OrderForm/Create
        [HttpPost]
        public IActionResult OrderFormCreate([FromBody] OrderForm orderForm)
        {
            OrderForm test = new OrderForm();
            test = orderForm;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: OrderForm/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> OrderFormDelete(int id)
        {
            var orderForm = await _context.OrderForms.FindAsync(id);
            if (orderForm == null)
            {
                return NotFound();
            }
            _context.OrderForms.Remove(orderForm);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: OrderForm/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> OrderFormEdit(int id,[FromBody] OrderForm orderForm)
        {
            if (id != orderForm.Id)
            {
                return Json("Fail");
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

        // GETALL: OrderForm/Index
        [HttpGet]
        public async Task<IActionResult> OrderFormIndex()
        {
            return Json(await _context.OrderForms.ToListAsync());
        }

        private bool OrderFormExists(int id)
        {
            return _context.OrderForms.Any(e => e.Id == id);
        }
    }
}
