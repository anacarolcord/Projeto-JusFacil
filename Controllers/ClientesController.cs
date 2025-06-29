using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JusFacil.API.Data;
using Microsoft.EntityFrameworkCore;
using JusFacil.API.Models;


namespace JusFacil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController (AppDbContext context)
        {
            _context = context;
        }

        //listar clientes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        //busca um cliente pelo id

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();

            }

            return Ok(cliente);
        }

        [HttpPost]

        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Cliente>> PutCliente(int id, Cliente cliente)
        {
            if ( id != cliente.ClienteId)
            {
                return BadRequest();
            }
            
            _context.Entry(cliente).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if(!_context.Clientes.Any(e => e.ClienteId == id))
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

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCliente(int id)
        {   
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
