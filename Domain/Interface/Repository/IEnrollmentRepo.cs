using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IEnrollmentRepo<TEntity, TEntityID>
        : IInsert<TEntity>, IDelete<TEntityID>, ISaveAll
    {
        TEntity GetByID(string Document, int Code);
        List<TEntity> GetAll(string Document);
    }
}
