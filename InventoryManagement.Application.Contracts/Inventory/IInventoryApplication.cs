using _0_FrameWork.Application;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(ReduceInventory command);//for inventor
        OperationResult Reduce(List<ReduceInventory> command);//for user
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
