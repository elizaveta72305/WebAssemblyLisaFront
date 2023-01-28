namespace WebAssemblyF.Models
{
	public class SubmitTaskBody
	{
		public string teamName { get; set; }

		public string taskName { get; set; }
			public string solution { get; set; }

			//public string email { get; set; }

			public SubmitTaskBody(string teamName, string taskName, string solution)
			{
				this.taskName = taskName;
				this.solution = solution;
				this.teamName = teamName;
				//this.email = email;
			}
	}
}
