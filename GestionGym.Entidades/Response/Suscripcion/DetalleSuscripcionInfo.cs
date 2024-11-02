using GestionGym.Entidades.Response.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Entidades.Response.Suscripcion
{
    public class DetalleSuscripcionInfo
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Descripcion { get; set; } = default!;
        public string TipoSuscripcion { get; set; } = default!;
        public string? DescripcionTipo { get; set; }
        public int IdTipoSuscripcion { get; set; }
        public int IdEstadoSuscripcion { get; set; }
        public int? IdPrecioSuscripcion { get; set; }
        public string? DescripcionPrecio { get; set; } 
        public decimal Precio { get; set; }
        public string EstadoSuscripcion { get; set; } = default!;
        public ClienteInfo Cliente { get; set; } = default!;
        public FichaClienteInfo Ficha { get; set; } = default!;
    }

    
}
