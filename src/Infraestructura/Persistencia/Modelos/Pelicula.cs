using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public string Nombre { get; set; }
        public int Sensibilidad { get; set; }
        public int Formato { get; set; }
    }
}
