using Bakery.Data.Entities;
using Bakery.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DataAccess
{
    public class BakeryDbContext: DbContext
    {
        public DbSet<Bun> Buns { get; set; }
        public BakeryDbContext(DbContextOptions<BakeryDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new BunConfiguration());


        }
    }
}
