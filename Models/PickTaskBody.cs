namespace WebAssemblyF.Models
{
	public class PickTaskBody
	{
		public string teamName { get; set; }
		public string taskName { get; set; }

		public string collaborators { get; set; }

		public string email { get; set; }

		public PickTaskBody(string teamName, string taskName, string collaborators, string email)
		{
			this.teamName = teamName;
			this.taskName = taskName;
			this.collaborators = collaborators;
			this.email = email;
		}

	}
}
