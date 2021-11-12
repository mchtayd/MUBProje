using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TeklifiAlinanReddedilenDal //: IRepository<TeklifiAlinanReddedilen>
    {
        static TeklifiAlinanReddedilenDal teklifiAlDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TeklifiAlinanReddedilenDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(TeklifiAlinanReddedilen entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TeklifiAlinanReddedilen Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TeklifiAlinanReddedilen> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(TeklifiAlinanReddedilen entity)
        {
            throw new NotImplementedException();
        }
    }
}
