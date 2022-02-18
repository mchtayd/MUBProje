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
    public class ReddedilenIzlemeDal 
    {
        static ReddedilenIzlemeDal reddedilenIzlemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ReddedilenIzlemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ReddedilenIzleme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ReddedilenSatEkle", new SqlParameter("@siparisno", entity.Siparisno), new SqlParameter("@islem", entity.Islem),
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

        public ReddedilenIzleme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReddedilenIzleme> GetList(string siparisNo)
        {
            try
            {
                List<ReddedilenIzleme> reddedilenIzlemes = new List<ReddedilenIzleme>();
                dataReader = sqlServices.StoreReader("ReddedilenSatListe", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    reddedilenIzlemes.Add(new ReddedilenIzleme(dataReader["ID"].ConInt(), dataReader["SiparisNo"].ToString(), dataReader["Islem"].ToString(),
                        dataReader["IslemYapan"].ToString(), dataReader["Tarih"].ConDate()));
                }
                dataReader.Close();
                return reddedilenIzlemes;
            }
            catch
            {
                return new List<ReddedilenIzleme>();
            }
        }

        public string Update(ReddedilenIzleme entity)
        {
            throw new NotImplementedException();
        }
        public static ReddedilenIzlemeDal GetInstance()
        {
            if (reddedilenIzlemeDal == null)
            {
                reddedilenIzlemeDal = new ReddedilenIzlemeDal();
            }
            return reddedilenIzlemeDal;
        }
    }
}
