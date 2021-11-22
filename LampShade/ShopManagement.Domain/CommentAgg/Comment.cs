using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ProductId { get; private set; }
        public Product Product { get; private set; }
        
        public Comment(string name, string email, string message, long productId)
        {
            this.Name = name;
            this.Email = email;
            this.Message = message;
            this.ProductId = productId;

        }

        public void Confirm()
        {
            IsConfirmed=true;
        }
        public void Cancel()
        {
            IsCanceled=true;
        }
    }
}