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
    public class ButceKoduDal
    {
        static ButceKoduDal butceKoduDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private ButceKoduDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ButceKodu entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ButceKodu Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ButceKodu> GetList()
        {
            try
            {
                List<ButceKodu> butceKodus = new List<ButceKodu>();
                dataReader = sqlServices.StoreReader("ButceKoduKalemiListele");
                while (dataReader.Read())
                {
                    butceKodus.Add(new ButceKodu(dataReader["ID"].ConInt(),dataReader["BUTCE_KODU_KALEMI"].ToString()));
                }
                dataReader.Close();
                return butceKodus;
            }
            catch
            {
                return new List<ButceKodu>();
            }
        }

        public string Update(ButceKodu entity)
        {
            throw new NotImplementedException();
        }
        public static ButceKoduDal GetInstance()
        {
            if (butceKoduDal == null)
            {
                butceKoduDal = new ButceKoduDal();
            }
            return butceKoduDal;
        }
    }
}
