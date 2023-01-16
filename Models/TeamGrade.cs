namespace WebAssemblyF.Models
{
    public class TeamGrade
    {
        public string teamName { get; set; }

        public int score { get; set; }

        public TeamGrade(string TeamName, int Score)
        {
            teamName = TeamName;
            score = Score;
        }

    }
}
