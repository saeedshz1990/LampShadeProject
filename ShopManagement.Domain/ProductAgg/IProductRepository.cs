using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long, Product>
    {
        Product GetProductWithCategory(long id);
        // return list product view model
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
        EditProduct GetDetails(long id);

    }
}
