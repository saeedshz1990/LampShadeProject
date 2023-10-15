namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryOperationViewModel
    {
        public long Id { get; set; }
        public bool Operation { get; set; }
        public long Count { get; set; }
        public long OperatorId { get; set; }
        public string Operator { get; set; } = string.Empty;
        public string OperationDate { get; set; } = string.Empty;
        public long CurrentCount { get; set; }
        public string Description { get; set; } = string.Empty;
        public long OrderId { get; set; }
    }
}
