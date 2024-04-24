﻿using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class CreateInventory
    {

        public CreateInventory()
        {
            Products = new List<ProductViewModel>();
        }

        [Range(1, 10000, ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}

