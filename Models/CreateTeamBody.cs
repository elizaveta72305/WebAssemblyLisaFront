namespace WebAssemblyF.Models
{
	public class CreateTeamBody
	{
		public string teamName { get; set; }

		public string[] listOfParticipantsEmail { get; set; }

		public CreateTeamBody(string teamName, string[] listOfParticipantsEmail)
		{
			this.teamName = teamName;
			this.listOfParticipantsEmail = listOfParticipantsEmail;
		}
	}
}
