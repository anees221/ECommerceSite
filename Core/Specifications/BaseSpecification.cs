using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
            

        public Expression<Func<T, bool>> Criteria  {get;}

        public List<Expression<Func<T, object>>> Includes {get;}=new List<Expression<Func<T, object>>>();

        //Protected Method can be accessed within Same Parent Class as well ootside Child Class as well.

        protected  void AddIncludes(Expression<Func<T,Object>> includeExpression)
         {
          Includes.Add(includeExpression);

        }
    }
}