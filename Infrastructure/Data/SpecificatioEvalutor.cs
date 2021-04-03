using System;
using System.Linq;
using Core.Entitities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificatioEvalutor<TEntity> where TEntity:BaseEntity
    {
        //Function
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecifications<TEntity> spec)
        {


        var query=inputQuery;
        if(spec.Criteria !=null)
        {
          query=query.Where(spec.Criteria);
        }

        query=spec.Includes.Aggregate(query, (current, include)=>current.Include(include));
        return query;


        }
    }

    public struct NewStruct
    {
        public object current;
        public object includes;

        public NewStruct(object current, object includes)
        {
            this.current = current;
            this.includes = includes;
        }

        public override bool Equals(object obj)
        {
            return obj is NewStruct other &&
                   System.Collections.Generic.EqualityComparer<object>.Default.Equals(current, other.current) &&
                   System.Collections.Generic.EqualityComparer<object>.Default.Equals(includes, other.includes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(current, includes);
        }

        public void Deconstruct(out object current, out object includes)
        {
            current = this.current;
            includes = this.includes;
        }

        public static implicit operator (object current, object includes)(NewStruct value)
        {
            return (value.current, value.includes);
        }

        public static implicit operator NewStruct((object current, object includes) value)
        {
            return new NewStruct(value.current, value.includes);
        }
    }
}