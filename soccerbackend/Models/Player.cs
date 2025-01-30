namespace soccerbackend.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int Handicap { get; set; } = 10; // Default value
    }
}
