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
    public class DevamEdenIzlemeDal 
    {
        static DevamEdenIzlemeDal devamEdenIzlemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DevamEdenIzlemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(DevamEdenIzleme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DevamEdenSatEkle", new SqlParameter("@siparisno", entity.Siparisno), new SqlParameter("@islem", entity.Islem),
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

        public DevamEdenIzleme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DevamEdenIzleme> GetList(string siparisNo)
        {
            try
            {
                List<DevamEdenIzleme> devamEdenIzlemes = new List<DevamEdenIzleme>();
                dataReader = sqlServices.StoreReader("DevamEdenSatListe", new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    devamEdenIzlemes.Add(new DevamEdenIzleme(dataReader["ID"].ConInt(), dataReader["SiparisNo"].ToString(), dataReader["Islem"].ToString(),
                        dataReader["IslemYapan"].ToString(), dataReader["Tarih"].ConDate()));
                }
                dataReader.Close();
                return devamEdenIzlemes;
            }
            catch
            {
                return new List<DevamEdenIzleme>();
            }
        }

        public string Update(DevamEdenIzleme entity)
        {
            throw new NotImplementedException();
        }
        
        public static DevamEdenIzlemeDal GetInstance()
        {
            if (devamEdenIzlemeDal == null)
            {
                devamEdenIzlemeDal = new DevamEdenIzlemeDal();
            }
            return devamEdenIzlemeDal;
        }
    }
}
