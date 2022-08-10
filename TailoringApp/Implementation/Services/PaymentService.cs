using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Enum;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        public PaymentService(IPaymentRepository paymentRepository, IUserRepository userRepository, ICustomerRepository customerRepository, IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            _paymentRepository = paymentRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
        }

        public async Task<PayStackResponse> CreatePaymentAsync(int userId)
        {
            var getcustomer = await _customerRepository.GetAsync(x => x.User.Id == userId);
            var getcartById = await _cartRepository.GetAsync(x => x.CustomerId == getcustomer.Id && x.IsDeleted == false && x.CartStatus == Cartstatus.Active);
            var getOrderByCartId = await _orderRepository.GetSelectedAsync(x => x.CartId == getcartById.Id && x.IsDeleted == false);
            var payment = new Payment
            {
                CustomerID = getcustomer.Id,
                CartId = getcartById.Id,
                TotalPrice = getcartById.TotalAmount,
                PaymentStatus = PaymentStatus.NotPaid,
                OrderReference = Guid.NewGuid().ToString().Substring(1,5),
                CreatedOn = DateTime.UtcNow,
            };

            var create = await _paymentRepository.Create(payment);
            if (create == null)
            {
                return new PayStackResponse
                {
                    message = "failed",
                    status = false,
                };
            }
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri("https://api.paystack.co/transaction/initialize");
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "sk_test_d4b098a06448e96fb70ad3d8ea1e1fbe9d372cca");
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                amount = (payment.TotalPrice * 100) + (1000 * 100),
                email = getcustomer.User.Email,
                reference = create.OrderReference,
            }), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://api.paystack.co/transaction/initialize", content);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<PayStackResponse>(responseString);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                payment.PaymentStatus = PaymentStatus.Paid;
                await _paymentRepository.Update(payment);
                foreach (var item in getOrderByCartId)
                {
                    item.OrderStatus = OrderStatus.paid;
                    await _orderRepository.Update(item);
                }
                getcartById.CartStatus = Cartstatus.NotActive;
                getcartById.DeliveryDate = DateTime.Now.AddDays(10);
                await _cartRepository.Update(getcartById);
                if (responseObject.status == true)
                {
                    return new PayStackResponse()
                    {


                        status = true,
                        message = responseObject.message,
                        data = new PaystackData
                        {
                            authorization_url = responseObject.data.authorization_url,
                            reference = payment.OrderReference,
                        }


                    };

                }

            }

            return new PayStackResponse()
            {
                status = false,
                message = responseObject.message
            };

        }
    }
}
