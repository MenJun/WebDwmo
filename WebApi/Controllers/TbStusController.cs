using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbStusController : ControllerBase
    {
        private readonly ShopContext _context;

        public TbStusController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/TbStus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbStu>>> GetTbStu()
        {
            return await _context.TbStu.ToListAsync();
        }

        // GET: api/TbStus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbStu>> GetTbStu(string id)
        {
            var tbStu = await _context.TbStu.FindAsync(id);

            if (tbStu == null)
            {
                return NotFound();
            }

            return tbStu;
        }

        // PUT: api/TbStus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbStu(TbStu tbStu)
        {
           

            _context.Entry(tbStu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
            }

            return NoContent();
        }

        // POST: api/TbStus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TbStu>> PostTbStu(TbStu tbStu)
        {
            _context.TbStu.Add(tbStu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbStuExists(tbStu.StuId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbStu", new { id = tbStu.StuId }, tbStu);
        }

        // DELETE: api/TbStus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TbStu>> DeleteTbStu(string id)
        {
            var tbStu = await _context.TbStu.FindAsync(id);
            if (tbStu == null)
            {
                return NotFound();
            }

            _context.TbStu.Remove(tbStu);
            await _context.SaveChangesAsync();

            return tbStu;
        }

        private bool TbStuExists(string id)
        {
            return _context.TbStu.Any(e => e.StuId == id);
        }
    }
}
