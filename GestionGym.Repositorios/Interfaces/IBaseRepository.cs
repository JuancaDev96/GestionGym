using GestionGym.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionGym.Repositorios.Interfaces
{
     public interface IBaseRepository<TEntity> where TEntity : EntidadBase
    {
        Task<ICollection<TEntity>> ListAsync();
        Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicado);
        Task<ICollection<TResult>> ListAsync<TResult>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TResult>> selector
            );

        Task<(ICollection<TResult> Coleccion, int TotalRegistros)> ListAsync<TResult, TKey>(
            Expression<Func<TEntity, bool>> predicado,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, TKey>> orderBy,
            int pagina = 1, int filas = 5
            );

        Task<TEntity?> FindByIdAsync(int id);

        Task<TResult?> FindOneAsync<TResult>(
           Expression<Func<TEntity, bool>> predicado,
           Expression<Func<TEntity, TResult>> selector
           );

        Task<TEntity> AddAsync(TEntity entidad);

        Task AddRangeAsync(List<TEntity> entidad);
        Task UpdateAsync();

        Task DeleteAsync(int Id);
    }
}
