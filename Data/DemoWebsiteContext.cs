using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoWebsite.Models;

namespace DemoWebsite.Data
{
    public class DemoWebsiteContext : DbContext
    {
        public DemoWebsiteContext(DbContextOptions<DemoWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!; // Ensure this matches the actual DbSet name
    }
}
