using AutoMapper;
using FdkElevator.DTOS.OrderDTO;
using FdkElevator.Models.Orders;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FdkElevator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder _order;
        private readonly IMapper _mapper;

        public OrderController(IOrder order, IMapper mapper)
        {
            _order = order;
            _mapper = mapper;
        }

        [HttpPost("addorder")]
        public ActionResult<string> PlaceOrder(CreateOrderDTO newOrder)
        {
            try
            {   
                var order = _mapper.Map<Order>(newOrder);
                order.ShippingAddress = _mapper.Map<ShippingAddress>(newOrder.ShippingAddress);
                order.OrderItems= _mapper.Map<List<OrderItem>>(newOrder.OrderItems);
                var result = _order.addOrder(order);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/{orderId}")]
        public async Task<ActionResult<OrderResponseDTO>> getOrder( Guid orderId)
        {
            try
            {
                var result = await _order.GetOrderById(orderId);
                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("orders/supplier/{supplierId}")]
        public async Task<ActionResult<OrderResponseDTO>> getOrderBySupplierId(Guid supplierId)
        {
            try
            {
                var result = await _order.GetOrdersBySupplierId(supplierId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orders/tenant/{tenantId}")]
        public async Task<ActionResult<OrderResponseDTO>> getOrderbyTenantId(Guid tenantId)
        {
            try
            {
                var result = await _order.GetOrdersByTenantId(tenantId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updatePayment")]

        public ActionResult<string> updatePaymentDetails(OrderPaymentDTO orD)
        {
            try
            {
                var result = _order.updatePayment(orD.OrderItemId, orD.PaymentImageURL);
                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
