namespace TdBlanc.Models.Repository
{
    public interface ISearchableRepository<TEntity, in TKey>
    {
        Task<TEntity?> GetByKeyAsync(TKey key);
    }
}
