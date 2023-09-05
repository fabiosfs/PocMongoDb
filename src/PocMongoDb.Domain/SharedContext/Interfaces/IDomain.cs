namespace PocMongoDb.Domain.SharedContext.Interfaces
{
    public interface IDomain<TEntity>
    {
        public Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancel);
        public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancel);
        public Task<TEntity> InsertAsync(TEntity data, CancellationToken cancel);
        public Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> data, CancellationToken cancel);
        public Task<TEntity> UpdateAsync(TEntity data, CancellationToken cancel);
        public Task<TEntity> DeleteAsync(Guid id, CancellationToken cancel);
    }
}
