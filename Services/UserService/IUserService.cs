using System;
using WebAssemblyF.Models;
namespace WebAssemblyF.Services.UserService
{
	public interface IUserService
    {
        public List<UserModel> users { get; set; }
        public Task GetUsers();
        public Task<UserModel> GetSingleUser(string id);
        public Task CreateUser(UserModel user);
        public Task UpdateUser(UserModel user);
        public Task DeleteUser(string id);
    }
}

