using System;
using BackgroundJob.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackgroundJob.Data
{
    public class AppDbContext : DbContext
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            _options = options;
        }

        public DbSet<Persona> Personas { get; set; }
    }
}

