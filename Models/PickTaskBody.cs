namespace WebAssemblyF.Models
{
	public class PickTaskBody
	{
		public string teamName { get; set; }
		public string taskName { get; set; }

		public string[] collaboratorsEmails { get; set; }

		//public string email { get; set; }

		public PickTaskBody(string teamName, string taskName, string[] collaboratorsEmails)
		{
			this.teamName = teamName;
			this.taskName = taskName;
			this.collaboratorsEmails = collaboratorsEmails;
			//this.email = email;
		}

	}
}
