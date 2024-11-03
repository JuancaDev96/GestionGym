using GestionGym.Dto.Request.Clientes;
using GestionGym.Dto.Response.Suscripciones;
using GestionGym.Dto.Response;
using GestionGym.Ui.Proxys.Interfaces;
using GestionGym.Dto.Request.Ejercicios;
using GestionGym.Dto.Response.Ejercicios;

namespace GestionGym.Ui.Proxys.Services
{
    public class EjercicioProxy(HttpClient httpClient) : ProxyBase("api/Ejercicios", httpClient), IEjercicioProxy
    {
        public async Task<PaginationResponse<ListaEjerciciosResponse>> GetEjercicios(BusquedaEjerciciosRequest request)
        {
            return await SendAsync<PaginationResponse<ListaEjerciciosResponse>>($"Paginacion?{QueryStringDto(request)}");
        }
    }
}
