using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entitities;

namespace Core.Interfaces
{
  
    public interface IProductRepository
    {

          //1 Product
         Task<Products> GetProductByIdAsync(int id);

        Task<IReadOnlyList<Products>>  GetProductAsync();

          //2 Brands
        Task<IReadOnlyList<ProductBrand>>  GetProductBrandsAsync();

          //3 Types
        Task<IReadOnlyList<ProductType>>  GetProductTypesAsync();
        
    }



}