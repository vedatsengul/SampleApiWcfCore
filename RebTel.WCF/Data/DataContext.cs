using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RebTel.WCF.Models;

namespace RebTel.WCF.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubscription>()
                .HasKey(t => new { t.UserId, t.SubscriptionId });

            modelBuilder.Entity<UserSubscription>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(pt => pt.UserId);

            modelBuilder.Entity<UserSubscription>()
                .HasOne(pt => pt.Subscription)
                .WithMany(t => t.UserSubscriptions)
                .HasForeignKey(pt => pt.SubscriptionId);
        }
    }
}