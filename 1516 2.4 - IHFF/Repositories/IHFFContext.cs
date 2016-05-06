using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using IHFF.Models;

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
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Airing> Airings { get; set; }
        public DbSet<Location> Locations { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airing>()
                .HasRequired<Movie>(a => a.Movie)
                .WithMany(m => m.Airings)
                .HasForeignKey(a => a.Movie_Id);

            modelBuilder.Entity<WishlistItem>()
                .HasRequired<Wishlist>(i => i.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(i => i.Wishlist_Id);

            modelBuilder.Entity<WishlistItem>()
                .HasRequired<ActivityType>(i => i.Item)
                .WithMany(a => a.WishlistItems)
                .HasForeignKey(i => i.ItemType);

            modelBuilder.Entity<Airing>()
                .HasRequired<Location>(a => a.Location)
                .WithMany(l => l.Airings)
                .HasForeignKey(a => a.Location_Id);
        }
    }
}