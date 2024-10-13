using GestionGym.AccesoDatos.Contexto;
using GestionGym.Entidades;
using GestionGym.Entidades.Response;
using GestionGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Implementaciones
{
    public class MaestroRepository : BaseRepository<Maestro>, IMaestroRepository
    {
        private readonly BdGymContext _contexto;
        public MaestroRepository(BdGymContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<(List<MaestroDetalleResponse> collection, int total)> ObtenerDetalleMaestroByCodigo(string codigoMaestro, int pagina, int filas)
        {
           var coleccion = await _contexto.Maestrodetalles
                                .Where(p => p.IdmaestroNavigation.Codigo == codigoMaestro && p.Estado)
                                .AsNoTracking()
                                .OrderBy(p=>p.Id)
                                .Skip((pagina - 1) * filas)
                                .Take(filas)
                                .Select(p => new MaestroDetalleResponse
                                {
                                    IdDetalleMaestro = p.Id,
                                    Codigo = p.Codigo,
                                    Valor = p.Valor,
                                    Descripcion = p.Descripcion,
                                    FechaRegistro = p.Fecharegistro
                                }).ToListAsync();

            var total = await _contexto.Maestrodetalles
                                .Where(p => p.IdmaestroNavigation.Codigo == codigoMaestro && p.Estado)
                                .CountAsync();

            return (coleccion, total);
        }

    }
}
