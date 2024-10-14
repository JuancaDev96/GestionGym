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

        public static int CalcularEdadExacta(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;

            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Verificar si la fecha de cumpleaños de este año ya pasó, de lo contrario, restar 1 a la edad
            if (fechaNacimiento.Date > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }

    }
}
