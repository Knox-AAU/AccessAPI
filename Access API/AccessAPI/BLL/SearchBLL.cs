namespace Access_API.BLL
{
    public class SearchBLL
    {
        public SearchResultsDTO searchBLL(string input, string sources)
        {
            string url = Urls.SearchUrl + $"/search?input={input}&sources={sources}";
            DAL.SearchDAL DAL = new DAL.SearchDAL();

            return DAL.GetSearchResults(url);
        }
    }
}
