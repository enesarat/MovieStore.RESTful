using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries.GetOrders
{
    public class GetOrdersQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrdersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OrderViewModel> Handle()
        {
            var orderlist = _context.Customers.Include(i => i.Orders).ThenInclude(t => t.Movie).Where(w => w.Orders.Any(a => a.IsActive)).OrderBy(x => x.Id).ToList<Customer>();
            List<OrderViewModel> vm = _mapper.Map<List<OrderViewModel>>(orderlist);
            return vm;


        }

       
        }
        public class OrderViewModel
        {
            public string NameSurname { get; set; }
            public IReadOnlyCollection<string> Movies { get; set; }
            public IReadOnlyCollection<string> Price { get; set; }
            public IReadOnlyCollection<string> PurchasedDate { get; set; }
        }
}
