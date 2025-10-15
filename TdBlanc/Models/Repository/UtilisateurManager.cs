using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;
using TdBlanc.Models.Repository.Interfaces;

namespace TdBlanc.Models.Repository
{
    public class UtilisateurManager : ISearchableRepository<Utilisateur, string>,
                                    IReadableRepository<Utilisateur, int>,
                                    IWriteableRepository<Utilisateur>
    {
        private readonly CommandeBDContext _context;

        public UtilisateurManager(CommandeBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Utilisateur>> GetAllAsync()
        {
            return await _context.Utilisateurs
                .Include(c => c.Commandes)
                .ToListAsync();
        }

        public async Task<Utilisateur?> GetByIdAsync(int id)
        {
            return await _context.Utilisateurs
                .Include(c => c.Commandes)
                .FirstOrDefaultAsync(c => c.IdUtilisateur == id);
        }

        public async Task<Utilisateur?> GetByKeyAsync(string key)
        {
            return await _context.Utilisateurs
                .Include(c => c.Commandes)
                .FirstOrDefaultAsync(c => c.Nom == key);
        }

        public async Task AddAsync(Utilisateur entity)
        {
            await _context.Utilisateurs.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Utilisateur entityToUpdate, Utilisateur entity)
        {
            _context.Entry(entityToUpdate).State = EntityState.Detached;

            entity.IdUtilisateur = entityToUpdate.IdUtilisateur;
            _context.Utilisateurs.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Utilisateur entity)
        {
            _context.Utilisateurs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}