using System.Collections.Generic;
using MyMvcApp.Models;

namespace MyMvcApp.Data
{
    public interface IUserRepo
    {
        Task<User> CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUserByName(string name);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);
    }
}