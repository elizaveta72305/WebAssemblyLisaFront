namespace WebAssemblyF.Models
{

	public class ITaskToObject
	{
		public string task { get; set; }
		public List<string> collaborators { get; set; }

		public ITaskToObject(string task, List<string> collaborators)
		{
			this.task = task;
			this.collaborators = collaborators;
		}

	}
}
