using GestionGym.Entidades;
using GestionGym.Entidades.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
    public interface IMaestroRepository : IBaseRepository<Maestro>
    {
        Task<(List<MaestroDetalleResponse> collection, int total)> ObtenerDetalleMaestroByCodigo(string codigoMaestro, int pagina, int filas);
    }
}
