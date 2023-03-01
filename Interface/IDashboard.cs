using WebAssemblyF.Models;

namespace WebAssemblyF.Interface
{
	public interface IDashboard
	{
		public Task GetAllTeams();
		public Task GetTeamByEmail();
		public Task GetAllCompetition();

		public Task<CompetitionModel> GetCompetitionById(string id);

		public Task CreateCompetition(CompetitionModel competition);
		public Task UpdateCompetition(CompetitionModel competition);

		public Task DeleteCompetition(string id);
		public List<string> userEmails { get; set; }

        public List<TaskModel> myStaticTask { get; set; }
		public List<TeamModel> myListOfAllTeams { get; set; }
		public List<TaskModel> Users { get; set; }
		public string Team { get; set; }
		public List<CompetitionModel> AllCompetitions { get; set; }



	}
}
