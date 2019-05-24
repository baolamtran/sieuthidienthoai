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
    public class EmployeeController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public EmployeeController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: Employee/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> EmployeeDetails(int id)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(employee);
        }

        //POST: Employee/Create
        [HttpPost]
        public IActionResult EmployeeCreate([FromBody] Employee employee)
        {
            try
            {
                Employee test = new Employee();
                test = employee;
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

        // DELETE: Employee/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> EmployeeDelete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: Employee/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> EmployeeEdit(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return Ok(employee);
        }

        // GETALL: Employee/Index
        [HttpGet]
        public async Task<IActionResult> EmployeeIndex()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
