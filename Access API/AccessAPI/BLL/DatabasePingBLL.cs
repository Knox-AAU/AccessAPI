using System.Net;

namespace Access_API.BLL
{
    public class DatabasePingBLL
    {
        public HttpWebResponse PingDatabase(string query)
        {
            DAL.PingDal DAL = new DAL.PingDal();
            return DAL.PingDb(query);
        }
    }
}