using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using IHFF.Models;
using IHFF.Interfaces;
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

        //Singleton, behaviour to prevent conflicts of several instances trying to read/write to database
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
        public DbSet<Restaurant> Restaurants { get; set; } //wat gebeurt hier?
        public DbSet<Special> Specials { get; set; }
        public DbSet<RestaurantReservation> RestaurantReservations { get; set;}

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
            modelBuilder.Entity<Restaurant>().ToTable("Restaurant"); //wat gebeurt hier?
            modelBuilder.Entity<RestaurantReservation>().ToTable("RestaurantReservation");
            modelBuilder.Entity<FoodFilm>().ToTable("FoodFilm");

            // Sets n-to-1 relation between Event (n) and Movie (1)
            modelBuilder.Entity<Event>()
                .HasRequired<Movie>(e => e.Movie)
                .WithMany(m => m.Airings)
                .HasForeignKey(e => e.ItemId);

            // Sets n-to-1 relation between Event (n) and Special (1)
            modelBuilder.Entity<Event>()
                .HasRequired<Special>(e => e.Special)
                .WithMany(s => s.Airings)
                .HasForeignKey(e => e.ItemId);

            modelBuilder.Entity<FoodFilm>()
                .HasRequired<RestaurantReservation>(f => f.Reservation)
                .WithMany(r => r.FoodFilms)
                .HasForeignKey(f => f.ReservationId);

            modelBuilder.Entity<FoodFilm>()
                .HasRequired<Event>(f => f.Event)
                .WithMany(e => e.FoodFilms)
                .HasForeignKey(f => f.EventId);

            // Sets n-to-1 relation between WishlistItem (n) and Wishlist (1)
            modelBuilder.Entity<WishlistItem>()
                .HasRequired<Wishlist>(i => i.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(i => i.WishlistUID);

            // Sets n-to-1 relation between WishlistItem (n) and Event (1)
            modelBuilder.Entity<WishlistItem>()
                .HasRequired<Event>(w => w.Event)
                .WithMany(e => e.WishlistItems)
                .HasForeignKey(w => w.ItemId);

            // Sets n-to-1 relation between WishlistItem (n) and RestaurantReservation (1)
            modelBuilder.Entity<WishlistItem>()
                .HasRequired<RestaurantReservation>(i => i.Reservation)
                .WithMany(r => r.WishlistItems)
                .HasForeignKey(i => i.ItemId);

            // Sets n-to-1 relation between WishlistItem (n) and FoodFilm (1)
            modelBuilder.Entity<WishlistItem>()
                .HasRequired<FoodFilm>(i => i.FoodFilm)
                .WithMany(r => r.WishlistItems)
                .HasForeignKey(i => i.ItemId);

            // Sets n-to-1 relation between RestaurantReservation (n) and Restaurant (1)
            modelBuilder.Entity<RestaurantReservation>()
                .HasRequired<Restaurant>(res => res.Restaurant)
                .WithMany(r => r.Reservations)
                .HasForeignKey(res => res.RestaurantId);
        }
    }
}