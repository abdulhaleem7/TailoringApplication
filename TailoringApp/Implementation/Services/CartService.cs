using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class CartService: ICartService
    {
        public readonly ICartRepository _cartRepository;
        public readonly ICustomerRepository _customerRepository;
        public readonly IOrderRepository _orderRepository;
        public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public async Task<BaseResponse<CartDto>> Create(CartRequestModel model)
        {

            var getcustomer = await _customerRepository.GetAsync(x => x.User.Id == model.CustomerId);
            var getCustomerCart = await _cartRepository.GetAsync(x => x.CustomerId == getcustomer.Id && x.IsDeleted == false);
            if (getCustomerCart != null) return new BaseResponse<CartDto> { Message = "exist", Status = false };
            var cart = new Cart
            {
                CustomerId = model.CustomerId,
                CartStatus = Enum.Cartstatus.Active,
            };
            await _cartRepository.Create(cart);
            return new BaseResponse<CartDto>
            {
                Status = true,
            };
        }

        public Task<BaseResponse<CartDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetAll()
        {
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.NotActive);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach(var  g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll =  new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                };
                items.Add(getAll);
            }
            
            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };
        }
        private async Task<int> GetOrderByCart(int cartId)
        {
            var items = await _orderRepository.GetSelectedAsync(x => x.CartId == cartId);
            return items.Count;
        }
        public async Task<BaseResponse<CartDto>> GetCartByCustomerId(int id)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == id);
            var getCart = await _cartRepository.GetAsync(x => x.CustomerId == getUser.Id && x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.Active);
            if (getCart == null) return new BaseResponse<CartDto> { Status = false };
            return new BaseResponse<CartDto> { Status = true, Data = new CartDto { Id = getCart.Id, CustomerId = getCart.CustomerId,TotalAmount =getCart.TotalAmount } };
        }

        public async Task<BaseResponse<CartDto>> UpdateCart(int id)
        {
            var get = await _cartRepository.GetAsync(x => x.Id == id && x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.Active);
            if (get == null) return new BaseResponse<CartDto> { Message = "failed", Status = false };
            await _cartRepository.Update(get);
            return new BaseResponse<CartDto>
            {
                Status = true,
            };
        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetProccessingCart()
        {
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.working);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId,

                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };
        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetCompletedCart()
        {
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.done);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId
                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };
        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetAllCartByCustomerId(int id)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == id);
            var get = await _cartRepository.GetSelectedAsync( x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.NotActive && x.CustomerId == getUser.Id);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId,
                    
                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };

        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetAllProccessingCartCustomerId(int id)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == id);
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.working && x.CustomerId == getUser.Id);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId,
                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };

        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetAllCompletedCartByCustomerId(int id)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == id);
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.done && x.CustomerId == getUser.Id);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId,
                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };

        }

        public async Task<BaseResponse<IEnumerable<CartDto>>> GetAllReceivedCartByCustomer(int id)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == id);
            var get = await _cartRepository.GetSelectedAsync(x => x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.delivered && x.CustomerId == getUser.Id);
            if (get == null) return new BaseResponse<IEnumerable<CartDto>> { Message = "EmptyOrders", Status = false };
            List<CartDto> items = new List<CartDto>();
            foreach (var g in get)
            {
                int c = await GetOrderByCart(g.Id);
                var getAll = new CartDto
                {
                    Id = g.Id,
                    CustomerName = g.Customer.FirstName,
                    SendDeliveryDate = g.DeliveryDate.ToShortDateString(),
                    Count = c,
                    CustomerId = g.CustomerId,
                };
                items.Add(getAll);
            }

            return new BaseResponse<IEnumerable<CartDto>>
            {
                Status = true,
                Data = items,
                Message = "Success"
            };

        }
    }
}
