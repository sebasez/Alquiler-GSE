using System;

namespace Aplicacion.Comun.Exceptions
{
    public class EntidadNoExisteException : Exception
    {
        public EntidadNoExisteException()
            : base()
        {
        }

        public EntidadNoExisteException(string mensaje)
            : base(mensaje)
        {
        }

        public EntidadNoExisteException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        public EntidadNoExisteException(string nombre, object identificador)
            : base($"Entidad \"{nombre}\" ({identificador}) no ha sido encontrada.")
        {
        }
    }
}
