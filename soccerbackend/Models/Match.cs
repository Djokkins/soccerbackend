namespace soccerbackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public Team Winner { get; set; }
        public Team Loser { get; set; }
    }
}
