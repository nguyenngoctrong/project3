namespace Models.FrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FloristDbContext : DbContext
    {
        public FloristDbContext()
            : base("name=FloristDbContext")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Bouquest> Bouquests { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill>()
                .Property(e => e.Bill_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bouquest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bouquest>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Bouquest>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bouquest>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Cart>()
                .Property(e => e.Cart_Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CartDetail>()
                .Property(e => e.Total_Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Credit>()
                .Property(e => e.Credit_Card)
                .IsUnicode(false);

            modelBuilder.Entity<Credit>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Credit>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bouquests)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Sender)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Role_Define)
                .IsUnicode(false);
        }
    }
}
