using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Commands.UpdateOrder;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;
using static WebApi.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;
using static WebApi.Application.OrderOperations.Commands.UpdateOrder.UpdateOrderCommand;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        // Here, we retreive all order data from database context via GetAllOrders endpoint.
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            GetOrdersQuery query = new GetOrdersQuery(_dbContext, _mapper);
            var response = query.Handle();

            return Ok(response);
        }

        // Here, we retreive the order data according to given id info from database context via GetOrderById endpoint.
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_dbContext, _mapper);
            query.OrderId = id;

            GetOrderDetailQueryValidator validator = new GetOrderDetailQueryValidator();
            validator.ValidateAndThrow(query);

            var response = query.Handle();

            return Ok(response);
        }

        // Here, we create purchased movie data according to incoming order informations into database context via CreatePurchasedMovie endpoint.
        [HttpPost]
        public IActionResult CreatePurchasedMovie([FromBody] CreateOrderModel model)
        {
            CreateOrderCommand command = new CreateOrderCommand(_dbContext, _mapper);
            command.Model = model;

            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

        // Here, we update the order data according to related order informations which exist on Id to database context via UpdateOrder endpoint.
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] UpdateOrderModel updateorder)
        {
            UpdateOrderCommand command = new UpdateOrderCommand(_dbContext, null);
            command.OrderId = id;

            command.Model = updateorder;
            UpdateOrderCommandValidator validator = new UpdateOrderCommandValidator();

            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }

        // Here, we delete the order data according to given id info from database context via DeleteOrder endpoint.
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_dbContext);
            command.OrderId = id;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();

        }
    }
}
