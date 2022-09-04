﻿using System.Linq.Expressions;

namespace Core.Spesifications
{
    public interface ISpesification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }

    }
}
