using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("GetCartByCustomerId/{id}")]
        public async Task<IActionResult> GetCartByCustomerId([FromRoute] int id)
        {
            var cart = await _cartService.GetCartByCustomerId(id);
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }


        [HttpGet("GetAllCart")]
        public async Task<IActionResult> GetAllI()
        {
            var cart = await _cartService.GetAll();
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }

        [HttpGet("GetProccessingCart")]
        public async Task<IActionResult> GetProccessingCart()
        {
            var cart = await _cartService.GetProccessingCart();
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }
        [HttpGet("GetCompletedCart")]
        public async Task<IActionResult> GetCompletedCart()
        {
            var cart = await _cartService.GetCompletedCart();
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }
        [HttpGet("GetAllCartByCustomerId/{id}")]
        public async Task<IActionResult> GetAllCartByCustomerId([FromRoute]int id)
        {
            var cart = await _cartService.GetAllCartByCustomerId(id);
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }
        [HttpGet("GetAllProccessingCartCustomerId/{id}")]
        public async Task<IActionResult> GetAllProccessingCartCustomerId([FromRoute]int id)
        {
            var cart = await _cartService.GetAllProccessingCartCustomerId(id);
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }
        [HttpGet("GetAllCompletedCartByCustomerId/{id}")]
        public async Task<IActionResult> GetAllCompletedCartByCustomerId([FromRoute]int id)
        {
            var cart = await _cartService.GetAllCompletedCartByCustomerId(id);
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }

        [HttpGet("GetAllReceivedCartByCustomer/{id}")]
        public async Task<IActionResult> GetAllReceivedCartByCustomer([FromRoute] int id)
        {
            var cart = await _cartService.GetAllReceivedCartByCustomer(id);
            if (cart.Status == false)
            {
                return BadRequest(cart);
            }
            return Ok(cart);
        }
    }
}
