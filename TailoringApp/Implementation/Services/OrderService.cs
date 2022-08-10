using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderMeasurementRepository _orderMeasurementRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IDesignRepository _designRepository;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IOrderMeasurementRepository orderMeasurementRepository,IDesignRepository designRepository,ICartRepository cartRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _orderMeasurementRepository = orderMeasurementRepository;
            _designRepository = designRepository;
            _cartRepository = cartRepository;
        }
        public async Task<BaseResponse<OrderDto>> Create(OrderRequestModel model,int UserId)
        {
            var getUser = await _customerRepository.GetAsync(x => x.User.Id == UserId);
            var getMeasurement = await _orderMeasurementRepository.GetAsync(x => x.Customer.Id == getUser.Id);
            var getCartByCustomerId = await _cartRepository.GetAsync(x => x.CustomerId == getUser.Id && x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.Active);
            if (getUser == null) return new BaseResponse<OrderDto>
            {
                Message = "Unrecognize user.",
                Status = false,
            };
            if (getMeasurement == null)
            {
                if (getCartByCustomerId == null)
                {
                    var cart = new Cart
                    {
                        CustomerId = getUser.Id,
                        CartStatus = Enum.Cartstatus.Active,
                    };
                    var createCart = await _cartRepository.Create(cart);
                    var measurements = new OrderMeasurement
                    {

                        CustomerId = getUser.Id,
                        SuitLenght = model.SuitLenght,
                        SuitChest = model.SuitChest,
                        SuitShoulder = model.SuitShoulder,
                        SuitSleeve = model.SuitSleeve,
                        SuitWaist = model.SuitWaist,
                        ShirtLenght = model.ShirtLenght,
                        ShirtWaist = model.ShirtWaist,
                        ShirtShoulder = model.ShirtShoulder,
                        ShirtSleeve = model.ShirtSleeve,
                        WaistCoatLenght = model.WaistCoatLenght,
                        WaistCoatWaist = model.WaistCoatWaist,
                        TrouserLenght = model.TrouserLenght,
                        TrouserWaist = model.TrouserWaist,
                        TrouserTight = model.TrouserTight,
                        TrouserKnee = model.TrouserKnee,
                        NativeLenght = model.NativeLenght,
                        NativeShoulder = model.NativeShoulder,
                        NativeSleeve = model.NativeSleeve,
                        NativeWaist = model.NativeWaist,
                        NativeTrouserKnee = model.NativeTrouserKnee,
                        NativeTrouserLenght = model.NativeTrouserLenght,
                        NativeTrouserTight = model.NativeTrouserTight,
                        NativeCap = model.NativeCap,
                        KneekerLenght = model.KneekerLenght,
                        KneekerTight = model.KneekerTight,
                        KneekerWaist = model.KneekerWaist,
                        AgbadaLenght = model.AgbadaLenght,
                    };
                    var orders = new Order
                    {
                        CartId = createCart.Id,
                        CustomerId = getUser.Id,
                        ColourId = model.ColourId,
                        Quantity = model.Quantity,
                        DesignId = model.DesignId,
                        Description = model.Description,
                        CustomerDesign = model.CustomerDesign,
                        OrderStatus = Enum.OrderStatus.Initial,
                    };
                    
                    await _orderMeasurementRepository.Create(measurements);
                    var creates = await _orderRepository.Create(orders);
                    var get1 = await _designRepository.GetAsync(x => x.Id == orders.DesignId);
                    createCart.TotalAmount = get1.Cloth.Price * creates.Quantity;
                    await _cartRepository.Update(createCart);
                    return new BaseResponse<OrderDto>
                    {
                        Data = new OrderDto
                        {
                            Id = creates.Id,
                            CustomerId = creates.CustomerId,
                            Quantity = creates.Quantity,
                        },
                        Status = true,
                        Message = "successful"
                    };
                }

                var measurement = new OrderMeasurement
                {
                    CustomerId = getUser.Id,
                    SuitLenght = model.SuitLenght,
                    SuitChest = model.SuitChest,
                    SuitShoulder = model.SuitShoulder,
                    SuitSleeve = model.SuitSleeve,
                    SuitWaist = model.SuitWaist,
                    ShirtLenght = model.ShirtLenght,
                    ShirtWaist = model.ShirtWaist,
                    ShirtShoulder = model.ShirtShoulder,
                    ShirtSleeve = model.ShirtSleeve,
                    WaistCoatLenght = model.WaistCoatLenght,
                    WaistCoatWaist = model.WaistCoatWaist,
                    TrouserLenght = model.TrouserLenght,
                    TrouserWaist = model.TrouserWaist,
                    TrouserTight = model.TrouserTight,
                    TrouserKnee = model.TrouserKnee,
                    NativeLenght = model.NativeLenght,
                    NativeShoulder = model.NativeShoulder,
                    NativeSleeve = model.NativeSleeve,
                    NativeWaist = model.NativeWaist,
                    NativeTrouserKnee = model.NativeTrouserKnee,
                    NativeTrouserLenght = model.NativeTrouserLenght,
                    NativeTrouserTight = model.NativeTrouserTight,
                    NativeCap = model.NativeCap,
                    KneekerLenght = model.KneekerLenght,
                    KneekerTight = model.KneekerTight,
                    KneekerWaist = model.KneekerWaist,
                    AgbadaLenght = model.AgbadaLenght,
                };
                var order = new Order
                {
                    CartId = getCartByCustomerId.Id,
                    CustomerId = getUser.Id,
                    ColourId = model.ColourId,
                    Quantity = model.Quantity,
                    DesignId = model.DesignId,
                    CustomerDesign = model.CustomerDesign,
                    OrderStatus = Enum.OrderStatus.Initial,
                    Description = model.Description
                };
                await _orderMeasurementRepository.Create(measurement);
                var create = await _orderRepository.Create(order);
                var get = await _designRepository.GetAsync(x => x.Id == order.DesignId);
                getCartByCustomerId.TotalAmount += get.Cloth.Price * create.Quantity;
                await _cartRepository.Update(getCartByCustomerId);
                return new BaseResponse<OrderDto>
                {
                    Data = new OrderDto
                    {
                        Id = create.Id,
                        CustomerId = create.CustomerId,
                        Quantity = create.Quantity,
                    },
                    Status = true,
                    Message = "successfull"
                    
                };

            }
            else
            {
                if (getCartByCustomerId == null)
                {
                    var cart = new Cart
                    {
                        CustomerId = getUser.Id,
                        CartStatus = Enum.Cartstatus.Active,
                    };
                    var createCart = await _cartRepository.Create(cart);
                    getMeasurement.SuitLenght = model.SuitLenght ?? getMeasurement.SuitLenght;
                    getMeasurement.SuitChest = model.SuitChest ?? getMeasurement.SuitChest;
                    getMeasurement.SuitShoulder = model.SuitShoulder ?? getMeasurement.SuitShoulder;
                    getMeasurement.SuitSleeve = model.SuitSleeve ?? getMeasurement.SuitSleeve;
                    getMeasurement.SuitWaist = model.SuitWaist ?? getMeasurement.SuitWaist;
                    getMeasurement.ShirtLenght = model.ShirtLenght ?? getMeasurement.ShirtLenght;
                    getMeasurement.ShirtWaist = model.ShirtWaist ?? getMeasurement.ShirtWaist;
                    getMeasurement.ShirtShoulder = model.ShirtShoulder ?? getMeasurement.ShirtShoulder;
                    getMeasurement.ShirtSleeve = model.ShirtSleeve ?? getMeasurement.ShirtSleeve;
                    getMeasurement.WaistCoatLenght = model.WaistCoatLenght ?? getMeasurement.WaistCoatLenght;
                    getMeasurement.WaistCoatWaist = model.WaistCoatWaist ?? getMeasurement.WaistCoatWaist;
                    getMeasurement.TrouserLenght = model.TrouserLenght ?? getMeasurement.TrouserLenght;
                    getMeasurement.TrouserWaist = model.TrouserWaist ?? getMeasurement.TrouserWaist;
                    getMeasurement.TrouserTight = model.TrouserTight ?? getMeasurement.TrouserTight;
                    getMeasurement.TrouserKnee = model.TrouserKnee ?? getMeasurement.TrouserKnee;
                    getMeasurement.NativeLenght = model.NativeLenght ?? getMeasurement.NativeLenght;
                    getMeasurement.NativeShoulder = model.NativeShoulder ?? getMeasurement.NativeShoulder;
                    getMeasurement.NativeSleeve = model.NativeSleeve ?? getMeasurement.NativeSleeve;
                    getMeasurement.NativeWaist = model.NativeWaist ?? getMeasurement.NativeWaist;
                    getMeasurement.NativeTrouserKnee = model.NativeTrouserKnee ?? getMeasurement.NativeTrouserKnee;
                    getMeasurement.NativeTrouserLenght = model.NativeTrouserLenght ?? getMeasurement.NativeTrouserLenght;
                    getMeasurement.NativeTrouserTight = model.NativeTrouserTight ?? getMeasurement.NativeTrouserTight;
                    getMeasurement.NativeCap = model.NativeCap ?? getMeasurement.NativeCap;
                    getMeasurement.KneekerLenght = model.KneekerLenght ?? getMeasurement.KneekerLenght;
                    getMeasurement.KneekerTight = model.KneekerTight ?? getMeasurement.KneekerTight;
                    getMeasurement.KneekerWaist = model.KneekerWaist ?? getMeasurement.KneekerWaist;
                    getMeasurement.AgbadaLenght = model.AgbadaLenght ?? getMeasurement.AgbadaLenght;
                    var order1 = new Order
                    {
                        CartId = createCart.Id,
                        CustomerId = getUser.Id,
                        ColourId = model.ColourId,
                        Quantity = model.Quantity,
                        DesignId = model.DesignId,
                        CustomerDesign = model.CustomerDesign,
                        OrderStatus = Enum.OrderStatus.Initial,
                        Description = model.Description
                    };
                    await _orderMeasurementRepository.Update(getMeasurement);
                    var create1 = await _orderRepository.Create(order1);
                    var get1 = await _designRepository.GetAsync(x => x.Id == order1.DesignId);
                    createCart.TotalAmount += get1.Cloth.Price * create1.Quantity;
                    await _cartRepository.Update(createCart);
                    return new BaseResponse<OrderDto>
                    {
                        Data = new OrderDto
                        {
                            Id = create1.Id,
                            CustomerId = create1.CustomerId,
                            Quantity = create1.Quantity,
                        },
                        Message = "success",
                        Status = true
                    };
                }
            
                getMeasurement.SuitLenght = model.SuitLenght ?? getMeasurement.SuitLenght;
                getMeasurement.SuitChest = model.SuitChest ?? getMeasurement.SuitChest;
                getMeasurement.SuitShoulder = model.SuitShoulder ?? getMeasurement.SuitShoulder;
                getMeasurement.SuitSleeve = model.SuitSleeve ?? getMeasurement.SuitSleeve;
                getMeasurement.SuitWaist = model.SuitWaist ?? getMeasurement.SuitWaist;
                getMeasurement.ShirtLenght = model.ShirtLenght?? getMeasurement.ShirtLenght;
                getMeasurement.ShirtWaist = model.ShirtWaist ?? getMeasurement.ShirtWaist;
                getMeasurement.ShirtShoulder = model.ShirtShoulder ?? getMeasurement.ShirtShoulder;
                getMeasurement.ShirtSleeve = model.ShirtSleeve ?? getMeasurement.ShirtSleeve;
                getMeasurement.WaistCoatLenght = model.WaistCoatLenght ?? getMeasurement.WaistCoatLenght;
                getMeasurement.WaistCoatWaist = model.WaistCoatWaist ?? getMeasurement.WaistCoatWaist;
                getMeasurement.TrouserLenght = model.TrouserLenght ?? getMeasurement.TrouserLenght;
                getMeasurement.TrouserWaist = model.TrouserWaist ?? getMeasurement.TrouserWaist;
                getMeasurement.TrouserTight = model.TrouserTight ?? getMeasurement.TrouserTight;
                getMeasurement.TrouserKnee = model.TrouserKnee ?? getMeasurement.TrouserKnee;
                getMeasurement.NativeLenght = model.NativeLenght ?? getMeasurement.NativeLenght;
                getMeasurement.NativeShoulder = model.NativeShoulder ?? getMeasurement.NativeShoulder;
                getMeasurement.NativeSleeve = model.NativeSleeve ?? getMeasurement.NativeSleeve;
                getMeasurement.NativeWaist = model.NativeWaist ?? getMeasurement.NativeWaist;
                getMeasurement.NativeTrouserKnee = model.NativeTrouserKnee ?? getMeasurement.NativeTrouserKnee;
                getMeasurement.NativeTrouserLenght = model.NativeTrouserLenght ?? getMeasurement.NativeTrouserLenght;
                getMeasurement.NativeTrouserTight = model.NativeTrouserTight ?? getMeasurement.NativeTrouserTight;
                getMeasurement.NativeCap = model.NativeCap ?? getMeasurement.NativeCap;
                getMeasurement.KneekerLenght = model.KneekerLenght ?? getMeasurement.KneekerLenght;
                getMeasurement.KneekerTight = model.KneekerTight ?? getMeasurement.KneekerTight;
                getMeasurement.KneekerWaist = model.KneekerWaist ?? getMeasurement.KneekerWaist;
                getMeasurement.AgbadaLenght = model.AgbadaLenght ?? getMeasurement.AgbadaLenght;
                var order = new Order
                {
                    CartId = getCartByCustomerId.Id,
                    CustomerId = getUser.Id,
                    ColourId = model.ColourId,
                    Quantity = model.Quantity,
                    DesignId = model.DesignId,
                    CustomerDesign = model.CustomerDesign,
                    OrderStatus = Enum.OrderStatus.Initial,
                    Description = model.Description,
                };
                await _orderMeasurementRepository.Update(getMeasurement);
                var create = await _orderRepository.Create(order);
                var get = await _designRepository.GetAsync(x => x.Id == order.DesignId);
                getCartByCustomerId.TotalAmount += get.Cloth.Price * create.Quantity;
                await _cartRepository.Update(getCartByCustomerId);
                return new BaseResponse<OrderDto>
                {
                    Data = new OrderDto
                    {
                        Id = create.Id,
                        CustomerId = create.CustomerId,
                        Quantity = create.Quantity,
                    },Message="success",Status = true
                };
            }
            
        }

        public async Task<BaseResponse<OrderDto>> DeleteOrdersInCart(int id)
        {
            var getOrders = await _orderRepository.GetAsync(x => x.Id == id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.Initial);
            getOrders.IsDeleted = true;

            await _orderRepository.Update(getOrders);
            
            
            return new BaseResponse<OrderDto>
            {
                Status = true,
                Message = "removed",
            };
        }
        public async Task<BaseResponse<OrderDto>> ReduceQuantity(int id)
        {
            var getOrders = await _orderRepository.GetAsync(x => x.Id == id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.Initial);
            getOrders.IsDeleted = true;
            await _orderRepository.Update(getOrders);

            return new BaseResponse<OrderDto>
            {
                Status = true,
                Message = "removed",
            };
        }
        public async Task<BaseResponse<OrderDto>> Get(int id)
        {
            var get = await _orderRepository.GetAsync(id);
            if (get == null) return new BaseResponse<OrderDto>
            {
                Message = "failed",
                Status = false,
            };
            return new BaseResponse<OrderDto>
            {
                Data = new OrderDto
                {
                    Id = get.Id,
                    CustomerId = get.CustomerId,
                    Quantity = get.Quantity,
                    CustomerDesign = get.CustomerDesign,
                    Description = get.Description,
                },
                Status = true,
                Message = "success",
            };

        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetAll()
        {
            var getAll = await _orderRepository.GetAllAsync();
            if(getAll == null) return new BaseResponse<IEnumerable<OrderDto>> { Message="failed",Status=false };
            var listOfOrder = getAll.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                ColourId = x.ColourId,
                CustomerId = x.CustomerId,
                Description = x.Description,
               
            });
            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = listOfOrder,
                Status = true,
                Message = "success"
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetAllItemsInCartByCustomerId(int cartId)
        {

            var cart = await _cartRepository.GetAsync(x => x.Id == cartId && x.IsDeleted == false && x.CartStatus == Enum.Cartstatus.NotActive);
            var orders = await _orderRepository.GetSelectedAsync(x => x.CartId == cart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.paid);
            if (orders == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var getAll = orders.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                DesignName = _designRepository.Get(y => y.Id == x.DesignId).Name,
                Quantity = x.Quantity,
                DesignImage = x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                TotalPrice = _designRepository.Get(y => y.Id == x.DesignId).Cloth.Price * x.Quantity,
                ColourName = x.Colour.Name,
                DeliveryDae =cart.DeliveryDate.ToShortDateString(),
                CustomerId = x.CustomerId,
                Description = x.Description,
                DateDiff = (cart.DeliveryDate.Day-DateTime.Now.Day)
            });

            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = getAll,
                Message = "success",
                Status = true,
            };

        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetCompletedOrderByCartId(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.done && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.done);
            if (getOrders == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var getAll = getOrders.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                DesignName = _designRepository.Get(y => y.Id == x.DesignId).Name,
                Quantity = x.Quantity,
                DesignImage = x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                TotalPrice = _designRepository.Get(y => y.Id == x.DesignId).Cloth.Price * x.Quantity,
                DeliveryDae = getCart.DeliveryDate.ToShortDateString(),
                ColourName = x.Colour.Name,
                Description = x.Description,

                DateDiff = getCart.DeliveryDate.Day - DateTime.Now.Day 
            });

            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = getAll,
                Message = "success",
                Status = true,
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetHistoryOrderByCartId(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.delivered && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.delivered);
            if (getOrders == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var getAll = getOrders.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                DesignName = _designRepository.Get(y => y.Id == x.DesignId).Name,
                Quantity = x.Quantity,
                DesignImage = x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                TotalPrice = _designRepository.Get(y => y.Id == x.DesignId).Cloth.Price * x.Quantity,
                DeliveryDae = getCart.DeliveryDate.ToShortDateString(),
                ColourName = x.Colour.Name,
                Description = x.Description,

                DateDiff = getCart.DeliveryDate.Day - DateTime.Now.Day
            });

            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = getAll,
                Message = "success",
                Status = true,
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderByCartId(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.NotActive && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.paid);
            if (getOrders == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var getAll = getOrders.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                DesignName = _designRepository.Get(y => y.Id == x.DesignId).Name,
                Quantity = x.Quantity,
                DesignImage = x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                TotalPrice = _designRepository.Get(y => y.Id == x.DesignId).Cloth.Price * x.Quantity,
                DeliveryDae = getCart.DeliveryDate.ToShortDateString(),
                ColourName = x.Colour.Name,
                Description = x.Description,

                DateDiff = getCart.DeliveryDate.Day - DateTime.Now.Day
            });
            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = getAll,
                Message = "success",
                Status = true,
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetOrderByCustomerId(int id)
        {
            var getCustomer = await _customerRepository.GetAsync(x => x.User.Id == id);
            var getAll = await _orderRepository.GetSelectedAsync(x => x.CustomerId == getCustomer.Id && x.OrderStatus == Enum.OrderStatus.Initial && x.IsDeleted == false);
            if (getAll == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var listOfOrder = getAll.ToList().Select( x => new OrderDto
            {
                Id = x.Id,
                Quantity = x.Quantity,
                ColourId = x.ColourId,
                CustomerId = x.CustomerId,
                TotalPrice =  _designRepository.Get(y=>y.Id == x.DesignId).Cloth.Price * x.Quantity,
                DesignImage =   x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                DesignName = _designRepository.Get(y=>y.Id == x.DesignId).Name,
                Price = _designRepository.Get(y=>y.Id == x.DesignId).Cloth.Price,
                CartId = x.CartId,
                
            });
            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = listOfOrder,
                Status = true,
                Message = "success"
            };
        }

        public async Task<BaseResponse<IEnumerable<OrderDto>>> GetProccessingOrderByCartId(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.working && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.working);
            if (getOrders == null) return new BaseResponse<IEnumerable<OrderDto>> { Message = "failed", Status = false };
            var getAll = getOrders.ToList().Select(x => new OrderDto
            {
                Id = x.Id,
                DesignName = _designRepository.Get(y => y.Id == x.DesignId).Name,
                Quantity = x.Quantity,
                DesignImage = x.CustomerDesign ?? _designRepository.Get(y => y.Id == x.DesignId).Picture,
                TotalPrice = _designRepository.Get(y => y.Id == x.DesignId).Cloth.Price * x.Quantity,
                DeliveryDae = getCart.DeliveryDate.ToShortDateString(),
                ColourName = x.Colour.Name,
                DateDiff = getCart.DeliveryDate.Day - DateTime.Now.Day
            });

            return new BaseResponse<IEnumerable<OrderDto>>
            {
                Data = getAll,
                Message = "success",
                Status = true,
            };
        }

        public async Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOCollected(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.done && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.done);
            foreach (var item in getOrders)
            {
                item.OrderStatus = Enum.OrderStatus.delivered;
                await _orderRepository.Update(item);
            }
            getCart.CartStatus = Enum.Cartstatus.delivered;
            await _cartRepository.Update(getCart);
            return new BaseResponse<OrderDto>
            {
                Status = true,
                Message = "Thanks for patronizing us......",
            };
        }

        public async Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOCompleted(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.working && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.working);
            foreach (var item in getOrders)
            {
                item.OrderStatus = Enum.OrderStatus.done;
                await _orderRepository.Update(item);

            }
            getCart.CartStatus = Enum.Cartstatus.done;
            await _cartRepository.Update(getCart);
            return new BaseResponse<OrderDto>
            {
                Status = true,
                Message = "Completed",
            };
        }

        public async Task<BaseResponse<OrderDto>> UpdateOrdersInCartTOProccessing(int cartId)
        {
            var getCart = await _cartRepository.GetAsync(x => x.Id == cartId && x.CartStatus == Enum.Cartstatus.NotActive && x.IsDeleted == false);
            var getOrders = await _orderRepository.GetSelectedAsync(x => x.CartId == getCart.Id && x.IsDeleted == false && x.OrderStatus == Enum.OrderStatus.paid);
            foreach (var item in getOrders)
            {
                item.OrderStatus = Enum.OrderStatus.working;
                await _orderRepository.Update(item);

            }
            getCart.CartStatus = Enum.Cartstatus.working;
            await _cartRepository.Update(getCart);
            return new BaseResponse<OrderDto>
            {
                Status = true,
                Message = "Started",
            };
        }
    }
}
