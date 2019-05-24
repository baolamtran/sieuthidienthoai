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
    public class GuaranteeFormCustomerController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public GuaranteeFormCustomerController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: GuaranteeFormCustomer/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GuaranteeFormCustomerDetails(int id)
        {
            var guaranteeFormCustomer = await _context.GuaranteeFormCustomers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (guaranteeFormCustomer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(guaranteeFormCustomer);
        }

        //POST: GuaranteeFormCustomer/Create
        [HttpPost]
        public IActionResult GuaranteeFormCustomerCreate([FromBody] GuaranteeFormCustomer guaranteeFormCustomer)
        {
            try
            {
                GuaranteeFormCustomer test = new GuaranteeFormCustomer();
                test = guaranteeFormCustomer;
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

        // DELETE: GuaranteeFormCustomer/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> GuaranteeFormCustomerDelete(int id)
        {
            var guaranteeFormCustomer = await _context.GuaranteeFormCustomers.FindAsync(id);
            if (guaranteeFormCustomer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.GuaranteeFormCustomers.Remove(guaranteeFormCustomer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: GuaranteeFormCustomer/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> GuaranteeFormCustomerEdit(int id, [FromBody] GuaranteeFormCustomer guaranteeFormCustomer)
        {
            if (id != guaranteeFormCustomer.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
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
                        Console.WriteLine("Id không tồn tại");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(guaranteeFormCustomer);
        }

        // GETALL: GuaranteeFormCustomer/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormCustomerIndex()
        {
            return Ok(await _context.GuaranteeFormCustomers.ToListAsync());
        }

        private bool GuaranteeFormCustomerExists(int id)
        {
            return _context.GuaranteeFormCustomers.Any(e => e.Id == id);
        }
    }
}
