using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.UpdateOrder
{
    public class UpdateOrderCommand
    {
        public UpdateOrderModel Model { get; set; }
        public int OrderId;


        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public UpdateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            Customer customer = _context.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            Movie movies = _context.Movies.SingleOrDefault(s => s.Id == Model.MovieId);

            Order order = _context.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (customer is null)
                throw new InvalidOperationException("Customer with given id is not exists!");
            else if (movies is null)
                throw new InvalidOperationException("Movie with given id is not exists!");
            else if (order is null)
                throw new InvalidOperationException("Order with given id is not exists!");

            _mapper.Map<UpdateOrderModel, Order>(Model, order);

            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public class UpdateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }

        }
    }
}
