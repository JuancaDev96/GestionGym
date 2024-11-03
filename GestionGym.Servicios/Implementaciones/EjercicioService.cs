using AutoMapper;
using GestionGym.Comun;
using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response;
using GestionGym.Dto.Response.Ejercicios;
using GestionGym.Repositorios.Interfaces;
using GestionGym.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Implementaciones
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repository;
        private readonly IMapper _mapper;

        public EjercicioService(IEjercicioRepository ejercicioRepository, IMapper mapper)
        {
            _repository = ejercicioRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ListaEjerciciosResponse>> ListarEjerciciosByEstablecimiento(BusquedaEjerciciosRequest request)
        {
            var respuesta = new PaginationResponse<ListaEjerciciosResponse>();
            try
            {
                var resultado = await _repository.ListAsync(
                    predicado: p => p.Estado && p.IdEstablecimiento == Constantes.IdEstablecimientoDefault,
                    selector: p => new ListaEjerciciosResponse
                    {
                        Id = p.Id,
                        Descripcion = p.Descripcion,
                        GrupoMuscular = p.IdgrupomuscularParametroNavigation.Valor,
                        IdGrupoMuscular = p.IdgrupomuscularParametro,
                        Nombre = p.Nombre,
                        FechaRegistro = p.Fecharegistro
                    },
                    pagina: request.Pagina,
                    filas: request.Filas,
                    orderBy: p => p.Nombre);

                respuesta.Collection = resultado.Coleccion;
                respuesta.TotalRegistros = resultado.TotalRegistros;
                respuesta.TotalPaginas = Utils.CalcularPaginacion(resultado.TotalRegistros, request.Filas);
            }
            catch (Exception ex)
            {
                respuesta.Success = false;
                respuesta.Message = ex.Message;
            }
            return respuesta;
        }
    }
}
