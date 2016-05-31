using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using IHFF.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Repositories
{
    public class IHFFContext : DbContext
    {
        private static IHFFContext _instance;

        public IHFFContext() : base("IHFFConnection")
        {

        }

        #region Properties

        //Singleton behaviour to prevent conflicts of several instances trying to read/write to database
        public static IHFFContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new IHFFContext();
                }
                return _instance;
            }
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Special> Specials { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Movie>().ToTable("Movie");
            modelBuilder.Entity<Special>().ToTable("Special");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Restaurant>().ToTable("Restaurant");

            modelBuilder.Entity<WishlistItem>()
                .HasRequired<Wishlist>(i => i.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(i => i.WishlistUID);

            modelBuilder.Entity<Wishlist>()
                .HasMany<WishlistItem>(w => w.WishlistItems)
                .WithRequired(i => i.Wishlist)
                .HasForeignKey(i => i.WishlistUID);
        }
    }
}