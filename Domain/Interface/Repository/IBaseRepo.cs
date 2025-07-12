using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Repository
{
    public interface IRepoBase<TEntity, TEntityID>
        : IInsert<TEntity>, IUpdate<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>, ISaveAll
    {
    }
}
