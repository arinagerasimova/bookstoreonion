
namespace BookStore.Infrastructure.Data
{
    using System.Data.Entity;
    using BookStore.Domain.Core;

    public class StoreContext : DbContext
    {
        public StoreContext()
             : base("name=StoreContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PublishHouse> PublishHouses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .Property(e => e.AuthorCharacteristic)
                .IsUnicode(false);

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.BookCharacteristic)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Genre1)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Language1)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderItems)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublishHouse>()
                .Property(e => e.PublishHouseCharacteristic)
                .IsUnicode(false);

            modelBuilder.Entity<PublishHouse>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.PublishHouse)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}