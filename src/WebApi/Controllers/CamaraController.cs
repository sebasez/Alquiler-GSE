using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Interfaz.Servicios;
using Microsoft.AspNetCore.Http;
using Aplicacion.Comun.Respuestas;
using Aplicacion.Comun.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CamaraController : ControllerBase
    {
        private readonly ICamaraServicio _servicioCamara;
        public CamaraController(ICamaraServicio servicioCamara)
        {
            this._servicioCamara = servicioCamara;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(RespuestaGeneral<List<CamaraRespuesta>>))]
        public async Task<IActionResult> Get()
        {
            var result =  await this._servicioCamara.ObtenerListaCamaras();
            switch (result.StatusCodeOperation)
            {
                case StatusCodes.Status200OK:
                    return Ok(result);
                case StatusCodes.Status400BadRequest:
                    return BadRequest(result);
                case StatusCodes.Status404NotFound:
                    return NotFound(result);
                default:
                    return BadRequest();
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            if (!int.TryParse(id, out int idConsulta))
            {
                return BadRequest(new RespuestaGeneral<CamaraRespuesta>
                {
                    Exito = false,
                    Mensaje = $"El id [{id}] para la busqueda no es valido",
                    Errores = null,
                    Datos = null
                });
            }
            var result = await this._servicioCamara.BuscarCamaraPorId(idConsulta);

            switch (result.StatusCodeOperation)
            {
                case StatusCodes.Status200OK:
                    return Ok(result);
                    break;
                case StatusCodes.Status400BadRequest:
                    return BadRequest(result);
                    break;
                case StatusCodes.Status404NotFound:
                    return NotFound(result);
                    break;
                default:
                    return BadRequest();
            }
        }
        [HttpGet("{filter}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(RespuestaGeneral<CamaraRespuesta>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilter(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest(new RespuestaGeneral<CamaraRespuesta>
                {
                    Exito = false,
                    Mensaje = $"El filto para la busqueda no es tiene datos",
                    Errores = null,
                    Datos = null
                });
            }
            var result = await this._servicioCamara.BuscarCamarasPorNombre(filter);

            switch (result.StatusCodeOperation)
            {
                case StatusCodes.Status200OK:
                    return Ok(result);
                    break;
                case StatusCodes.Status400BadRequest:
                    return BadRequest(result);
                    break;
                case StatusCodes.Status404NotFound:
                    return NotFound(result);
                    break;
                default:
                    return BadRequest();
            }
        }
    }
}
