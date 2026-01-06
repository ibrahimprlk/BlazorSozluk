using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlozorSozluk.Infrastructure.Persistence.EntityConfigurations
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("user", BlazorSozlukContext.DEFAULT_SCHEMA);
        }

    }
}