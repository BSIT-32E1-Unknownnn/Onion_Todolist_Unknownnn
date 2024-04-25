using Microsoft.EntityFrameworkCore;

namespace Onion_Todolist_Unknownnn.Models
{
    public class Database : DbContext
    {
        public DbSet <Todolist> List {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"C:\Users\USER\Documents\GitHub\Onion_Todolist_Unknownnn\Onion_Todolist_Unknownnn\Onion_Todolist_Unknownnn\Files\todolist.db");
    }
}
