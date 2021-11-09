using System.Collections.Generic;
using ShopManagement.Application.Contracts.Product;
using _0_FrameWork.Domain;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IRepository<long,Product>
    {
        // return list product view model
        List<ProductViewModel> Search(ProductSearchModel searchModel);

        EditProduct GetDeatails(long id);

    }
}
