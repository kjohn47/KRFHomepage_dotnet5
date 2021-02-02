namespace KRFHomepage.App.DatabaseQueries
{
    using System.Threading.Tasks;

    using KRFHomepage.Domain.Database.Homepage;

    public interface IHomepageDatabaseQuery
    {
        Task<HomePageData> GetHomePageDataAsync(string langCode);
    }
}
