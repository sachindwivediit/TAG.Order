using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TAG.Order.Entities;
using TAG.Order.Repositoryy.Interface;

namespace TAG.Order.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<OrderDetails> _repository;

        public OrderController(IRepository<OrderDetails> repository)
        {
            _repository = repository;
        }

          // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDetails>> GetAllOrder()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<OrderDetails> GetOrder(int id)
        {
            return await _repository.GetById(id);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDetails orderDetails)
        {
            await _repository.Add(orderDetails);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] OrderDetails orderDetails, int id)
        {
            if (id > 0)
            {
                var resultOrder = await _repository.GetById(id);
                if (resultOrder != null)
                {
                    orderDetails.OrderNumber = orderDetails.OrderNumber;
                    orderDetails.ProductName = orderDetails.ProductName;
                    orderDetails.CreatedBy = orderDetails.CreatedBy;
                    orderDetails.CreatedDate = DateTime.Now;

                    await _repository.Update(resultOrder);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(OrderDetails orderDetails, int id)
        {
            if (id > 0)
            {
                var resultOrder = await _repository.GetById(id);
                if (resultOrder != null)
                {
                    await _repository.Delete(resultOrder);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}
