using System;
using System.Linq;
using System.Threading.Tasks;
using DB.DataAccess.IdentityModel;
using DB.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Testimonial> Testimonial { get; set; }
        public virtual void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        public virtual async Task CommitAsync()
        {
            try
            {
                await base.SaveChangesAsync();

            }
            catch (Exception)
            {
                // ignored
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
           
        }
    }
}
