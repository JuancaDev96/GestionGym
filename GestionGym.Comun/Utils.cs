using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Comun
{
    public static class Utils
    {
        public static int CalcularPaginacion(int TotalRegistros, int Filas)
        {
            return (int)Math.Ceiling((double)TotalRegistros / Filas);
        }

        /// <summary>
        /// Metodo que mapea las propiedades de una clase a otra
        /// </summary>
        /// <param name="source">Clase origen</param>
        /// <param name="destination">Clase destino</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Map(object source, object destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Source or/and Destination objects are null");
            }

            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties
                    .FirstOrDefault(destProp => destProp.Name == sourceProperty.Name &&
                                                destProp.PropertyType == sourceProperty.PropertyType &&
                                                destProp.CanWrite);

                if (destinationProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
        }

        public static int CalcularEdadExacta(DateOnly fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Verificar si la fecha de cumpleaños de este año ya pasó, de lo contrario, restar 1 a la edad
            if (fechaNacimiento.ToDateTime(TimeOnly.MinValue).Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }
            return edad;

        }

    }
}
