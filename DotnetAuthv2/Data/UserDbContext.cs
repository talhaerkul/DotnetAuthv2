using DotnetAuthv2.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetAuthv2.Data
{
    public class UserDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}