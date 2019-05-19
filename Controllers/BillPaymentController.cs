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
    public class BillPaymentController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public BillPaymentController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: BillPayment/Details/id
         [HttpGet("{id}")]
        public async Task<IActionResult> BillPaymentDetails(int id)
        {
            var billPayment = await _context.BillPayments
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(billPayment);
        }

        //POST: BillPayment/Create
        [HttpPost]
        public IActionResult BillPaymentCreate([FromBody] BillPayment billPayment)
        {
            BillPayment test = new BillPayment();
            test = billPayment;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

         // DELETE: BillPayment/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> BillPaymentDelete(int id)
        {
            var billPayment = await _context.BillPayments.FindAsync(id);
            if (billPayment == null)
            {
                return NotFound();
            }
            _context.BillPayments.Remove(billPayment);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: BillPayment/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> BillPaymentEdit(int id,[FromBody] BillPayment billPayment)
        {
            if (id != billPayment.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillPaymentExists(billPayment.Id))
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

        // GETALL: BillPayment/Index
        [HttpGet]
        public async Task<IActionResult> BillPaymentIndex()
        {
            return Json(await _context.BillPayments.ToListAsync());
        }

        private bool BillPaymentExists(int id)
        {
            return _context.BillPayments.Any(e => e.Id == id);
        }
    }
}
