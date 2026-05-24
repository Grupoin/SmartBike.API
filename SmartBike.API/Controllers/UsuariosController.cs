using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBike.API.Servicios;
using SmartBike.Entidades;
using SmartBike.Entidades.DTos;

namespace SmartBike.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuariosController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        // POST: api/usuarios/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var resultado = await _usuarioServicio.RegistrarUsuarioAsync(dto);
                return CreatedAtAction(nameof(ObtenerPorCedula), new { cedula = resultado!.Cedula }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET: api/usuarios/buscar/100xxxxxxx
        [HttpGet("buscar/{cedula}")]
        public async Task<IActionResult> ObtenerPorCedula(string cedula)
        {
            var usuario = await _usuarioServicio.ObtenerPorCedulaAsync(cedula);
            if (usuario == null) return NotFound(new { mensaje = "Usuario no encontrado." });

            return Ok(usuario);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // ESTO LO VERÁS EN LA CONSOLA DE VISUAL STUDIO MIENTRAS LA API EJECUTA
            Console.WriteLine($"DEBUG: Recibí Correo: '{loginDto.CorreoInstitucional}'");
            Console.WriteLine($"DEBUG: Recibí Contraseña: '{loginDto.Contrasena}'");

            var usuario = await _usuarioServicio.ValidarLoginAsync(loginDto.CorreoInstitucional, loginDto.Contrasena);

            if (usuario == null)
            {
                Console.WriteLine("DEBUG: No se encontró al usuario en la BD.");
                return Unauthorized();
            }

            return Ok(usuario);
        }

    }
}
