namespace Domain.Interface
{
    public interface IUpdate<TEntity>
    {
        bool Update(TEntity entity);

    }
}

