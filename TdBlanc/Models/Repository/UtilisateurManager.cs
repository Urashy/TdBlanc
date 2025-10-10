using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;

namespace TdBlanc.Models.Repository
{
    public class UtilisateurManager : NamedManagerGenerique<Utilisateur> 
    {
        public UtilisateurManager(CommandeBDContext context) : base(context)
        {
        }

        // Override pour inclure les relations
        public override async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            return await dbSet
                .ToListAsync();
        }

        public override async Task<Utilisateur?> GetByIdAsync(int id)
        {
            return await dbSet
                .Include(m => m.Commandes)
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
        }

        public override async Task<Utilisateur?> GetByNameAsync(string name)
        {
            return await dbSet
                .FirstOrDefaultAsync(m => m.Nom == name);
        }
    }
}
