using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T> 
    {
        Expression<Func<T, bool>> Criteria { get; }  //pr. Criteria predstavlja kad se pretrazuje TASK sa odredjenim ID-em, Func vraca boolean value, a to je criteria
        List<Expression<Func<T, object>>> Includes {get;}  //list of includes statement that we can pass to listasync method

    }
}