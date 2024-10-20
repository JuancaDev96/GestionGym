using GestionGym.Dto.Request.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Repositorios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<Cliente> Registrar(Cliente request);
        Task<List<ControlFisicoClienteResponse>> ListarControlFisicoByIdCliente(int IdCliente);
        Task<(List<ClientePaginadoResponse> coleccion, int totalRegistros, int totalPaginas)> ListarClientes(BusquedaClientesRequest request);
        Task RegistrarParametroControlFisico(ControlfisicoCliente request);
        Task<ControlfisicoCliente?> VerificarExistenciaControlFisico(int IdCliente, int IdParametro);
        Task ActualizarControlFisicoValor(List<ControlfisicoCliente> request);
    }
}
