using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperaitons.Commands.CreateActor;
using WebApi.Application.ActorOperaitons.Commands.DeleteActor;
using WebApi.Application.ActorOperaitons.Commands.UpdateActor;
using WebApi.Application.ActorOperaitons.Queries.GetActorDetail;
using WebApi.Application.ActorOperaitons.Queries.GetActors;
using WebApi.DbOperations;
using static WebApi.Application.ActorOperaitons.Commands.CreateActor.CreateActorCommand;
using static WebApi.Application.ActorOperaitons.Commands.UpdateActor.UpdateActorCommand;
using static WebApi.Application.ActorOperaitons.Queries.GetActorDetail.GetActorDetailQuery;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Here, we retreive all actor data from database context via GetAllActors endpoint.
        [HttpGet]
        public IActionResult GetAllActors()
        {
            GetActorQuery query = new GetActorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // Here, we retreive the actor data according to given id info from database context via GetActorById endpoint.
        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            ActorDetailViewModel result;
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorId = id;
            GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }

        // Here, we create actor data according to incoming author informations into database context via AddActor endpoint.
        [HttpPost]
        public IActionResult AddActor([FromBody] CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = newActor;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // Here, we update the actor data according to related author informations which exist on Id to database context via UpdateActor endpoint.
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel updatedActor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_mapper, _context);
            command.ActorId = id;
            command.Model = updatedActor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // Here, we delete the actor data according to given id info from database context via DeleteActor endpoint.
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

    }
}
