using AutoMapper;
using WebApi.Application.OrderOperations.Queries.GetOrderDetail;
using WebApi.Application.OrderOperations.Queries.GetOrders;
using WebApi.DbOperations;
using WebApi.Entities;
using static WebApi.Application.ActorOperaitons.Commands.CreateActor.CreateActorCommand;
using static WebApi.Application.ActorOperaitons.Commands.UpdateActor.UpdateActorCommand;
using static WebApi.Application.ActorOperaitons.Queries.GetActorDetail.GetActorDetailQuery;
using static WebApi.Application.ActorOperaitons.Queries.GetActors.GetActorQuery;
using static WebApi.Application.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
using static WebApi.Application.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static WebApi.Application.DirectorOperations.Commands.UpdateDirector.UpdateDirectorCommand;
using static WebApi.Application.DirectorOperations.Queries.GetDirectorDetail.GetDirectorDetailQuery;
using static WebApi.Application.DirectorOperations.Queries.GetDirectors.GetDirectorsQuery;
using static WebApi.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static WebApi.Application.GenreOperations.Commands.UpdateGenre.UpdateGenreCommand;
using static WebApi.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static WebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static WebApi.Application.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static WebApi.Application.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;
using static WebApi.Application.MovieOperations.Queries.GetMovieDetail.GetMovieDetailQuery;
using static WebApi.Application.MovieOperations.Queries.GetMovies.GetMoviesQuery;
using static WebApi.Application.OrderOperations.Commands.CreateOrder.CreateOrderCommand;

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


            //Movie Mapping
            CreateMap<Movie, MovieViewModel>().ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname));
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.GenreTitle))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorMovieJoint.Select(x => x.Actor.Name + " " + x.Actor.Surname)));

            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<UpdateMovieViewModel, Movie>();

            //Genre Mapping
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<UpdateGenreViewModel, Genre>();

            //Customer Mapping
            CreateMap<CreateCustomerModel, Customer>();

            CreateMap<CreateOrderModel, Order>();
            CreateMap<Customer, OrderDetailViewModel>()
            .ForMember(dest => dest.FirstNameLastname, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Title)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Price)))
            .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.PurchasedTime)));
            CreateMap<Customer, OrderViewModel>()
            .ForMember(dest => dest.NameSurname, opt => opt.MapFrom(m => m.Name + " " + m.Surname))
            .ForMember(dest => dest.Movies, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Title)))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(m => m.Orders.Select(s => s.Movie.Price)))
            .ForMember(dest => dest.PurchasedDate, opt => opt.MapFrom(m => m.Orders.Select(s => s.PurchasedTime)));
        }
    }
}  
