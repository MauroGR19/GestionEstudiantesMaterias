﻿using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IUseCaseBase<TEntity, TEntityID>
        : IInsert<TEntity>, IUpdate<TEntity>, IDelete<TEntityID>, IList<TEntity, TEntityID>
    {
    }
}
