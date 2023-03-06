using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database
{
    class SqlDatabase : SqlServices
    {
        static SqlDatabase sqlDatabase;

        public static SqlDatabase GetInstance()
        {
            if (sqlDatabase==null)
            {
                sqlDatabase = new SqlDatabase();
            }
            return sqlDatabase;
        }
    }
}
