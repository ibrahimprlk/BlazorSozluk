using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlozorSozluk.Infrastructure.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentFavoriteEntityConfiguration : BaseEntityConfiguration<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentfavorite", BlazorSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComment)
                .WithMany(i => i.EntryCommentFavorites)
                .HasForeignKey(i => i.EntryCommentId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryCommentFavorites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict); // Herhangi bir silme isleminde nasil calisacagi icin
        }
    }
}
