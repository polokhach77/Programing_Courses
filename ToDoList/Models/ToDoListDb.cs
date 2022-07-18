using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ToDoList.Models
{
    public partial class ToDoListDb : DbContext
    {
        public ToDoListDb()
            : base("name=ToDoListDb")
        {
        }

        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.User_id)
                .WillCascadeOnDelete(false);
        }
    }
}
