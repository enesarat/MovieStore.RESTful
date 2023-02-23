using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.ActorOperaitons.Commands.CreateActor.CreateActorCommand;
using static WebApi.Application.ActorOperaitons.Commands.UpdateActor.UpdateActorCommand;
using static WebApi.Application.ActorOperaitons.Queries.GetActorDetail.GetActorDetailQuery;
using static WebApi.Application.ActorOperaitons.Queries.GetActors.GetActorQuery;
using static WebApi.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static WebApi.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static WebApi.Application.DirectorOperations.Queries.GetDirectorDetail.GetDirectorDetailQuery;
using static WebApi.Application.DirectorOperations.Queries.GetDirectors.GetDirectorsQuery;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public readonly IMovieStoreDbContext _dbContext;

        public MappingProfile()
        {
            //Actor Mapping
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Actor, ActorDetailViewModel>();
            CreateMap<UpdateActorModel, Actor>();

            //Director Mapping
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director, DirectorDetailViewModel>();
            CreateMap<UpdateDirectorViewModel, Director>();
        }
    }
}  
