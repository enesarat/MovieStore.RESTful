using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public List<MovieViewModel> Handle()
        {
            var movies = _context.Movies.Include(x => x.Director).OrderBy(x => x.Id).ToList<Movie>();
            List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movies);
            return vm;
        }

        public class MovieViewModel
        {
            public string Title { get; set; }
            public string Director { get; set; }
        }
    }
}
