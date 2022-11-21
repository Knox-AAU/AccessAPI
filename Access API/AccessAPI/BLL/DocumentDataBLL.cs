using Access_API.DAL;

namespace Access_API.BLL
{
    public class DocumentDataBLL
    {
        public string CategoriesBll(int? limit, int? offset)
        {
            string url = Urls.SearchUrl + "/categories";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";

            SearchDAL dal = new SearchDAL();
            return dal.GetResults(url);
        }
        
        public string SourcesBll(int? limit, int? offset)
        {
            string url = Urls.SearchUrl + "/sources";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";
            
            SearchDAL dal = new SearchDAL();
            return dal.GetResults(url);
        }
    }
}