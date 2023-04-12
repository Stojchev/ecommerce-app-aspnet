namespace eTickets.Models
{
    public class Producer
    {
        //[Key]
        //public int ActorId { get; set; }
        public int Id { get; set; }
        public string? ProfilePictureURL { get; set; }
        public string? FullName { get; set; }
        public string? Biography { get; set; }
        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
