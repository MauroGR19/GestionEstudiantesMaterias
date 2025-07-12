namespace Domain.Interface
{
    public interface IInsert<TEntity>
    {
        bool Insert(TEntity entity);
    }
}
