using System;
using System.Collections.Generic;
using Access_API.DAL;

namespace Access_API.BLL
{
    public class SearchBLL
    {
        public string SearchBll(string words, List<long> sourceIds, List<string> authors, List<int> categoryIds,
            DateTime? beforeDate, DateTime? afterDate, int? limit, int? offset)
        {
            string url = Urls.SearchUrl + $"/search?words={words}";
            foreach (long sourceId in sourceIds) url += $"&sourceIds={sourceId}"; // Skips if list is empty
            foreach (string author in authors) url += $"&authors={author}"; // Skips if list is empty
            foreach (int categoryId in categoryIds) url += $"&categoryIds={categoryId}"; // Skips if list is empty
            if (beforeDate is not null) url += $"&beforeDate={beforeDate:o}";
            if (afterDate is not null) url += $"&afterDate={afterDate:o}";
            if (limit is not null) url += $"&limit={limit}";
            if (offset is not null) url += $"&offset={offset}";

            DocumentDataDAL dal = new DocumentDataDAL();

            return dal.GetResults(url);
        }
    }
}
