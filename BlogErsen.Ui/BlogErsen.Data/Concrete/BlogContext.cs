using BlogErsen.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogErsen.Data.Concrete
{
    public class BlogContext:DbContext
    {
        public DbSet<Post>Posts  { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ersen\\Desktop\\BlogErsen\\BlogErsen.Ui\\BlogErsen.Data\\BlogContext.db");
        }
    }
}
