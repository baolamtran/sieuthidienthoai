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

            return Ok(employee);
        }

        //POST: Employee/Create
        [HttpPost]
        public IActionResult EmployeeCreate([FromBody] Employee employee)
        {
            Employee test = new Employee();
            test = employee;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: Employee/Delete/id
         [HttpDelete("{id}")]
        public async Task<IActionResult> EmployeeDelete(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: Employee/Edit/id
         [HttpPut("{id}")]
        public async Task<IActionResult> EmployeeEdit(int id,[FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return Json("Fail");
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

        // GETALL: Employee/Index
        [HttpGet]
        public async Task<IActionResult> EmployeeIndex()
        {
            return Json(await _context.Employees.ToListAsync());
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
