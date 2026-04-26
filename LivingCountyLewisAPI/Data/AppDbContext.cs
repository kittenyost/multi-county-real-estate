using Microsoft.EntityFrameworkCore;
using LivingCountyLewisAPI.Models;

namespace LivingCountyLewisAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<EmailLead> EmailLeads { get; set; }

        // ✅ Add this line for Admins table
        public DbSet<Admin> Admins { get; set; }
    }
}