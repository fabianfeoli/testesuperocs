using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSuperoCS.DAO;
using TesteSuperoCS.DAO.Models;
using System;

namespace TesteSuperoCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SuperoDbContext _context;

        public TarefasController(SuperoDbContext context, IConfiguration config)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> GetTarefas()
        {
            var ret = _context.Tarefas;
            return await ret.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            var Tarefa = await _context.Tarefas.FindAsync(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            return Tarefa;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarefa(int id, Tarefa Tarefa)
        {
            if (id != Tarefa.Id)
            {
                return BadRequest();
            }

            _context.Entry(Tarefa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarefaExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa(Tarefa Tarefa)
        {
             try
            {
                _context.Tarefas.Add(Tarefa);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                System.Console.WriteLine( e.ToString() );
            }
            return CreatedAtAction("GetTarefa", new { id = Tarefa.Id }, Tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarefa>> DeleteTarefa(int id)
        {
            var Tarefa = await _context.Tarefas.FindAsync(id);
            if (Tarefa == null)
            {
                return NotFound();
            }

            _context.Tarefas.Remove(Tarefa);
            await _context.SaveChangesAsync();

            return Tarefa;
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefas.Any(e => e.Id == id);
        }
    }
}
