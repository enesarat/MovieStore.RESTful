using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreViewModel Model { get; set; }
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException($"Genre with id: {GenreId} not exists!");
            }

            _mapper.Map(Model, genre);
            _context.SaveChanges();
        }

        public class UpdateGenreViewModel
        {
            public string GenreTitle { get; set; }
        }
    }
}
