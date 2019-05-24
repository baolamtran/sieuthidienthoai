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
    public class GuaranteeFormController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public GuaranteeFormController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: GuaranteeForm/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GuaranteeFormDetails(int id)
        {
            var guaranteeForm = await _context.GuaranteeForms
                .FirstOrDefaultAsync(m => m.Id == id);

            if (guaranteeForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(guaranteeForm);
        }

        //POST: GuaranteeForm/Create
        [HttpPost]
        public IActionResult GuaranteeFormCreate([FromBody] GuaranteeForm guaranteeForm)
        {
            try
            {
                GuaranteeForm test = new GuaranteeForm();
                test = guaranteeForm;
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

        // DELETE: GuaranteeForm/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> GuaranteeFormDelete(int id)
        {
            var guaranteeForm = await _context.GuaranteeForms.FindAsync(id);
            if (guaranteeForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.GuaranteeForms.Remove(guaranteeForm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: GuaranteeForm/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> GuaranteeFormEdit(int id, [FromBody] GuaranteeForm guaranteeForm)
        {
            if (id != guaranteeForm.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guaranteeForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuaranteeFormExists(guaranteeForm.Id))
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
            return Ok(guaranteeForm);
        }

        // GETALL: GuaranteeForm/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormIndex()
        {
            return Ok(await _context.GuaranteeForms.ToListAsync());
        }

        private bool GuaranteeFormExists(int id)
        {
            return _context.GuaranteeForms.Any(e => e.Id == id);
        }
    }
}
