using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface ICartService
    {
        Task<BaseResponse<CartDto>> Create(CartRequestModel model);
        Task<BaseResponse<CartDto>> Get(int id);
        Task<BaseResponse<IEnumerable<CartDto>>> GetAll();
        Task<BaseResponse<CartDto>> GetCartByCustomerId(int id);
        Task<BaseResponse<CartDto>> UpdateCart(int id);
        Task<BaseResponse<IEnumerable<CartDto>>> GetProccessingCart();
        Task<BaseResponse<IEnumerable<CartDto>>> GetCompletedCart();
        Task<BaseResponse<IEnumerable<CartDto>>> GetAllCartByCustomerId(int id);
        Task<BaseResponse<IEnumerable<CartDto>>> GetAllProccessingCartCustomerId(int id);
        Task<BaseResponse<IEnumerable<CartDto>>> GetAllCompletedCartByCustomerId(int id);
        Task<BaseResponse<IEnumerable<CartDto>>> GetAllReceivedCartByCustomer(int id);

    }
}
