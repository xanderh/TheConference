using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheConference.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SpeakerEvent> Events { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
