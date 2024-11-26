using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response.Ejercicios;
using GestionGym.Dto.Response;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IEjercicioProxy
    {
        Task<BaseResponse> RegistrarRecurso(RecursoEjercicioRequest request);
        Task<BaseResponse> Registrar(EjercicioRequest request);
        Task<BaseResponse> Actualizar(EjercicioRequest request);
        Task<PaginationResponse<ListaEjerciciosResponse>> GetEjercicios(BusquedaEjerciciosRequest request);
        Task<BaseResponse<EjercicioResponse>> GetById(int id);
    }
}
