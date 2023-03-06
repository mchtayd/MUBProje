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
    public class SatRaporLogDal // : IRepository<SatRaporLog>
    {
        static SatRaporLogDal satRaporLogDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatRaporLogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(SatRaporLog entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatRaporKayitlariEkle",
                    new SqlParameter("@firmaBilgisi",entity.FirmaBilgisi),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@yil",entity.Yil),
                    new SqlParameter("@islemYapan",entity.IslemYapan),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@toplamTutar",entity.ToplamTutar));
                dataReader.Close();
                return "OK";
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

        public SatRaporLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRaporLog> GetList()
        {
            try
            {
                List<SatRaporLog> satRaporLogs = new List<SatRaporLog>();
                dataReader = sqlServices.StoreReader("SatRaporKayitlariListele");
                while (dataReader.Read())
                {
                    satRaporLogs.Add(new SatRaporLog(
                        dataReader["ID"].ConInt(),
                        dataReader["FIRMA_BILGISI"].ToString(),
                        dataReader["DONEM"].ToString(),
                        dataReader["YIL"].ToString(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["TOPLAM_TUTAR"].ConDouble()));
                }
                dataReader.Close();
                return satRaporLogs;
            }
            catch (Exception)
            {
                return new List<SatRaporLog>();
            }
        }

        public string Update(SatRaporLog entity)
        {
            throw new NotImplementedException();
        }
        public static SatRaporLogDal GetInstance()
        {
            if (satRaporLogDal == null)
            {
                satRaporLogDal = new SatRaporLogDal();
            }
            return satRaporLogDal;
        }
    }
}
