namespace TdBlanc.Models.Repository
{
    public interface IDataRepository<TEntity, in TIdentifier, in TKey>
    : ISearchableRepository<TEntity, TKey>,
        IReadableRepository<TEntity, TIdentifier>,
        IWriteableRepository<TEntity>;

}
