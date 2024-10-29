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

        public async Task<Suscripcion> Registrar(Suscripcion request, Cliente cliente, DateTime FechaInicio, string Objetivo, int Nivel)
        {
            await using (var trx = await _contexto.Database.BeginTransactionAsync())
            {
                try
                {
                    var EstadoActivo = await _contexto.Maestrodetalles.FirstOrDefaultAsync(p => p.Codigo == CodigoMaestro.ESUSC_ACTIVO);

                    if (EstadoActivo is not null)
                        request.IdestadosuscripcionParametro = EstadoActivo.Id;

                    var suscripcion = await _contexto.Suscripcions.AddAsync(request);
                    await _contexto.SaveChangesAsync();

                    var nuevoCliente = await _clienteRepositorio.Registrar(cliente);

                    if (nuevoCliente is not null)
                    {


                        var ficha = new Fichacliente
                        {
                            Idcliente = nuevoCliente.Id,
                            Fechainicio = FechaInicio,
                            Objetivo = Objetivo,
                            Nivel = Nivel
                        };

                        await _contexto.Fichaclientes.AddAsync(ficha);
                        await _contexto.SaveChangesAsync();
                    }
                    else
                    {
                        await trx.RollbackAsync();
                    }

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
