using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;

namespace TdBlanc.Models.Repository
{
    public abstract class NamedManagerGenerique<TEntity> : ManagerGenerique<TEntity>, INamedRepository<TEntity>
    where TEntity : class, INamedEntity
    {
        protected NamedManagerGenerique(CommandeBDContext context) : base(context)
        {
        }

        public virtual async Task<TEntity?> GetByNameAsync(string name)
        {
            return await dbSet.FirstOrDefaultAsync(e => e.Nom == name);
        }
    }
}
