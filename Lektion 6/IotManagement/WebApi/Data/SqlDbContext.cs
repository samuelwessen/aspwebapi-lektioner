using Microsoft.EntityFrameworkCore;
using SharedRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }

        public DbSet<DhtMeasurement> DhtMeasurements { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
