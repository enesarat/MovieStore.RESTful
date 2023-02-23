using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperaitons.Queries.GetActors
{
    public class GetActorQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public List<ActorViewModel> Handle()
        {
            var actorList = _context.ActorActress.ToList();
            List<ActorViewModel> vm = _mapper.Map<List<ActorViewModel>>(actorList);
            return vm;
        }

        public class ActorViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
