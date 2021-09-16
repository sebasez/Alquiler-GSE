using System.Collections.Generic;

namespace Aplicacion.Comun.Respuestas
{
    public class CamaraRespuesta
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public bool TieneSoporteFlash { get; set; }
        public string Pelicula { get; set; }
        public double ValorAlquiperPorDia { get; set; }
    }
}
