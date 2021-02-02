namespace KRFHomepage.Domain.CQRS.Homepage.Query
{
    using KRFCommon.CQRS.Query;

    public class HomePageOutput: IQueryResponse
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Descrption { get; set; }
    }
}
