using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public List<DirectorViewModel> Handle()
        {
            var directors = _context.Directors.ToList();
            List<DirectorViewModel> vm = _mapper.Map<List<DirectorViewModel>>(directors);
            return vm;
        }

        public class DirectorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
