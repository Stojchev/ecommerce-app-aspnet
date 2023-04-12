using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        //[Key]
        //public int ActorId { get; set; }
        public int Id { get; set; }
        public string? ProfilePictureURL { get; set; }
        public string? FullName { get; set; }
        public string? Biography { get; set; }
        //Relatioships
        public List<Actor_Movie> Actor_Movies{ get; set; }
    }
}
