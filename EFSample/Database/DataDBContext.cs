using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    public class DataDBContext : DbContext
    {
        public DbSet<Person> PersonData { get; set; }
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(x => x.Id);
        }
    }
}
