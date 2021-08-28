using ApiLinkShortener.Configuration;
using ApiLinkShortener.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLinkShortener
{
    public class AppContext : DbContext
    {
        public DbSet<ShortenerModel> TableShortener { get; set; }
        public DbSet<AnalyticsModel> TableAnalytics { get; set; }
        public DbSet<SimpleAnalyticsModel> TableSimpleAnalytics { get; set; }
        private dynamic Connection = ConfigurationSettings.DataBase();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
             optionsBuilder.UseNpgsql($@"Host={Connection.host};Database={Connection.database};Username={Connection.user};Password={Connection.password}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalyticsModel>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<SimpleAnalyticsModel>(entity =>
            {
                entity.HasKey(x => x.Id);
            });
        }
    }
}
