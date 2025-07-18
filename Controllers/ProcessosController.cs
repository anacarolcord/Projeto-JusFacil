using JusFacil.API.Data;
using JusFacil.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JusFacil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProcessosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProcessosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Processo>> PostProcesso(Processo processo)
        {
            _context.Processos.Add(processo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProcesso), new { id = processo.ProcessoId }, processo);
        }

        [HttpGet]
        [Authorize]

        public async Task<ActionResult<IEnumerable<Processo>>> GetProcessos()
        {
            return await _context.Processos.ToListAsync();
        }

        [HttpGet("{numeroProcesso}")]
        [Authorize]

        public async Task<ActionResult<Processo>> GetProcesso(string numeroProcesso)
        {
            var processo = await _context.Processos.FirstOrDefaultAsync(p => p.NumeroProcesso == numeroProcesso);

            if (processo == null)
            {
                return NotFound();
            }

            return Ok(processo);


        }



    }
}
