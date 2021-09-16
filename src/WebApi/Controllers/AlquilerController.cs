using Aplicacion.Comun.Request;
using Aplicacion.Comun.Respuestas;
using Aplicacion.Interfaz.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerServicio _servicioAlquiler;
        public AlquilerController(IAlquilerServicio servicioAlquiler)
        {
            this._servicioAlquiler = servicioAlquiler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaGeneral<List<AlquilerRespuesta>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaGeneral<List<AlquilerRespuesta>>))]
        public async Task<IActionResult> Get()
        {
            var resultado = await this._servicioAlquiler.TodosAlquileres();
            return resultado.StatusCodeOperation switch
            {
                StatusCodes.Status200OK => Ok(resultado),
                StatusCodes.Status400BadRequest => BadRequest(resultado),
                _ => BadRequest(),
            };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RespuestaGeneral<AlquilerRespuesta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaGeneral<AlquilerRespuesta>))]
        public async Task<IActionResult> Get(string id)
        {
            if (!int.TryParse(id, out int idConsulta))
            {
                return BadRequest(new RespuestaGeneral<AlquilerRespuesta>
                {
                    Exito = false,
                    Mensaje = $"El id [{id}] para la busqueda no es valido",
                    Errores = null,
                    Datos = null
                });
            }
            var resultado = await this._servicioAlquiler.BuscarAlquilerPorId(idConsulta);
            return resultado.StatusCodeOperation switch
            {
                StatusCodes.Status200OK => Ok(resultado),
                StatusCodes.Status400BadRequest => BadRequest(resultado),
                _ => BadRequest(),
            };
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RespuestaGeneral<AlquilerRespuesta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaGeneral<AlquilerRespuesta>))]
        public async Task<IActionResult> Post([FromBody] AlquilerRequest alquiler)
        {
            var resultado = await this._servicioAlquiler.CrearAlquiler(alquiler);
            return resultado.StatusCodeOperation switch
            {
                StatusCodes.Status201Created => Ok(resultado),
                StatusCodes.Status400BadRequest => BadRequest(resultado),
                _ => BadRequest(),
            };
        }

    }
}
