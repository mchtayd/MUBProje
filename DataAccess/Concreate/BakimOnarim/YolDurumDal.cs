using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class YolDurumDal //: IRepository<YolDurum>
    {
        static YolDurumDal yolDurumDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YolDurumDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static YolDurumDal GetInstance()
        {
            if (yolDurumDal == null)
            {
                yolDurumDal = new YolDurumDal();
            }
            return yolDurumDal;
        }

        public string Add(YolDurum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeYolDurumuAdd",
                    new SqlParameter("@bolgeAdi",entity.BolgeAdi),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@donem",entity.Donem),
                    new SqlParameter("@yolDurumu",entity.YolDurumu),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@kayitYapan",entity.KayitYapan));

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

        public YolDurum Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<YolDurum> GetList(string bolgeAdi,DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                List<YolDurum> yolDurums = new List<YolDurum>();
                dataReader = sqlServices.StoreReader("BolgeYolDurumuList", new SqlParameter("@bolgeAdi", bolgeAdi), new SqlParameter("@basTarihi", basTarihi), new SqlParameter("@bitTarihi", bitTarihi));
                while (dataReader.Read())
                {
                    yolDurums.Add(new YolDurum(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["YOL_DURUMU"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString()));
                }
                dataReader.Close();
                return yolDurums;
            }
            catch (Exception)
            {
                return new List<YolDurum>();
            }
        }

        public string Update(YolDurum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeYolDurumuUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@yolDurumu", entity.YolDurumu),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@kayitYapan", entity.KayitYapan));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
