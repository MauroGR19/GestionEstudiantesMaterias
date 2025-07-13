using Domain.Interface;

namespace GestionEstudiantesMaterias.Interface
{
    public interface IEnrollmentService<TEntity, TEntityID>
    : IInsert<TEntity>, IDelete<TEntityID>
    {
        List<TEntity> GetAll(string Document);
    }
}
