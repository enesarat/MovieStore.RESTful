using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperaitons.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }

        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public ActorDetailViewModel Handle()
        {
            var actor = _context.ActorActress.Where(actor => actor.Id == ActorId).SingleOrDefault();
            if (actor == null)
            {
                throw new InvalidOperationException("Actor could not found!");
            }

            ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);

            return vm;
        }

        public class ActorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
