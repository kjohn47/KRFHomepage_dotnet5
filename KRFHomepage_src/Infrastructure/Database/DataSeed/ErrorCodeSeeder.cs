namespace KRFHomepage.Infrastructure.Database.DataSeed
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using KRFHomepage.Domain.Database.Translations;

    public static class ErrorCodeSeeder
    {
        public static void Seed(EntityTypeBuilder<ErrorCode> entity)
        {
            entity.HasData(new[] {
                new ErrorCode {
                    Code = "GenericError"
                },
                new ErrorCode {
                    Code = "PageNotFound"
                },
                new ErrorCode {
                    Code = "AdminOnlyError"
                },
                new ErrorCode {
                    Code = "AbortError"
                }
            });
        }
    }
}