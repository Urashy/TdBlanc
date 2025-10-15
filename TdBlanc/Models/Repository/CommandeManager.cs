using TdBlanc.Models.EntityFramework;
using TdBlanc.Models.Repository.Interfaces;

namespace TdBlanc.Models.Repository
{
    public class CommandeManager : ISearchableRepository<Commande,String>, IReadableRepository<Commande, int>, IWriteableRepository<Commande>
    {

        public CommandeManager(CommandeBDContext context) : base(context)
        {
        }

        public Task AddAsync(Commande entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Commande entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Commande>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Commande?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Commande entityToUpdate, Commande entity)
        {
            throw new NotImplementedException();
        }

        public Task<Commande?> GetByKeyAsync(string key)
        {
            throw new NotImplementedException();
        }
    }
}
