using Dapper;
using GestionGym.AccesoDatos.Contexto;
using GestionGym.Comun;
using GestionGym.Dto.Request.Clientes;
using GestionGym.Entidades;
using GestionGym.Entidades.Response.Clientes;
using GestionGym.Entidades.Response.Suscripcion;
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
    public class EjercicioRepository : BaseRepository<Ejercicio>, IEjercicioRepository
    {
        private readonly BdGymContext _contexto;
        public EjercicioRepository(BdGymContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task Registrar(Ejercicio request, List<Rutinaejercicio> rutina)
        {
            await using (var transaccion = await _contexto.Database.BeginTransactionAsync())
            {
                try
                {
                    var nuevoEjercicio = await _contexto.Ejercicios.AddAsync(request);
                    await _contexto.SaveChangesAsync();

                    if (nuevoEjercicio != null)
                    {
                        if (rutina.Count > 0)
                        {
                            rutina.ForEach(p => p.Idejercicio = nuevoEjercicio.Entity.Id);
                            await _contexto.Rutinaejercicios.AddRangeAsync(rutina);
                            await _contexto.SaveChangesAsync();
                        }
                        await transaccion.CommitAsync();
                    }
                    else
                        await transaccion.RollbackAsync();
                }
                catch (Exception)
                {
                    await transaccion.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<Recursosejercicio> RegistrarRecurso(Recursosejercicio request)
        {
            var respuesta = await _contexto.Recursosejercicios.AddAsync(request);
            await _contexto.SaveChangesAsync();
            return respuesta.Entity;
        }

        public async Task<List<Rutinaejercicio>> ObtenerRutinaByIdEjercicio(int idEjercicio)
        {
            return await _contexto.Rutinaejercicios.Where(p => p.Idejercicio == idEjercicio).ToListAsync();
        }
    }
}
