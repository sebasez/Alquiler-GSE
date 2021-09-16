using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Aplicacion.Comun.Respuestas
{
    public class RespuestaGeneral <T>
    {
        public bool Exito { get; set; } 
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }
        public T Datos { get; set; }

        [JsonIgnore]
        public int StatusCodeOperation { get; set; }
        
        public RespuestaGeneral()
        {

        }
    }
}
