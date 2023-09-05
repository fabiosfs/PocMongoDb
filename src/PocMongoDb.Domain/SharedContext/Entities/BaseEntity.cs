namespace PocMongoDb.Domain.SharedContext.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTimeOffset? Created { get; set; }
        public virtual DateTimeOffset? Updated { get; set; }
        
        public BaseEntity() 
        {
            Created = DateTimeOffset.Now;
            Updated = DateTimeOffset.Now;
        }

        public virtual void GenerateId() { Id = Guid.NewGuid(); }
        public virtual void CreateDate() { Created = DateTimeOffset.Now; }
        public virtual void UpdateDate() { Updated = DateTime.Now; }
    }
}
