﻿using _0_FrameWork.Domain;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        //Store list of inventoryoperation in Inventory
        public List<InventoryOpearation> Operations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        private long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateCurrentCount()+ count;
            var operation = new InventoryOpearation(true,count,operatorId ,currentCount,description,0,Id );
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operatorId, string description,long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOpearation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }
}
