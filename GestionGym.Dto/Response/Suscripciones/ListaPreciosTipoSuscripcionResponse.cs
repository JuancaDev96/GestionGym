using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Dto.Response.Suscripciones
{
    public class ListaPreciosTipoSuscripcionResponse
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
