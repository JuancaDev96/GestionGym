using GestionGym.Dto.Request.Maestros;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
    public interface IMaestroRepository : IBaseRepository<Maestro>
    {
        Task<(List<MaestroDetalleInfo> collection, int total)> ObtenerDetalleMaestroByCodigo(string codigoMaestro, int pagina, int filas);
        Task<(List<MaestroDetalleInfo> collection, int total)> ObtenerDetalleMaestroByIdMaestro(ListaDetalleMaestroRequest request);
        Task<Maestrodetalle> RegistrarDetalleMaestro(Maestrodetalle request);
        Task<Maestrodetalle?> BuscarDetalleMaestroById(int IdMaestroDetalle);
        Task<List<MaestroDetalleInfo>> ListarDetalleMaestroByCodigo(string codigoMaestro);
        Task<List<MaestroDetalleInfo>> ListarDetalleMaestroByListCodigos(List<string> listCodigos);
    }
}
