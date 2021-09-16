using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Camara
    {
        [Key]
        public int Id { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public bool TieneSoporteFlash { get; set; }
        public int Cantidad { get; set; }
        public double ValorAlquiperPorDia { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public ICollection<Pelicula> Peliculas { get; set; }

    }
}
