using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access_API.DAL;

namespace Access_API.BLL
{
    public class FileBLL
    {
        FileDAL fileDAL = new FileDAL();
        public List<byte> fileBLL(int id) 
        {
            return fileDAL.GetFile(id);
        }
    }
}
