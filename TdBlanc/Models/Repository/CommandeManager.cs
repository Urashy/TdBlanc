using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;
using TdBlanc.Models.Repository.Interfaces;

namespace TdBlanc.Models.Repository
{
    public class CommandeManager : ISearchableRepository<Commande, string>,
                                    IReadableRepository<Commande, int>,
                                    IWriteableRepository<Commande>
    {
        private readonly CommandeBDContext _context;

        public CommandeManager(CommandeBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Commande>> GetAllAsync()
        {
            return await _context.Commandes
                .Include(c => c.CommandeUtlisateurNavigation)
                .ToListAsync();
        }

        public async Task<Commande?> GetByIdAsync(int id)
        {
            return await _context.Commandes
                .Include(c => c.CommandeUtlisateurNavigation)
                .FirstOrDefaultAsync(c => c.IdCommande == id);
        }

        public async Task<Commande?> GetByKeyAsync(string key)
        {
            return await _context.Commandes
                .Include(c => c.CommandeUtlisateurNavigation)
                .FirstOrDefaultAsync(c => c.NomArticle == key);
        }

        public async Task AddAsync(Commande entity)
        {
            await _context.Commandes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commande entityToUpdate, Commande entity)
        {
            _context.Entry(entityToUpdate).State = EntityState.Detached;

            entity.IdCommande = entityToUpdate.IdCommande;
            _context.Commandes.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Commande entity)
        {
            _context.Commandes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}