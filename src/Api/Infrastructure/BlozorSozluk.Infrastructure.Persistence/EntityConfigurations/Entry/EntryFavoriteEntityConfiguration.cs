using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlozorSozluk.Infrastructure.Persistence.EntityConfigurations.Entry
{
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entryfavorite", BlazorSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryFavorites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // Herhangi bir silme isleminde nasil calisacagi icin
        }
    }
}
