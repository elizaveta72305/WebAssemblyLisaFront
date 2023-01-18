namespace WebAssemblyF.Models
{
	public class SubmitTaskBody
	{
			public string taskName { get; set; }
			public string solution { get; set; }

			public string email { get; set; }

			public SubmitTaskBody(string taskName, string solution, string email)
			{
				this.taskName = taskName;
				this.solution = solution;
				this.email = email;
			}
	}
}
