using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArizaIslemAdimiDal // : IRepository<ArizaIslemAdimi>
    {
        static ArizaIslemAdimiDal arizaIslemAdimiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ArizaIslemAdimiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ArizaIslemAdimi entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaIslemAdimi Get(string islemAdimi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimArizalar", new SqlParameter("@islemAdimi", islemAdimi));
                ArizaIslemAdimi item = null;
                while (dataReader.Read())
                {
                    item = new ArizaIslemAdimi(
                        dataReader["SIRNAK"].ConInt(),
                        dataReader["CUKURCA"].ConInt(),
                        dataReader["YUKSEKOVA"].ConInt(),
                        dataReader["SEMDINLI"].ConInt(),
                        dataReader["DERECIK"].ConInt(),
                        dataReader["D_BOLGESI"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ArizaIslemAdimi> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(ArizaIslemAdimi entity)
        {
            throw new NotImplementedException();
        }

        public static ArizaIslemAdimiDal GetInstance()
        {
            if (arizaIslemAdimiDal == null)
            {
                arizaIslemAdimiDal = new ArizaIslemAdimiDal();
            }
            return arizaIslemAdimiDal;
        }
    }
}
