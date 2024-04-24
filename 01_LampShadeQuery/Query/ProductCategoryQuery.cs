using _0_FrameWork.Application;
using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using DiscountManagement.Infrasutructure.EFCore;
using InventoryManagement.Infrasutructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrasutructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).AsNoTracking().ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = _inventoryContext.Inventory
            .Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var discounts = _discountContext.CustomerDisounts.
            Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var categories = _shopContext.ProductCategories
            .Include(x => x.Products)
            .ThenInclude(x => x.Category)
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Products = MapProducts(x.Products)

            }).AsNoTracking().ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {

                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();

                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount != null)
                        {
                            int discountRate = discount.DiscountRate;
                            product.Discountrate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PriceWithDiscount = (price - discountAmount).ToMoney();
                        }
                    }
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var result = new List<ProductQueryModel>();
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                Category = product.Category.Name
            }).ToList();
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug)
        {
            var inventory = _inventoryContext.Inventory
           .Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDisounts.
            Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            var category = _shopContext.ProductCategories
            .Include(x => x.Products)
            .ThenInclude(x => x.Category)
            .Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                Products = MapProducts(x.Products)
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);
            foreach (var product in category.Products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.Discountrate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }
            return category;
        }
    }
}
