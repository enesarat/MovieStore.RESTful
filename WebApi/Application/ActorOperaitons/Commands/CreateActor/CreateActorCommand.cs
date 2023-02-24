using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperaitons.Commands.CreateActor
{
    public class CreateActorCommand
    {
        public CreateActorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;


        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.ActorActress.SingleOrDefault(x => x.Name == Model.Name);
            if (actor != null)
            {
                throw new InvalidOperationException("A actor with the given title already exists!");
            }

            actor = _mapper.Map<Actor>(Model);

            _context.ActorActress.Add(actor);
            _context.SaveChanges();
        }

        public class CreateActorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
