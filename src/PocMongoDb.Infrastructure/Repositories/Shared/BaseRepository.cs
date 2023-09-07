using MongoDB.Driver;
using PocMongoDb.Domain.SharedContext.Entities;
using PocMongoDb.Domain.SharedContext.Interfaces;
using System.Linq.Expressions;

namespace PocMongoDb.Domain.Repositories.Shared
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected IMongoCollection<TEntity> _collection { get; set; }

        public BaseRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<TEntity>(typeof(TEntity).Name.Replace("Entity", ""), null);
        }

        public virtual async Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancel) => await ListAsync(_ => true, cancel);

        protected virtual async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> fillter, CancellationToken cancel)
            => (await _collection.FindAsync(fillter, null, cancel)).ToList();

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancel) => (await ListAsync(_ => _.Id == id, cancel)).FirstOrDefault();


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

        public virtual async Task<TEntity> DeleteAsync(Guid id, CancellationToken cancel) => await _collection.FindOneAndDeleteAsync(x => x.Id == id, null, cancel);
    }
}
