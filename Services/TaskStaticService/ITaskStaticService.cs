using System;
using WebAssemblyF.Models;
namespace WebAssemblyF.Services.TaskStaticService
{
	public interface ITaskStaticService
	{
        public List<ITaskStatic> tasksStatic { get; set; }
        public List<string> categories { get; set; }
        public Task GetTasksStatic();
        public Task<ITaskStatic> GetSingleTaskStatic(string id);
        public Task CreateTaskStatic(ITaskStatic taskStatic);
        public Task UpdateTaskStatic(ITaskStatic taskStatic);
        public Task DeleteTaskStatic(string id);
    }
}

