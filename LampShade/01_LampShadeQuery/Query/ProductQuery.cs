using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _01_LampShadeQuery.Contracts.Product.Product;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampShadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
         private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {
            throw new NotImplementedException();
        }

        public List<ProductQueryModel> GetLatestArrivals()
        {
                var inventory=_inventoryContext.Inventory.Select(x=> new {x.ProductId,x.UnitPrice}).ToList();

                        var discounts=_discountContext.CustomerDiscount.Where(x=>x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x=> new {x.DiscountRate,x.ProductId}).ToList();

            var products=_shopContext.Products
            .Include(x=>x.Category).Select(product=> new ProductQueryModel
            {
                     Id=product.Id,
                    Name=product.Name,
                    Picture=product.Picture,
                    PictureAlt=product.PictureAlt,
                    PictureTitle=product.PictureTitle,
                    Slug=product.Slug,
                    Category=product.Category.Name
                 
            }).AsNoTracking().OrderByDescending(x=>x.Id).Take(6).ToList();
            foreach (var product in products)
                    {
                       var productInventory=inventory.FirstOrDefault(x=>x.ProductId==product.Id);
                         if(productInventory!=null)
                         {
                             var price=productInventory.UnitPrice;
                              product.Price=price.ToMoney();  

                              var discount=discounts.FirstOrDefault(x=>x.ProductId==product.Id);
                                 if(discount!=null)
                                {
                                    int discountRate=discount.DiscountRate;
                                    product.DiscountRate=discountRate;
                                    product.HasDiscount=discountRate >0 ;
                                    var discountAmount=Math.Round((product.Price * discountRate)/100);
                                    product.ProductWithDiscount=(price-discountAmount).ToMoney(); 
                                }
                         }

                    }
            return products;
        }

        public List<ProductQueryModel> Search(string value)
        {
             var inventory=_inventoryContext.Inventory
            .Select(x=> new {x.ProductId,x.UnitPrice}).ToList();
            var discounts=_discountContext.CustomerDiscount.
            Where(x=>x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x=> new {x.DiscountRate,x.ProductId,x.EndDate}).ToList();
           
            var query= _shopContext.Products
            .Include(x=>x.Category)
            .Select(product=> new ProductQueryModel
            {
                    Id=product.Id,
                    Name=product.Name,
                    Picture=product.Picture,
                    PictureAlt=product.PictureAlt,
                    PictureTitle=product.PictureTitle,
                    Slug=product.Slug,
                    CategorySlug=product.Category.Slug,
                    Category=product.Category.Name,
                    ShortDescription=product.ShortDescription
            }).AsNoTracking();

            if(!string.IsNullOrWhiteSpace(value))
                query=query.Where(x=>x.Name.Contains(value)||x.ShortDescription.Contains(value));

            var products=query.OrderByDescending(x=>x.Id).ToList();



               foreach (var product in products)
                    {
                        var productInventory=inventory.FirstOrDefault(x=>x.ProductId==product.Id);
                         if(productInventory!=null)
                         {
                             var price=productInventory.UnitPrice;
                              product.Price=price.ToMoney();  
                              var discount=discounts.FirstOrDefault(x=>x.ProductId==product.Id);
                                 if(discount!=null)
                                {
                                    int discountRate=discount.DiscountRate;
                                    product.DiscountRate=discountRate;
                                    product.DiscountExpireDate=discount.EndDate.ToDiscountFormat();
                                    product.HasDiscount=discountRate >0 ;
                                    var discountAmount=Math.Round((product.Price * discountRate)/100);
                                    product.ProductWithDiscount=(price-discountAmount).ToMoney(); 
                                }
                         }
                    }
            return products;
        }
    }
}