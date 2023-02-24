using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.ToList();
            List<GenreViewModel> vm = _mapper.Map<List<GenreViewModel>>(genres);
            return vm;
        }

        public class GenreViewModel
        {
            public string GenreTitle { get; set; }
        }

    }
}
