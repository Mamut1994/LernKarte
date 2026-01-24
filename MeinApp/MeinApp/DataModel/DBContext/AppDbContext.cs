using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeinApp.DataModel.DataForm;
using Microsoft.EntityFrameworkCore;

namespace MeinApp.DataModel.DBContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<FrageStr> Fragen { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MeinApp.db");
        }
    }
}
