using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface ICustomerService
    {
        Task<BaseResponse<CustomerDto>> Create(CustomerRequestModel model);
        Task<BaseResponse<CustomerDto>> Get(int id);
        Task<BaseResponse<IEnumerable<CustomerDto>>> GetAll();
    }
}
