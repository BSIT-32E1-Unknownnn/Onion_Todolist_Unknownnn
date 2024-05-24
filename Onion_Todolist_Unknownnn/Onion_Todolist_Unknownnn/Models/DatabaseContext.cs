using Microsoft.EntityFrameworkCore;

namespace Onion_Todolist_Unknownnn.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Todolist> TodoList { get; set; }
    }
}