using Microsoft.EntityFrameworkCore;

namespace Onion_Todolist_Unknownnn.Models
{
    public class Database : DbContext
    {
        public DbSet<Todolist> TodoList { get; set; }

        // Add a constructor that accepts DbContextOptions
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }
    }
}