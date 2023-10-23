#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PianoTeacherWebApp_Lab2_.Data;
using PianoTeacherWebApp_Lab2_.Models;

namespace PianoTeacherWebApp_Lab2_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class ParentsController : ControllerBase
    {
        private readonly PianoTeacherDBContext _context;

        public ParentsController(PianoTeacherDBContext context)
        {
            _context = context;
        }

        // GET: api/Parents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parent>>> GetParent_1()
        {
          if (_context.Parent == null)
          {
              return NotFound();
          }
            return await _context.Parent.ToListAsync();
        }

        // GET: api/Parents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParent(int id)
        {
          if (_context.Parent == null)
          {
              return NotFound();
          }
            var parent = await _context.Parent.FindAsync(id);

            if (parent == null)
            {
                return NotFound();
            }

            return parent;
        }

        // PUT: api/Parents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParent(int id, Parent parent)
        {
            if (id != parent.Id)
            {
                return BadRequest();
            }

            _context.Entry(parent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Parents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parent>> PostParent(Parent parent)
        {
          if (_context.Parent == null)
          {
              return Problem("Entity set 'PianoTeacherAPIContext.Parent_1'  is null.");
          }
            _context.Parent.Add(parent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParent", new { id = parent.Id }, parent);
        }

        // DELETE: api/Parents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            if (_context.Parent == null)
            {
                return NotFound();
            }
            var parent = await _context.Parent.FindAsync(id);
            if (parent == null)
            {
                return NotFound();
            }

            _context.Parent.Remove(parent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParentExists(int id)
        {
            return (_context.Parent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
