using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response.Ejercicios;
using GestionGym.Dto.Response;

namespace GestionGym.Ui.Proxys.Interfaces
{
    public interface IEjercicioProxy
    {
        Task<PaginationResponse<ListaEjerciciosResponse>> GetEjercicios(BusquedaEjerciciosRequest request);
    }
}
