using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IOrderService
    {
        Task<BaseResponse<OrderDto>> Create(OrderRequestModel model,int userId);
        Task<BaseResponse<OrderDto>> Get(int id);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetAll();
        Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderByCustomerId(int id);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderByCartId(int cartId);
        Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOProccessing(int cartId);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetProccessingOrderByCartId(int cartId);
        Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOCompleted(int cartId);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetCompletedOrderByCartId(int cartId);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetAllItemsInCartByCustomerId(int cartId);
        Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOCollected(int cartId);
        Task<BaseResponse<IEnumerable<OrderDto>>> GetHistoryOrderByCartId(int cartId);

        Task<BaseResponse<OrderDto>> DeleteOrdersInCart(int cartId);



    }
}
