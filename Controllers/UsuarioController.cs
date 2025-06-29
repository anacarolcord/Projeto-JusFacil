using JusFacil.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JusFacil.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace JusFacil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController (AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]

        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, usuario);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        //listar usuarios
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        //buscar usuario

        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            //se nao for admin verifica se eh o prorio usuario

            var usuarioId =int.Parse(User.FindFirst("id").Value);
            var ehAdmin = User.IsInRole("Admin");

            if (!ehAdmin && usuarioId != id)
            {
                return Forbid();
            }

            return usuario;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            //verifica se usuario eh admin ou o dono do perfil

            var usuarioId = int.Parse(User.FindFirst("id").Value);
            var ehAdmin = User.IsInRole("Admin");

            if (!ehAdmin && usuarioId != id)
            {
                return Forbid();
            }

            usuario.TipoUsuario = null;

            _context.Entry(usuario).State=EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(e => e.UsuarioId == id))
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
        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario=await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
