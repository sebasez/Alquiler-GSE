using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CentroServicio { get; set; }
    }
}
