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
        public Team? WinnerTeam { get; set; } // kampresultat kendes ikke ved oprettelse
        public int? LoserId { get; set; }
        public Team? LoserTeam { get; set; }

        public bool isPlayerOnBothTeams(Team team1, Team team2)
        {
            foreach (var player in team1.Players)
            {
                if (team2.Players.Contains(player))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
