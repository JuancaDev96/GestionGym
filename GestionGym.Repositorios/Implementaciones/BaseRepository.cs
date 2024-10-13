using GestionGym.AccesoDatos.Contexto;
using GestionGym.Entidades;
using GestionGym.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Implementaciones
{

    public class RepositoryBase<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadBase
    {
        protected readonly BdGymContext Contexto;

        public RepositoryBase(BdGymContext context)
        {
            Contexto = context;
        }

        public async Task<ICollection<TEntity>> ListAsync()
        {
            return await Contexto.Set<TEntity>()
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicado)
        {
            return await Contexto.Set<TEntity>()
                        .Where(predicado)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<ICollection<TResult>> ListAsync<TResult>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TResult>> selector
            )
        {
            return await Contexto.Set<TEntity>()
                        .Where(predicado)
                        .AsNoTracking()
                        .Select(selector)
                        .ToListAsync();
        }

        public async Task<(ICollection<TResult> Coleccion, int TotalRegistros)> ListAsync<TResult, TKey>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            int pagina = 1, int filas = 5
            )
        {
            var resultado = await Contexto.Set<TEntity>()
                        .Where(predicado)
                        .AsNoTracking()
                        .OrderBy(orderBy)
                        .Skip((pagina - 1) * filas)
                        .Take(filas)
                        .Select(selector)
                        .ToListAsync();

            var total = await Contexto.Set<TEntity>()
                               .Where(predicado)
                               .CountAsync();

            return (resultado, total);
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await Contexto.Set<TEntity>().FindAsync(id);
        }

        public async Task<TResult?> FindOneAsync<TResult>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TResult>> selector
            )
        {
            return await Contexto.Set<TEntity>()
                        .Where(predicado)
                        .AsNoTracking()
                        .Select(selector)
                        .FirstOrDefaultAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entidad)
        {
            var resultado = await Contexto.Set<TEntity>().AddAsync(entidad);
            await Contexto.SaveChangesAsync();
            return resultado.Entity;
        }

        public async Task AddRangeAsync(List<TEntity> entidad)
        {
            await Contexto.Set<TEntity>().AddRangeAsync(entidad);
            await Contexto.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await Contexto.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var resultado = await Contexto.Set<TEntity>().FindAsync(Id);
            if (resultado != null)
            {
                resultado!.Estado = false;
                await Contexto.SaveChangesAsync();
            }
        }

    }
}
