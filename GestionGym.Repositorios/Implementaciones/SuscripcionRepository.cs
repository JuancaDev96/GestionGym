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
    public class SuscripcionRepository : BaseRepository<Suscripcion>, ISuscripcionRepository
    {
        private readonly BdGymContext _contexto;
        private readonly IClienteRepository _clienteRepositorio;
        public SuscripcionRepository(BdGymContext contexto, IClienteRepository clienteRepositorio) : base(contexto)
        {
            _contexto = contexto;
            _clienteRepositorio = clienteRepositorio;
        }

        public async Task<List<Preciossuscripcion>> ListarPreciosTipoSuscripcion(int idTipoSuscripcion)
        {
            return await _contexto.Preciossuscripcions.Where(p => p.IdtiposuscripcionParametro == idTipoSuscripcion && p.Estado).ToListAsync();
        }

        public async Task<Suscripcion> Registrar(Suscripcion request, Cliente cliente, DateTime FechaInicio, int IdObjetivo, int IdNivel)
        {
            await using (var trx = await _contexto.Database.BeginTransactionAsync())
            {
                try
                {
                    cliente.Idestablecimiento = 1;
                    var EstadoActivo = await _contexto.Maestrodetalles.FirstOrDefaultAsync(p => p.Codigo == CodigoMaestro.ESUSC_ACTIVO);

                    if (EstadoActivo is not null)
                        request.Idestadosuscripcion = EstadoActivo.Id;

                    #region Creacion del Cliente, Control Fisico y Ficha del cliente

                    var nuevoCliente = await _contexto.Clientes.AddAsync(cliente);
                    await _contexto.SaveChangesAsync();

                    if (nuevoCliente is not null)
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
                                    Idcliente = nuevoCliente.Entity.Id,
                                    Idparametro = item.Id
                                };
                                await _contexto.ControlfisicoClientes.AddAsync(controlfisico);
                                await _contexto.SaveChangesAsync();
                            }
                        }

                        request.Idcliente = nuevoCliente.Entity.Id;

                        var ficha = new Fichacliente
                        {
                            Idcliente = nuevoCliente.Entity.Id,
                            Fechainicio = FechaInicio,
                            IdobjetivoParametro = IdObjetivo,
                            IdnivelParametro = IdNivel
                        };

                        await _contexto.Fichaclientes.AddAsync(ficha);
                        await _contexto.SaveChangesAsync();
                    }
                    else
                    {
                        await trx.RollbackAsync();
                    }

                    #endregion
                    var suscripcion = await _contexto.Suscripcions.AddAsync(request);
                    await _contexto.SaveChangesAsync();



                    await trx.CommitAsync();

                    return suscripcion.Entity;
                }
                catch (Exception)
                {
                    await trx.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
