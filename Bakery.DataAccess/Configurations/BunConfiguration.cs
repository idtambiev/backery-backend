using Bakery.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.DataAccess.Configurations
{
    public class BunConfiguration: IEntityTypeConfiguration<Bun>
    {
        public void Configure(EntityTypeBuilder<Bun> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.StartPrice)
                .IsRequired();

            builder
                .Property(x => x.CurrentPrice)
                .IsRequired();

            builder
                .Property(x => x.SalesDeadline)
                .IsRequired();

            builder
                .Property(x => x.NumberOfHours)
                .IsRequired();

            builder
                .Property(x => x.CreatedDate)
                .IsRequired();
        }
    }
}
