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
    public class ReceiveFormController : Controller
    {
        private readonly SieuThiDienThoaiDbContext _context;

        public ReceiveFormController(SieuThiDienThoaiDbContext context)
        {
            _context = context;
        }

        // GET: ReceiveForm/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ReceiveFormDetails(int id)
        {
            var receiveForm = await _context.ReceiveForms
                .FirstOrDefaultAsync(m => m.Id == id);

            if (receiveForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }

            return Ok(receiveForm);
        }

        //POST: ReceiveForm/Create
        [HttpPost]
        public IActionResult ReceiveFormCreate([FromBody] ReceiveForm receiveForm)
        {
            try
            {
                ReceiveForm test = new ReceiveForm();
                test = receiveForm;
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

        // DELETE: ReceiveForm/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> ReceiveFormDelete(int id)
        {
            var receiveForm = await _context.ReceiveForms.FindAsync(id);
            if (receiveForm == null)
            {
                Console.WriteLine("Id không tồn tại");
                return NotFound();
            }
            _context.ReceiveForms.Remove(receiveForm);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // UPDATE: ReceiveForm/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> ReceiveFormEdit(int id, [FromBody] ReceiveForm receiveForm)
        {
            if (id != receiveForm.Id)
            {
                Console.WriteLine("Không đúng định dạng");
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receiveForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiveFormExists(receiveForm.Id))
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
            return Ok(receiveForm);
        }

        // GETALL: ReceiveForm/Index
        [HttpGet]
        public async Task<IActionResult> ReceiveFormIndex()
        {
            return Ok(await _context.ReceiveForms.ToListAsync());
        }

        private bool ReceiveFormExists(int id)
        {
            return _context.ReceiveForms.Any(e => e.Id == id);
        }
    }
}
