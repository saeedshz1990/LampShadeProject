using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class DefineCustomerDiscount
    {

        public DefineCustomerDiscount()
        {
            Products = new List<ProductViewModel>();
        }

        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, 99, ErrorMessage = ValidationMessages.IsRequired)]
        public int DiscountRate { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public List<ProductViewModel> Products { get; set; }

    }
}
