
namespace soccerbackend.Models
{
    public class Player
    {
        public Player(string name, string initials, int handicap)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Initials = initials ?? throw new ArgumentNullException(nameof(initials));
            Handicap = handicap;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int Handicap { get; set; } = 10; // Default value
    }
}
