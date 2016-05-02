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

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}