namespace KRFHomepage.Infrastructure.Database.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using KRFHomepage.Domain.Database.Translations;

    public static class TokenConfiguration
    {
        public static void Configure(EntityTypeBuilder<Token> entity)
        {
            entity.ToTable("tokens");
            entity.HasMany(c => c.Translations).WithOne(c => c.Token);
        }
    }
}
