using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;

        public int DirectorId { get; set; }
        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Handle()
        {
            var Director = _context.Directors.SingleOrDefault(x => x.Id == DirectorId);

            if (Director == null)
            {
                throw new InvalidOperationException($"Director with id: {DirectorId} not exists!");
            }

            _context.Directors.Remove(Director);
            _context.SaveChanges();
        }
    }
}
