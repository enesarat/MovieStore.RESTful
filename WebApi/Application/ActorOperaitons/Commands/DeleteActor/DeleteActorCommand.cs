using WebApi.DbOperations;

namespace WebApi.Application.ActorOperaitons.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly IMovieStoreDbContext _dbContext;

        public int ActorId { get; set; }

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actor.SingleOrDefault(x => x.Id == ActorId);

            if (actor == null)
            {
                throw new InvalidOperationException($"Actor with id: {ActorId} not exists, delete operation failed!");
            }

            _dbContext.Actor.Remove(actor);
            _dbContext.SaveChanges();

        }
    }
}
