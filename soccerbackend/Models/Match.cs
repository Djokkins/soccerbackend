namespace soccerbackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Team1Id { get; set; }
        public Team Team1 { get; set; }
        public int Team2Id { get; set; }
        public Team Team2 { get; set; }
        public int? WinnerId { get; set; }
        public Team? Winner { get; set; } // kampresultat kendes ikke ved oprettelse
        public int? LoserId { get; set; }
        public Team? Loser { get; set; }

    }
}
