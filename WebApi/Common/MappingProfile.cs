using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.ActorOperaitons.Commands.CreateActor.CreateActorCommand;
using static WebApi.Application.ActorOperaitons.Commands.UpdateActor.UpdateActorCommand;
using static WebApi.Application.ActorOperaitons.Queries.GetActorDetail.GetActorDetailQuery;
using static WebApi.Application.ActorOperaitons.Queries.GetActors.GetActorQuery;

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
        }
    }
}  
