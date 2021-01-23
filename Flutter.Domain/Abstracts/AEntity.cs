namespace Flutter.Domain.Abstracts
{
    public abstract class AEntity
    {
        public long EntityId { get; set; }
        public AEntity()
        {
            EntityId = System.DateTime.Now.Ticks;
        }
    }
}