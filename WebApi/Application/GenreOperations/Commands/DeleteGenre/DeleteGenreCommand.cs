using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }

        private readonly IMovieStoreDbContext _context;
        public DeleteGenreCommand(IMovieStoreDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException($"Genre with id: {GenreId} not exists!");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
