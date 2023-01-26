namespace WebAssemblyF.Models
{

	public class ITaskToObject
	{
		public ITaskStatic task { get; set; }
		public List<string> collaborators { get; set; }

		public ITaskToObject(ITaskStatic task, List<string> collaborators)
		{
			this.task = task;
			this.collaborators = collaborators;
		}

	}
}
