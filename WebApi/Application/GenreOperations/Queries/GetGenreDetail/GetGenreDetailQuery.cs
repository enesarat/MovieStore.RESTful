using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.Where(x => x.Id == GenreId).FirstOrDefault();
            if (genre == null)
            {
                throw new InvalidOperationException($"Genre with id: {GenreId} not exists!");
            }

            GenreDetailViewModel vm = _mapper.Map<GenreDetailViewModel>(genre);

            return vm;
        }

        public class GenreDetailViewModel
        {
            public string GenreTitle { get; set; }
        }
    }
}
