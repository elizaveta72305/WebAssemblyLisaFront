namespace WebAssemblyF.Models
{
	public class ITaskDynamicAdd
	{
		public ITaskDynamic task { get; set; }

		public ITaskDynamicAdd(ITaskDynamic task)
		{
			this.task = task;
		}
	}
}
