using AutoMapper;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public void Hande()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.GenreTitle == Model.GenreTitle);
            if (genre != null)
            {
                throw new InvalidOperationException("A genre with the given title already exists!");
            }

            genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public class CreateGenreViewModel
        {
            public string GenreTitle { get; set; }
        }
    }
}
