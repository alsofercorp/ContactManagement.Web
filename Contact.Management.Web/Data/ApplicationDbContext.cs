using Contact.Management.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.Reflection.Metadata;

namespace Contact.Management.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Contacts>(c => c.HasKey(e => e.Id));
            builder.Entity<Contacts>(c => c.HasKey(e => e.EmailAddress));
           

            builder.Entity<Contacts>().Property("Id").UseIdentityColumn();
            builder.Entity<Contacts>().Property("Id").Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }

        public DbSet<Contacts> Contacts { get; set; }
    }
}