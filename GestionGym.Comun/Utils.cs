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

    }
}
