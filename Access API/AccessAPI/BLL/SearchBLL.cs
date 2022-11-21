using System;
using System.Collections.Generic;
using Access_API.DAL;

namespace Access_API.BLL
{
    public class SearchBLL
    {
        public string SearchBll(string words, List<long>? sourceIds, List<string>? authors, List<int>? categoryId,
            DateTime? beforeDate, DateTime? afterDate, int? limit, int? offset)
        {
            string url = Urls.SearchUrl + $"/search?words={words}";
            if (sourceIds is not null) url += $"&sourceId={sourceIds}";
            if (authors is not null) url += $"&author={authors}";
            if (categoryId is not null) url += $"&categoryId={categoryId}";
            if (beforeDate is not null) url += $"&beforeDate={beforeDate:o}";
            if (afterDate is not null) url += $"&afterDate={afterDate:o}";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";

            SearchDAL dal = new SearchDAL();

            return dal.GetResults(url);
        }
    }
}
