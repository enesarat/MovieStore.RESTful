using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public UpdateMovieViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public UpdateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
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

            _mapper.Map(Model, movie);
            _context.SaveChanges();
        }

        public class UpdateMovieViewModel
        {
            public string Title { get; set; }
            public int DirectorId { get; set; }
            public int GenreId { get; set; }
            public double Price { get; set; }
        }
    }
}
