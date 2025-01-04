
using MyMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MyMvcApp.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext ( DbContextOptions<UsersContext> options) : base(options)
        {

        }
        

        public DbSet<User> Users {get; set;}
    }

   
}
