using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int DirectorId { get; set; }

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.Where(director => director.Id == DirectorId).FirstOrDefault();

            if (director == null)
            {
                throw new InvalidOperationException($"Director with id: {DirectorId} not exists!");
            }

            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);

            return vm;
        }

        public class DirectorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

    }
}
