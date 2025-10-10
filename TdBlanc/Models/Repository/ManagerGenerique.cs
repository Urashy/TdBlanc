using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;

namespace TdBlanc.Models.Repository
{
    public abstract class ManagerGenerique<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        protected readonly CommandeBDContext context;
        protected readonly DbSet<TEntity> dbSet;

        public ManagerGenerique(CommandeBDContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
