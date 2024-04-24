using _0_FrameWork.Application;
using _0_FrameWork.Infrasutructure;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrasutructure.EFCore;

namespace InventoryManagement.Infrasutructure.EFCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;
        private readonly InventoryContext _inventoryContext;

        public InventoryRepository(InventoryContext inventoryContext,
            ShopContext shopContext, AccountContext accountContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
            _accountContext = accountContext;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice

            }).FirstOrDefault(x => x.Id == id);

        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            //it means checkbox is true then show me the false
            if (!searchModel.InStock)
                query = query.Where(x => x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(item =>
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;

            });
            return inventory;
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var accounts = _accountContext.Account.Select(x => new { x.Id, x.Fullname }).ToList();
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            var operations = inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OperatorId = x.OperatorId,
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var operation in operations)
            {
                operation.Operator = accounts.FirstOrDefault(x => x.Id == operation.OperatorId)?.Fullname;
            }

            return operations;

        }
    }
}
