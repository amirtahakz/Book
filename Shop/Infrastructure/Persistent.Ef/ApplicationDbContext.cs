﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Domain.CategoryAgg;
using Domain.CommentAgg;
using Domain.OrderAgg;
using Domain.ProductAgg;
using Domain.RoleAgg;
using Domain.SellerAgg;
using Domain.SiteEntities;
using Domain.UserAgg;
using Infrastructure._Utilities.MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistent.Ef
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICustomPublisher _publisher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICustomPublisher publisher) :
            base(options)
        {
            _publisher = publisher;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerInventory> Inventories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var modifiedEntities = GetModifiedEntities();
            await PublishEvents(modifiedEntities);
            return await base.SaveChangesAsync(cancellationToken);
        }
        private List<BaseAggregateRoot> GetModifiedEntities() =>
            ChangeTracker.Entries<BaseAggregateRoot>()
                .Where(x => x.State != EntityState.Detached)
                .Select(c => c.Entity)
                .Where(c => c.DomainEvents.Any()).ToList();

        private async Task PublishEvents(List<BaseAggregateRoot> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.DomainEvents;
                foreach (var domainEvent in events)
                {
                    await _publisher.Publish(domainEvent, PublishStrategy.ParallelNoWait);
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
