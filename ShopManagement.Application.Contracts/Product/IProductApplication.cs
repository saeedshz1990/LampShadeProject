using System.Collections.Generic;
using _0_FrameWork.Application;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        //For Create Product
        OperationResult Create(CreateProduct command);

        //Fore Edit Product
        OperationResult Edit(EditProduct command);

       
        //Return EditProduct and Get Id
        EditProduct GetDetails(long id);

        //return list ProductViewModel
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        List<ProductViewModel> GetProducts();
    }
}
