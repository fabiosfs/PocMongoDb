using MongoDB.Driver;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;
using System.Linq.Expressions;

namespace PocMongoDb.Domain.Repositories.Shared
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected IMongoCollection<TEntity> _collection { get; set; }

        public BaseRepository(IMongoDatabase database, string collection)
        {
            _collection = database.GetCollection<TEntity>(collection, null);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancel)
        {
            var records = await ListAsync(_ => true, cancel);

            return records;
        }

        protected virtual async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> fillter, CancellationToken cancel)
        {
            var records = await _collection.FindAsync(fillter, null, cancel);

            var data = records.ToList();

            return data.ToList();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancel)
        {
            var records = await ListAsync(_ => _.Id == id, cancel);

            return records.FirstOrDefault();
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancel)
        {
            await _collection.InsertOneAsync(entity, null, cancel);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> InsertManyAsync(IEnumerable<TEntity> entity, CancellationToken cancel)
        {
            await _collection.InsertManyAsync(entity, null, cancel);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancel)
        {
            var options = new ReplaceOptions();
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity, options, cancel);
            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id, CancellationToken cancel)
        {
            var data = await _collection.FindOneAndDeleteAsync(x => x.Id == id, null, cancel);
            return data;
        }
    }
}
