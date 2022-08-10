using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OrderController(IOrderService orderService, IWebHostEnvironment webHostEnvironment)
        {
            _orderService = orderService;
            _webHostEnvironment = webHostEnvironment;
        }
        
        [HttpPost("CreateOrderForItem/{id}")]
        public async Task<IActionResult> CreateOrderForItem([FromForm]OrderRequestModel model,[FromRoute]int id)
        {

            var files = HttpContext.Request.Form;
            if (files != null && files.Count > 0)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "Design");
                Directory.CreateDirectory(imageDirectory);
                foreach (var file in files.Files)
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    string Design = Guid.NewGuid().ToString() + fi.Extension;
                    string path = Path.Combine(imageDirectory, Design);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    model.CustomerDesign = Design;
                }
            }

            var order = await _orderService.Create(model,id);
            if(order.Status == false)
            {
                return BadRequest(order);
            }

            return Ok(order);
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var order = await _orderService.GetAll();
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }

        [HttpGet("GetOrderByCartId/{id}")]
        public async Task<IActionResult> GetOrderByCartId(int id)
        {
            var order = await _orderService.GetOrderByCartId(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }

        [HttpGet("GetOrderDetails/{id}")]
        public async Task<IActionResult> GetOrderDetails([FromRoute] int id)
        {
            var order = await _orderService.Get(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }

        [HttpPost("UpdateOrdersInCartTOProccessing/{id}")]
        public async Task<IActionResult> UpdateOrdersInCartTOProccessing([FromRoute] int id)
        {
            var order = await _orderService.UpdateOrdersInCartTOProccessing(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpPost("DeleteOrdersInCart/{id}")]
        public async Task<IActionResult> DeleteOrdersInCart([FromRoute] int id)
        {
            var order = await _orderService.DeleteOrdersInCart(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpGet("OrderByCustomer/{id}")]
        public async Task<IActionResult> GetOrderByCustomerId([FromRoute]int id)
        {
           
            var order = await _orderService.GetOrderByCustomerId(id);
            if(order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }

        [HttpGet("GetAllItemsInCartByCustomerId/{id}")]
        public async Task<IActionResult> GetAllItemsInCartByCustomerId([FromRoute] int id)
        {

            var order = await _orderService.GetAllItemsInCartByCustomerId(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpGet("GetProccessingOrderByCartId/{id}")]
        public async Task<IActionResult> GetProccessingOrderByCartId(int id)
        {
            var order = await _orderService.GetProccessingOrderByCartId(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpGet("GetCompletedOrderByCartId/{id}")]
        public async Task<IActionResult> GetCompletedOrderByCartId(int id)
        {
            var order = await _orderService.GetCompletedOrderByCartId(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpPost("UpdateOrdersInCartTOCompleted/{id}")]
        public async Task<IActionResult> UpdateOrdersInCartTOCompleted([FromRoute] int id)
        {
            var order = await _orderService.UpdateOrdersInCartTOCompleted(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpPost("UpdateOrdersInCartTOCollected/{id}")]
        public async Task<IActionResult> UpdateOrdersInCartTOCollected([FromRoute] int id)
        {
            var order = await _orderService.UpdateOrdersInCartTOCollected(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
        [HttpGet("GetHistoryOrderByCartId/{id}")]
        public async Task<IActionResult> GetHistoryOrderByCartId([FromRoute] int id)
        {
            var order = await _orderService.GetHistoryOrderByCartId(id);
            if (order.Status == false)
            {
                return BadRequest(order);
            }
            return Ok(order);
        }
    }

}
