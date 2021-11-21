using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Product.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(string slug);
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);
        
    }
}