using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;

namespace TdBlanc.Models.Repository
{
    public class CommandeManager : ManagerGenerique<Commande>
    {
        public CommandeManager(CommandeBDContext context) : base(context)
        {
        }

        // Override pour inclure les relations
        public override async Task<IEnumerable<Commande>> GetAllAsync()
        {
            return await dbSet
                .Include(c => c.CommandeUtlisateurNavigation)
                .ToListAsync();
        }

        public override async Task<Commande?> GetByIdAsync(int id)
        {
            return await dbSet
                .Include(c => c.CommandeUtlisateurNavigation)
                .FirstOrDefaultAsync(m => m.IdCommande == id);
        }
    }
}