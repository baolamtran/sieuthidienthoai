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
    public class GuaranteeFormCustomerController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public GuaranteeFormCustomerController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: GuaranteeFormCustomer/Details/id
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormCustomerDetails(int id)
        {
            var guaranteeFormCustomer = await _context.GuaranteeFormCustomers
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(guaranteeFormCustomer);
        }

        //POST: GuaranteeFormCustomer/Create
        [HttpPost]
        public IActionResult GuaranteeFormCustomerCreate([FromBody] GuaranteeFormCustomer guaranteeFormCustomer)
        {
            GuaranteeFormCustomer test = new GuaranteeFormCustomer();
            test = guaranteeFormCustomer;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: GuaranteeFormCustomer/Delete/id
        [HttpPost]
        public async Task<IActionResult> GuaranteeFormCustomerDelete(int id)
        {
            var guaranteeFormCustomer = await _context.GuaranteeFormCustomers.FindAsync(id);
            if (guaranteeFormCustomer == null)
            {
                return NotFound();
            }
            _context.GuaranteeFormCustomers.Remove(guaranteeFormCustomer);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: GuaranteeFormCustomer/Edit/id
        [HttpPost]
        public async Task<IActionResult> GuaranteeFormCustomerEdit(int id,[FromBody] GuaranteeFormCustomer guaranteeFormCustomer)
        {
            if (id != guaranteeFormCustomer.Id)
            {
                return Json("Fail");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guaranteeFormCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuaranteeFormCustomerExists(guaranteeFormCustomer.Id))
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

        // GETALL: GuaranteeFormCustomer/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormCustomerIndex()
        {
            return Json(await _context.GuaranteeFormCustomers.ToListAsync());
        }

        private bool GuaranteeFormCustomerExists(int id)
        {
            return _context.GuaranteeFormCustomers.Any(e => e.Id == id);
        }
    }
}
