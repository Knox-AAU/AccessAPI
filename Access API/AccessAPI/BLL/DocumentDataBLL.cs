using Access_API.DAL;

namespace Access_API.BLL
{
    public class DocumentDataBLL
    {
        public string CategoriesBll(int? limit, int? offset)
        {
            string url = Urls.DocumentDataUrl + "/categories";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";

            DocumentDataDAL dal = new DocumentDataDAL();
            return dal.GetResults(url);
        }

        public string SourcesBll(int? limit, int? offset)
        {
            string url = Urls.DocumentDataUrl + "/sources";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";

            DocumentDataDAL dal = new DocumentDataDAL();
            return dal.GetResults(url);
        }
    }
}
