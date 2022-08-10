using TailoringApp.Dto;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class OrderMeasurementService : IOrderMeasurementService
    {
        private readonly IOrderMeasurementRepository _orderMeasurementRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderMeasurementService(IOrderMeasurementRepository orderMeasurementRepository, ICustomerRepository customerRepository)
        {
            _orderMeasurementRepository = orderMeasurementRepository;
            _customerRepository = customerRepository;
        }
        public async Task<BaseResponse<OrderMeasurementDto>> Get(int id)
        {
            var get = await _orderMeasurementRepository.GetAsync(id);
            if (get == null) return new BaseResponse<OrderMeasurementDto> { Message = "failed", Status = false };
            return new BaseResponse<OrderMeasurementDto>
            {
                Message = "success",
                Status = true,
                Data = new OrderMeasurementDto
                {
                    Id = get.Id,
                    SuitLenght = get.SuitLenght,
                    SuitChest = get.SuitChest,
                    SuitShoulder = get.SuitShoulder,
                    SuitSleeve = get.SuitSleeve,
                    SuitWaist = get.SuitWaist,
                    ShirtLenght = get.ShirtLenght,
                    ShirtWaist = get.ShirtWaist,
                    ShirtShoulder = get.ShirtShoulder,
                    ShirtSleeve = get.ShirtSleeve,
                    WaistCoatLenght = get.WaistCoatLenght,
                    WaistCoatWaist = get.WaistCoatWaist,
                    TrouserLenght = get.TrouserLenght,
                    TrouserWaist = get.TrouserWaist,
                    TrouserTight = get.TrouserTight,
                    TrouserKnee = get.TrouserKnee,
                    NativeLenght = get.NativeLenght,
                    NativeShoulder = get.NativeShoulder,
                    NativeSleeve = get.NativeSleeve,
                    NativeWaist = get.NativeWaist,
                    NativeTrouserKnee = get.NativeTrouserKnee,
                    NativeTrouserLenght = get.NativeTrouserLenght,
                    NativeTrouserTight = get.NativeTrouserTight,
                    NativeCap = get.NativeCap,
                    KneekerLenght = get.KneekerLenght,
                    KneekerTight = get.KneekerTight,
                    KneekerWaist = get.KneekerWaist,
                    AgbadaLenght = get.AgbadaLenght,
                }
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderMeasurementDto>>> GetAll()
        {
            var getAll = await _orderMeasurementRepository.GetAllAsync();
            if (getAll == null) return new BaseResponse<IEnumerable<OrderMeasurementDto>> { Message = "failed", Status = false };
            var getAllOrderMeasurement = getAll.ToList().Select(get => new OrderMeasurementDto
            {
                Id = get.Id,
                SuitLenght = get.SuitLenght,
                SuitChest = get.SuitChest,
                SuitShoulder = get.SuitShoulder,
                SuitSleeve = get.SuitSleeve,
                SuitWaist = get.SuitWaist,
                ShirtLenght = get.ShirtLenght,
                ShirtWaist = get.ShirtWaist,
                ShirtShoulder = get.ShirtShoulder,
                ShirtSleeve = get.ShirtSleeve,
                WaistCoatLenght = get.WaistCoatLenght,
                WaistCoatWaist = get.WaistCoatWaist,
                TrouserLenght = get.TrouserLenght,
                TrouserWaist = get.TrouserWaist,
                TrouserTight = get.TrouserTight,
                TrouserKnee = get.TrouserKnee,
                NativeLenght = get.NativeLenght,
                NativeShoulder = get.NativeShoulder,
                NativeSleeve = get.NativeSleeve,
                NativeWaist = get.NativeWaist,
                NativeTrouserKnee = get.NativeTrouserKnee,
                NativeTrouserLenght = get.NativeTrouserLenght,
                NativeTrouserTight = get.NativeTrouserTight,
                NativeCap = get.NativeCap,
                KneekerLenght = get.KneekerLenght,
                KneekerTight = get.KneekerTight,
                KneekerWaist = get.KneekerWaist,
                AgbadaLenght = get.AgbadaLenght,
            });
            return new BaseResponse<IEnumerable<OrderMeasurementDto>>
            {
                Status = true,
                Message = "success",
                Data = getAllOrderMeasurement
            };
        }

        public async Task<BaseResponse<OrderMeasurementDto>> GetMeasurementNameOrderByCustomerId(int id, OrderMeasurementDto name)
        {
            var getCustomer = await _customerRepository.GetAsync(x => x.UserId == id);
            if (getCustomer == null) return new BaseResponse<OrderMeasurementDto> { Message = "anounymous user", Status = false };
            if(name.TrouserLenght != null)
            {

            }
            var get = await _orderMeasurementRepository.GetAsync(x => x.CustomerId == getCustomer.Id);
            if (get == null) return new BaseResponse<OrderMeasurementDto> { Message = "failed", Status = false };
            return new BaseResponse<OrderMeasurementDto>
            {
                Status = true,
                Message = "success",
            };
        }

        public async Task<BaseResponse<OrderMeasurementDto>> GetMeasurementOrderByCustomerId(int id)
        {
            var get = await _orderMeasurementRepository.GetAsync(x => x.CustomerId == id);
            if (get == null) return new BaseResponse<OrderMeasurementDto> { Message = "failed", Status = false };
            return new BaseResponse<OrderMeasurementDto>
            {
                Status = true,
                Message = "success",
                Data = new OrderMeasurementDto
                {
                    Id = get.Id,
                    SuitLenght = get.SuitLenght,
                    SuitChest = get.SuitChest,
                    SuitShoulder = get.SuitShoulder,
                    SuitSleeve = get.SuitSleeve,
                    SuitWaist = get.SuitWaist,
                    ShirtLenght = get.ShirtLenght,
                    ShirtWaist = get.ShirtWaist,
                    ShirtShoulder = get.ShirtShoulder,
                    ShirtSleeve = get.ShirtSleeve,
                    WaistCoatLenght = get.WaistCoatLenght,
                    WaistCoatWaist = get.WaistCoatWaist,
                    TrouserLenght = get.TrouserLenght,
                    TrouserWaist = get.TrouserWaist,
                    TrouserTight = get.TrouserTight,
                    TrouserKnee = get.TrouserKnee,
                    NativeLenght = get.NativeLenght,
                    NativeShoulder = get.NativeShoulder,
                    NativeSleeve = get.NativeSleeve,
                    NativeWaist = get.NativeWaist,
                    NativeTrouserKnee = get.NativeTrouserKnee,
                    NativeTrouserLenght = get.NativeTrouserLenght,
                    NativeTrouserTight = get.NativeTrouserTight,
                    NativeCap = get.NativeCap,
                    KneekerLenght = get.KneekerLenght,
                    KneekerTight = get.KneekerTight,
                    KneekerWaist = get.KneekerWaist,
                    AgbadaLenght = get.AgbadaLenght,
                }
            };
        }
        
        public async Task<BaseResponse<OrderMeasurementDto>> GetMeasuremenvalueByCustomerId(int id, string name)
        {
            var getCustomer = await _customerRepository.GetAsync(x => x.UserId == id);
            var getmeasure = await _orderMeasurementRepository.GetAsync(x => x.CustomerId == getCustomer.Id);
            if (getmeasure == null)
            {
                return new BaseResponse<OrderMeasurementDto> { Status = false, Message = "NoMeasurement" };
            }
            var measurement = getmeasure.GetType().GetProperty(name).GetValue(getmeasure); 
            if(measurement == null)
            {
                return new BaseResponse<OrderMeasurementDto> { Status = false ,Message = "NotExist"};
            }
            return new BaseResponse<OrderMeasurementDto> { Status = true ,Message = "Exist"};
        }
    }
}
