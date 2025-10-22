using Microsoft.EntityFrameworkCore;
using TdBlanc.Models.EntityFramework;
using TdBlanc.Models.Repository.Interfaces;

namespace TdBlanc.Models.Repository
{
    public class AnimalManager : ISearchableRepository<Animal, string>,
                                    IReadableRepository<Animal, int>,
                                    IWriteableRepository<Animal>
    {
        private readonly CommandeBDContext _context;

        public AnimalManager(CommandeBDContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _context.Animaux
                .ToListAsync();
        }

        public async Task<Animal?> GetByIdAsync(int id)
        {
            return await _context.Animaux
                .FirstOrDefaultAsync(c => c.IdAnnimal == id);
        }

        public async Task<Animal?> GetByKeyAsync(string key)
        {
            return await _context.Animaux
                .FirstOrDefaultAsync(c => c.Nom == key);
        }

        public async Task AddAsync(Animal entity)
        {
            await _context.Animaux.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Animal entityToUpdate, Animal entity)
        {
            _context.Entry(entityToUpdate).State = EntityState.Detached;

            entity.IdAnnimal = entityToUpdate.IdAnnimal;
            _context.Animaux.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Animal entity)
        {
            _context.Animaux.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
