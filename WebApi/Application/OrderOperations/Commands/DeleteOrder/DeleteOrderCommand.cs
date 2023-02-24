using WebApi.DbOperations;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        public int OrderId;


        private readonly IMovieStoreDbContext _context;

        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(s => s.Id == OrderId);

            if (order is null)
                throw new InvalidOperationException($"Order with id: {OrderId} not exists!");

            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
