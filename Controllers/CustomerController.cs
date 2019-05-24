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
    public class CustomerController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public CustomerController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Customer/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> CustomerDetails(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(customer);
        }

        //POST: Customer/Create
        [HttpPost]
        public IActionResult CustomerCreate([FromBody] Customer customer)
        {
            try
            {
                Customer test = new Customer();
                test = customer;
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

        // DELETE: Customer/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> CustomerDelete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Customer/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> CustomerEdit(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return Ok(customer);
        }

        // GETALL: Customer/Index
        [HttpGet]
        public async Task<IActionResult> CustomerIndex()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
