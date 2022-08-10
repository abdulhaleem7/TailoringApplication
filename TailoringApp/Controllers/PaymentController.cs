using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost("Create/{id}")]
        public async Task<IActionResult> CreatePayment([FromRoute] int id)
        {
            var payment = await _paymentService.CreatePaymentAsync(id);
            if (payment.status == false)
            {
                return BadRequest(payment);
            }
            return Ok(payment);
        }
    }
}
