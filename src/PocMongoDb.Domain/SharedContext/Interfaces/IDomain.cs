namespace PocMongoDb.Domain.SharedContext.Interfaces
{
    public interface IDomain<TDto>
    {
        public Task<IEnumerable<TDto>> ListAsync(CancellationToken cancel);
        public Task<TDto> GetByIdAsync(Guid id, CancellationToken cancel);
        public Task<TDto> InsertAsync(TDto data, CancellationToken cancel);
        public Task<IEnumerable<TDto>> InsertManyAsync(IEnumerable<TDto> data, CancellationToken cancel);
        public Task<TDto> UpdateAsync(TDto data, CancellationToken cancel);
        public Task<TDto> DeleteAsync(Guid id, CancellationToken cancel);
    }
}
