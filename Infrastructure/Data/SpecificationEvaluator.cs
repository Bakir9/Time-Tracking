using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery; //query  that will be executed

            //evaluate what is in spec
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); //p => p.ProductTypeId == id  lambda expression
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));       //aggregate because we have more than one include statement

            return query; 
        }
    }
}