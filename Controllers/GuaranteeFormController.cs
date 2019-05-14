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
    public class GuaranteeFormController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public GuaranteeFormController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: GuaranteeForm/Details/id
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormDetails(int id)
        {
            var guaranteeForm = await _context.GuaranteeForms
                .FirstOrDefaultAsync(m => m.Id == id);

            return Ok(guaranteeForm);
        }

        //POST: GuaranteeForm/Create
        [HttpPost]
        public IActionResult GuaranteeFormCreate([FromBody] GuaranteeForm guaranteeForm)
        {
            GuaranteeForm test = new GuaranteeForm();
            test = guaranteeForm;
            if (ModelState.IsValid)
            {
                _context.Add(test);
                _context.SaveChangesAsync();
            }
            return Json("Success");
        }

        // DELETE: GuaranteeForm/Delete/id
        [HttpPost]
        public async Task<IActionResult> GuaranteeFormDelete(int id)
        {
            var guaranteeForm = await _context.GuaranteeForms.FindAsync(id);
            if (guaranteeForm == null)
            {
                return NotFound();
            }
            _context.GuaranteeForms.Remove(guaranteeForm);
            await _context.SaveChangesAsync();
            return Json("Success");
        }

        // UPDATE: GuaranteeForm/Edit/id
        [HttpPost]
        public async Task<IActionResult> GuaranteeFormEdit(int id,[FromBody] GuaranteeForm guaranteeForm)
        {
            if (id != guaranteeForm.Id)
            {
                return Json("Fail");
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

        // GETALL: GuaranteeForm/Index
        [HttpGet]
        public async Task<IActionResult> GuaranteeFormIndex()
        {
            return Json(await _context.GuaranteeForms.ToListAsync());
        }

        private bool GuaranteeFormExists(int id)
        {
            return _context.GuaranteeForms.Any(e => e.Id == id);
        }
    }
}
