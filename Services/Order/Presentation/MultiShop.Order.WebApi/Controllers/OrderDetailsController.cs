using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailQueryHandler _removeOrderDetailQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler, 
            RemoveOrderDetailQueryHandler removeOrderDetailQueryHandler, 
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailQueryHandler = removeOrderDetailQueryHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Order Detail information added");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Order Detail information updated");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailQueryHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Order Detail information deleted");
        }
    }
}
