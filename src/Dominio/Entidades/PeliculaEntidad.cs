namespace Dominio.Entidades
{
    public class PeliculaEntidad
    {
        public int Id { get; set; }
        public MarcaEntidad MarcaEntidad { get; set; }
        public string Nombre { get; set; }
        public int Sensibilidad { get; set; }
        public int Formato { get; set; }
    }
}
