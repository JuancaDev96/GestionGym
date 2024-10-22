using GestionGym.AccesoDatos.Contexto;
using GestionGym.Dto.Request.Maestros;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Maestros;
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

        public async Task<(List<MaestroDetalleInfo> collection, int total)> ObtenerDetalleMaestroByCodigo(string codigoMaestro, int pagina, int filas)
        {
            var coleccion = await _contexto.Maestrodetalles
                                 .Where(p => p.IdmaestroNavigation.Codigo == codigoMaestro && p.Estado)
                                 .AsNoTracking()
                                 .OrderBy(p => p.Id)
                                 .Skip((pagina - 1) * filas)
                                 .Take(filas)
                                 .Select(p => new MaestroDetalleInfo
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

        public async Task<(List<MaestroDetalleInfo> collection, int total)> ObtenerDetalleMaestroByIdMaestro(ListaDetalleMaestroRequest request)
        {
            var coleccion = await _contexto.Maestrodetalles
                                 .Where(p => p.Idmaestro == request.idMaestro && 
                                    p.Estado &&
                                    (
                                        string.IsNullOrEmpty(request.codigoMaestro) ||
                                        p.Codigo.ToUpper().Contains(request.codigoMaestro.ToUpper())
                                    ) &&
                                    (
                                        string.IsNullOrEmpty(request.Nombre) ||
                                        p.Descripcion!.ToUpper().Contains(request.Nombre.ToUpper())
                                    ))
                                 .AsNoTracking()
                                 .OrderBy(p => p.Id)
                                 .Skip((request.Pagina - 1) * request.Filas)
                                 .Take(request.Filas)
                                 .Select(p => new MaestroDetalleInfo
                                 {
                                     IdDetalleMaestro = p.Id,
                                     Codigo = p.Codigo,
                                     Valor = p.Valor,
                                     Descripcion = p.Descripcion,
                                     FechaRegistro = p.Fecharegistro,
                                     EsBool = p.Esbool ?? false,
                                     EsDefault = p.Esdefault ?? false
                                 }).ToListAsync();

            var total = await _contexto.Maestrodetalles
                                .Where(p => p.Idmaestro == request.idMaestro && p.Estado)
                                .CountAsync();

            return (coleccion, total);
        }

        public async Task<Maestrodetalle> RegistrarDetalleMaestro(Maestrodetalle request)
        {
            var resultado = await _contexto.Maestrodetalles.AddAsync(request);
            await _contexto.SaveChangesAsync();
            return resultado.Entity;
        }

        public async Task<Maestrodetalle?> BuscarDetalleMaestroById(int IdMaestroDetalle)
        {
            return await _contexto.Maestrodetalles.FindAsync(IdMaestroDetalle);
        }

    }
}
