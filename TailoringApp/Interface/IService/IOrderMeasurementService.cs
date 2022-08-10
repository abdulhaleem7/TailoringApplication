using TailoringApp.Dto;

namespace TailoringApp.Interface.IService
{
    public interface IOrderMeasurementService
    { 
        Task<BaseResponse<OrderMeasurementDto>> Get(int id);
        Task<BaseResponse<IEnumerable<OrderMeasurementDto>>> GetAll();
        Task<BaseResponse<OrderMeasurementDto>> GetMeasurementOrderByCustomerId(int id);

        Task<BaseResponse<OrderMeasurementDto>> GetMeasuremenvalueByCustomerId(int id, string name);
    }
}
