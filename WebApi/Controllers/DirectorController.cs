using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using WebApi.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.DbOperations;
using static WebApi.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static WebApi.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static WebApi.Application.DirectorOperations.Queries.GetDirectorDetail.GetDirectorDetailQuery;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        // Here, we retreive all director data from database context via GetAllDirectors endpoint.
        [HttpGet]
        public IActionResult GetAllDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // Here, we retreive the director data according to given id info from database context via GetDirectorById endpoint.
        [HttpGet("{id}")]
        public IActionResult GetDirectorById(int id)
        {
            DirectorDetailViewModel result;
            GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
            query.DirectorId = id;
            GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }


        // Here, we create director data according to incoming author informations into database context via AddDirector endpoint.
        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorViewModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // Here, we update the director data according to related author informations which exist on Id to database context via UpdateDirector endpoint.
        [HttpPut("{id}")]
        public IActionResult UpdateDirector([FromBody] UpdateDirectorViewModel updatedDirector, int id)
        {

            UpdateDirectorCommand command = new UpdateDirectorCommand(_context, _mapper);
            command.DirectorId = id;
            command.Model = updatedDirector;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        // Here, we delete the director data according to given id info from database context via DeleteDirector endpoint.
        [HttpDelete]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
