using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DeleteMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie == null)
            {
                throw new InvalidOperationException($"Movie with id: {MovieId} not exists!");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
