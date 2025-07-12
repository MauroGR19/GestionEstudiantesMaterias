namespace Domain.Interface
{
    public interface IList<TEntity, TEntityID>
    {
        TEntity GetByID(TEntityID entityID);
        List<TEntity> GetAll();
    }
}
