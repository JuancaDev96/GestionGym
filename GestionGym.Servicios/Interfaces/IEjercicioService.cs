using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response.Ejercicios;
using GestionGym.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Servicios.Interfaces
{
    public interface IEjercicioService
    {
        Task<BaseResponse> Actualizar(EjercicioRequest request);
        Task<BaseResponse<EjercicioResponse>> Registrar(EjercicioRequest request);
        Task<PaginationResponse<ListaEjerciciosResponse>> ListarEjerciciosByEstablecimiento(BusquedaEjerciciosRequest request);
    }
}
