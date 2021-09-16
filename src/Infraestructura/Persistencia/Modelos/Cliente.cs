using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Infraestructura.Persistencia.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

    }
}
