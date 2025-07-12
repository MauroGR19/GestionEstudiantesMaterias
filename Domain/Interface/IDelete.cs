namespace Domain.Interface
{
    public interface IDelete<TEntityID>
    {
        bool Delete(TEntityID entityID);
    }
}
