using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(x => x.Director).Include(x => x.Genre).Include(x => x.ActorMovieJoint).ThenInclude(x => x.Actor).Where(x => x.Id == MovieId).FirstOrDefault();

            var aktörler = _context.actorActressMovieJoints.Where(x => x.MovieId == MovieId).ToList();

            if (movie == null)
            {
                throw new InvalidOperationException("Movie with given id is not exists!");
            }

            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);

            return vm;
        }

        public class MovieDetailViewModel
        {
            public string Title { get; set; }
            public string Director { get; set; }
            public string Genre { get; set; }
            public double Price { get; set; }
            public List<string> Actors { get; set; }
        }
    }
}
