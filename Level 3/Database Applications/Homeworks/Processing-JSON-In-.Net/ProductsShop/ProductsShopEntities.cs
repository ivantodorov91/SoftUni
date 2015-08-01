using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductsShop
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopEntities : DbContext
    {
        public ProductsShopEntities()
            : base("name=ProductsShopEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions
                .Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });

            modelBuilder.Entity<Product>()
                .HasOptional<User>(s => s.Buyer)
                .WithMany(s => s.BoughtProducts)
                .HasForeignKey(s => s.BuyerId);

            modelBuilder.Entity<Product>()
                .HasRequired<User>(p => p.Seller)
                .WithMany(p => p.SoldProducts)
                .HasForeignKey(s => s.SellerId);


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

    }
}