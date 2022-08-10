using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IPaymentService
    {
        public Task<PayStackResponse> CreatePaymentAsync(int userId);
    }
}
