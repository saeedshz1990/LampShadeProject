using ShopManagement.Application.Contracts.Order;

namespace _01_LampShadeQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
