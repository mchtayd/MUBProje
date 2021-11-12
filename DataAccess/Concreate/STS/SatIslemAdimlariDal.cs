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
    public class SatIslemAdimlariDal 
    {
        static SatIslemAdimlariDal islemAdimlariDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatIslemAdimlariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(SatIslemAdimlari entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatIslemAdimlariEkle", new SqlParameter("@siparisno", entity.Siparisno), new SqlParameter("@islem", entity.Islem),
                    new SqlParameter("@islemyapan", entity.Islemyapan), new SqlParameter("@tarih", entity.Tarih));
                dataReader.Close();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatIslemAdimlari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatIslemAdimlari> GetList(string siparisNo)
        {
            try
            {
                List<SatIslemAdimlari> satIslems = new List<SatIslemAdimlari>();
                dataReader = sqlServices.StoreReader("SatIslemAdimlariListele", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    satIslems.Add(new SatIslemAdimlari(dataReader["ID"].ConInt(), dataReader["SiparisNo"].ToString(), dataReader["Islem"].ToString(),
                        dataReader["IslemYapan"].ToString(), dataReader["Tarih"].ConTime()));
                }
                dataReader.Close();
                return satIslems;
            }
            catch
            {
                return new List<SatIslemAdimlari>();
            }
        }

        public string Update(SatIslemAdimlari entity)
        {
            throw new NotImplementedException();
        }
        public static SatIslemAdimlariDal GetInstance()
        {
            if (islemAdimlariDal == null)
            {
                islemAdimlariDal = new SatIslemAdimlariDal();
            }
            return islemAdimlariDal;
        }
    }
}
