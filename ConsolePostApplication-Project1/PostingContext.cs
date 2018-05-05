using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    public class PostingContext : DbContext
    {
        public PostingContext() : base("PostingContext") { }

        public DbSet<User> Users {get;set;}
        public DbSet<Post> Posts {get;set;}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Username);
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("Password");
            modelBuilder.Entity<User>().Property(u => u.Role).HasColumnName("Role");


            modelBuilder.Entity<Post>().HasKey(u => u.Id);
            modelBuilder.Entity<Post>().Property(u => u.Message).HasColumnName("Message").HasMaxLength(250);
            modelBuilder.Entity<Post>().Property(u => u.Date).HasColumnName("Date");
            modelBuilder.Entity<Post>().Property(u => u.ConditionEdited).HasColumnType("bit").HasColumnName("ConditionEdited");
            modelBuilder.Entity<Post>().Property(u => u.SenderUsername).HasColumnName("SenderUsername");
            modelBuilder.Entity<Post>().Property(u => u.ReceiverUsername).HasColumnName("ReceiverName");

            modelBuilder.Entity<Post>()
               .HasRequired(i => i.Sender)
               .WithMany(i => i.SentPosts)
               .HasForeignKey(i => i.SenderUsername)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
           .HasRequired(i => i.Receiver)
           .WithMany(i => i.ReceivedPosts)
           .HasForeignKey(i => i.ReceiverUsername)
           .WillCascadeOnDelete(false);

            //base.OnModelCreating(modelBuilder);
        }
        /*
                public DbSet<User> Users { get; set; }
                // public DbSet<User> Receiver { get; set; }
                public DbSet<Post> Posts { get; set; }

                //To access the fluent API you override the OnModelCreating method in DbContext
                protected override void OnModelCreating(DbModelBuilder dbmodelBuilder)
                {

                }
                */
    }
}
