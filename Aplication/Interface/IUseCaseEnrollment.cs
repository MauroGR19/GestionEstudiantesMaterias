using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IUseCaseEnrollment<TEntity, TEntityID>
        : IInsert<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>
    {
    }
}
