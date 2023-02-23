using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class ActorMovieJoint
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
