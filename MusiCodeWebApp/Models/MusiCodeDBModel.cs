using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MusiCodeWebApp.Models
{
    public partial class MusiCodeDBModel : DbContext
    {
        public MusiCodeDBModel()
            : base("name=MusiCodeDBModel")
        {
        }

        public DbSet<ManagerRole> ManagerRoles { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
