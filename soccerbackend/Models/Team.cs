
namespace soccerbackend.Models
{
    public class Team
    {
        public Team() { }
        public Team(string name, List<Player> players)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Players = players ?? throw new ArgumentNullException(nameof(players));
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
