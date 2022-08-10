using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TailoringApp.Interface.IService;

namespace TailoringApp.Controllers
{

    public class OrderMeasurement : ControllerBase
    {
        private readonly IOrderMeasurementService _orderMeasurementService;
        public OrderMeasurement(IOrderMeasurementService orderMeasurementService)
        {
            _orderMeasurementService = orderMeasurementService;
        }

        [HttpGet("GetMeasuremenvalueByCustomerId/{id}/{name}")]
        public async Task<IActionResult> GetMeasuremenvalueByCustomerId([FromRoute]int id, [FromRoute]string name)
        {
            var get = await _orderMeasurementService.GetMeasuremenvalueByCustomerId(id, name);
            if(get.Status == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }
        [HttpGet("GetMeasurementOrderByCustomerId/{id}")]
        public async Task<IActionResult> GetMeasurementOrderByCustomerId([FromRoute] int id)
        {
            var get = await _orderMeasurementService.GetMeasurementOrderByCustomerId(id);
            if (get.Status == false)
            {
                return BadRequest(get);
            }
            return Ok(get);
        }
    }
}
