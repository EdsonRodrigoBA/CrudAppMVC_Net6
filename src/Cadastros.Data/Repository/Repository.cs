using Cadastros.Business.Interfaces;
using Cadastros.Business.Models;
using Cadastros.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cadastros.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly CadastrosDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        protected Repository(CadastrosDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid Id)
        {
            return await  _dbSet.FindAsync(Id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Remover(Guid Id)
        {
      
            _dbSet.Remove(new TEntity { Id = Id });
            await SaveChanges();

        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }


        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
