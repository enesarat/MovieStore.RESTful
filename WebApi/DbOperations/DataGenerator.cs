using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                //Directors
                context.AddRange(
                    new Director { Name = "David", Surname = "Fincher" },
                    new Director { Name = "Cristopher", Surname = "Nolan" },
                    new Director { Name = "Stanley", Surname = "Kubrick" });

                //Movie Genres
                context.AddRange(
                    new Genre { GenreTitle = "Drama" },
                    new Genre { GenreTitle = "Comedy" },
                    new Genre { GenreTitle = "Science Fiction" },
                    new Genre { GenreTitle = "Fantastic" });

                //Movies
                context.AddRange(
                    new Movie { DirectorId = 1, GenreId = 2, Price = 79.90, Title = "Pirates Of Carrabian" },
                    new Movie { DirectorId = 1, GenreId = 1, Price = 64.90, Title = "Interstellar" },
                    new Movie { DirectorId = 2, GenreId = 3, Price = 74.90, Title = "One Flew Over the Cuckoo's Nest" },
                    new Movie { DirectorId = 3, GenreId = 3, Price = 54.90, Title = "Fight Club" });

                //Actors
                context.AddRange(
                    new Actor { Name = "Johnny", Surname = "Depp" },
                    new Actor { Name = "Keanu", Surname = "Reeves" },
                    new Actor { Name = "Jack", Surname = "Nicholson" },
                    new Actor { Name = "Daniel D.", Surname = "Lewis" },
                    new Actor { Name = "Leonardo", Surname = "Dicaprio" });

                //Movie and Actor Relation
                context.AddRange(
                    new ActorMovieJoint { ActorId = 1, MovieId = 1 },
                    new ActorMovieJoint { ActorId = 3, MovieId = 1 },
                    new ActorMovieJoint { ActorId = 1, MovieId = 2 },
                    new ActorMovieJoint { ActorId = 2, MovieId = 3 },
                    new ActorMovieJoint { ActorId = 4, MovieId = 4 });


                context.SaveChanges();

            }
        }
    }
}
