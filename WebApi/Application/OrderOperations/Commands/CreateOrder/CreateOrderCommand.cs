using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        public CreateOrderModel Model;

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(s => s.Id == Model.CustomerId);
            var movies = _context.Movies.SingleOrDefault(s => s.Id == Model.MovieId);

            if (customer is null)
                throw new InvalidOperationException("Customer could not found!");
            if (movies is null)
                throw new InvalidOperationException("Movie could not found!");


            var result = _mapper.Map<Order>(Model);
            result.PurchasedTime = DateTime.Now;

            _context.Orders.Add(result);
            _context.SaveChanges();
        }

        public class CreateOrderModel
        {
            public int MovieId { get; set; }
            public int CustomerId { get; set; }
            public DateTime TransactionTime { get; set; }
        }
    }
}
