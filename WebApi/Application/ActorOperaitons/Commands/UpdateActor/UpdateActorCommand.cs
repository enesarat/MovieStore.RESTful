using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.ActorOperaitons.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int ActorId { get; set; }

        public UpdateActorCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public void Handle()
        {
            var actor = _context.Actor.SingleOrDefault(x => x.Id == ActorId);

            if (actor == null)
            {
                throw new InvalidOperationException($"Actor with id: {ActorId} not exists!");
            }

            _mapper.Map(Model, actor);
            _context.SaveChanges();
        }


        public class UpdateActorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
