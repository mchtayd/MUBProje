using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class YurtDisiGorevDal // : IRepository<YurtDisiGorev>
    {
        static YurtDisiGorevDal yurtDisiGorevDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YurtDisiGorevDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(YurtDisiGorev entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public YurtDisiGorev Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YurtDisiGorev> GetList()
        {
            try
            {
                List<YurtDisiGorev> yurtDisiGorevs = new List<YurtDisiGorev>();
                dataReader = sqlServices.StoreReader("DevamYurtDisiList");
                while (dataReader.Read())
                {
                    yurtDisiGorevs.Add(new YurtDisiGorev(
                        dataReader["ID"].ConInt(),
                        dataReader["AD_SOYAD"].ToString(),
                        dataReader["UNVANI"].ToString(),
                        dataReader["BAS_TARIHI"].ConDate(),
                        dataReader["BIT_TARIHI"].ConDate(),
                        dataReader["TOPLAM_SURE"].ToString(),
                        dataReader["KALAN_SURE"].ToString()));
                }
                dataReader.Close();
                return yurtDisiGorevs;
            }
            catch (Exception)
            {
                return new List<YurtDisiGorev>();
            }
        }

        public string Update(YurtDisiGorev entity)
        {
            throw new NotImplementedException();
        }
        public static YurtDisiGorevDal GetInstance()
        {
            if (yurtDisiGorevDal == null)
            {
                yurtDisiGorevDal = new YurtDisiGorevDal();
            }
            return yurtDisiGorevDal;
        }
    }
}
