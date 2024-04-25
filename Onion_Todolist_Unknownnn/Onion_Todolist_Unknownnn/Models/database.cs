using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Onion_Todolist_Unknownnn.Models
{
    public class Database : DbContext
    {
        public DbSet<Todolist> TodoList {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=C:\Users\USER\Documents\GitHub\Onion_Todolist_Unknownnn\Onion_Todolist_Unknownnn\Onion_Todolist_Unknownnn\Files\todolist.db");
    }
}
