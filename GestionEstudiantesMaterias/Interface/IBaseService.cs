using Domain.Interface;

namespace GestionEstudiantesMaterias.Interface
{
    public interface IBaseService<TEntity, TEntityID>
       : IDelete<TEntityID>, IList<TEntity, TEntityID>, IUpdate<TEntity>, IInsert<TEntity>
    {
    }
}
