namespace WebAssemblyF.Models
{
	public class SendTaskToObject
	{
		public ITaskDynamic taskOpen { get; set; }
		public new List<string> collaborators { get; set; }

		public string input { get; set; }

		public SendTaskToObject(ITaskDynamic taskOpen, List<string> collaborators, string input)
		{
			this.taskOpen = taskOpen;
			this.collaborators = collaborators;
			this.input = input;
		}
	}
}
