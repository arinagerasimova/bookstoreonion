namespace BookStore.Domain.Core
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreContext : DbContext
    {
        public StoreContext()
            : base("name=StoreContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<PublishHouse> PublishHouse { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublishHouse>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.PublishHouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
