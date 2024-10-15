using Dapper;
using GestionGym.AccesoDatos.Contexto;
using GestionGym.Comun;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionGym.Repositorios.Implementaciones
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly BdGymContext _contexto;
        public ClienteRepository(BdGymContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Cliente> Registrar(Cliente request)
        {
            var nuevo = await _contexto.Clientes.AddAsync(request);
            await _contexto.SaveChangesAsync();

            if (nuevo is not null)
            {
                var ControlFisicoParametros = await _contexto.Maestrodetalles
                                            .Where(p => p.IdmaestroNavigation.Codigo == CodigoMaestro.CTRL_FISICO && p.Esdefault == true)
                                            .ToListAsync();

                if (ControlFisicoParametros.Any())
                {
                    foreach (var item in ControlFisicoParametros)
                    {
                        ControlfisicoCliente controlfisico = new()
                        {
                            Idcliente = nuevo.Entity.Id,
                            Idparametro = item.Id
                        };
                        await _contexto.ControlfisicoClientes.AddAsync(controlfisico);
                        await _contexto.SaveChangesAsync();
                    }
                }
                return nuevo.Entity;
            }
            return new Cliente();
        }

        public async Task<List<ControlFisicoClienteResponse>> ListarControlFisicoByIdCliente(int IdCliente)
        {
            return await _contexto.ControlfisicoClientes
                                .Where(p => p.Idcliente == IdCliente && p.Estado)
                                .Select(p => new ControlFisicoClienteResponse
                                {
                                    IdCliente = IdCliente,
                                    IdControlFisico = p.Id,
                                    NombreControl = p.IdparametroNavigation.Valor,
                                    ValorControl = p.Valor!,
                                    DescripcionControl = p.IdparametroNavigation.Descripcion!
                                }).ToListAsync();
        }

        public async Task<(List<ClientePaginadoResponse> coleccion, int totalRegistros, int totalPaginas)> ListarClientes(BusquedaClientesRequest request)
        {
            using (var connection = _contexto.Database.GetDbConnection())
            {
                var sql = "SELECT * FROM sp_get_clientes_paginados(@_idestablecimiento, @_nombre, @_dni, @_pagenumber, @_pagesize)";

                var parameters = new DynamicParameters();
                // Parámetros de entrada
                parameters.Add("_idestablecimiento", Constantes.IdEstablecimientoDefault, DbType.Int32, ParameterDirection.Input);
                parameters.Add("_nombre", request.Nombre, DbType.String, ParameterDirection.Input);
                parameters.Add("_dni", request.Dni, DbType.String, ParameterDirection.Input);
                parameters.Add("_pagenumber", request.Pagina, DbType.Int32, ParameterDirection.Input);
                parameters.Add("_pagesize", request.Filas, DbType.Int32, ParameterDirection.Input);

                // Ejecutar la consulta SQL dinámica
                var resultados = await connection.QueryAsync<ClientePaginadoResponse>(sql, parameters);

                // Obtener el total de registros del primer elemento
                var totalRegistros = resultados.Any() ? resultados.First().totalRegistros : 0;

                // Calcular la cantidad de registros en la página actual
                var registrosPagina = resultados.Count();

                return (resultados.ToList(), totalRegistros, Utils.CalcularPaginacion(request.Filas, totalRegistros));
            }
        }

    }
}
