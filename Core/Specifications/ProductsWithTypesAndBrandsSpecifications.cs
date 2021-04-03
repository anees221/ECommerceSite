using System;
using System.Linq.Expressions;
using Core.Entitities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecifications : BaseSpecification<Products>
    {
        public ProductsWithTypesAndBrandsSpecifications()
        {

            AddIncludes(x=>x.ProductType);
            AddIncludes(x=>x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecifications(int id) : base(x=>x.id==id)
        {
             AddIncludes(x=>x.ProductType);
            AddIncludes(x=>x.ProductBrand);
        }
    }
}