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
    public class EvrakKayitDal //: IRepository<EvrakKayit>
    {
        static EvrakKayitDal evrakKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private EvrakKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(EvrakKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("EvrakKayitEkle",
                    new SqlParameter("@isakisno",entity.IsAkisNo),
                    new SqlParameter("@yazituru",entity.YaziTuru),
                    new SqlParameter("@cinsi",entity.Cinsi),
                    new SqlParameter("@neredengeldi",entity.NeredenGeldigi),
                    new SqlParameter("@sayino",entity.Sayino),
                    new SqlParameter("@tarih",entity.Tarih),
                    new SqlParameter("@konu",entity.Konu),
                    new SqlParameter("@eksayisi",entity.EkSayisi),
                    new SqlParameter("@geregi",entity.Geregi),
                    new SqlParameter("@bilgi1",entity.Bilgi1),
                    new SqlParameter("@bilgi2",entity.Bilgi2),
                    new SqlParameter("@bilgi3",entity.Bilgi3),
                    new SqlParameter("@bilgi4",entity.Bilgi4),
                    new SqlParameter("@bilgi5",entity.Bilgi5),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu));
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
            try
            {
                dataReader = sqlServices.StoreReader("EvrakKayitSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public EvrakKayit Get(int isakisno)
        {
            try
            {
                dataReader = sqlServices.StoreReader("EvrakKayitList",new SqlParameter("@isakisno",isakisno));
                EvrakKayit item = null;
                while (dataReader.Read())
                {
                    item = new EvrakKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["YAZI_TURU"].ToString(),
                        dataReader["CINSI"].ToString(),
                        dataReader["NEREDEN_GELDIGI"].ToString(),
                        dataReader["SAYI_NO"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KONU"].ToString(),
                        dataReader["EK_SAYISI"].ToString(),
                        dataReader["GEREGI"].ToString(),
                        dataReader["BILGI1"].ToString(),
                        dataReader["BILGI2"].ToString(),
                        dataReader["BILGI3"].ToString(),
                        dataReader["BILGI4"].ToString(),
                        dataReader["BILGI5"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("EvrakKayitDuzenle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@isAkisNo", isAkisNo),
                    new SqlParameter("@dosyaYolu", dosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<EvrakKayit> GetList(int isakisno)
        {
            try
            {
                List<EvrakKayit> evraks = new List<EvrakKayit>();
                dataReader = sqlServices.StoreReader("EvrakKayitList", new SqlParameter("@isakisno", isakisno));
                while (dataReader.Read())
                {
                    evraks.Add(new EvrakKayit(dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["YAZI_TURU"].ToString(),
                        dataReader["CINSI"].ToString(),
                        dataReader["NEREDEN_GELDIGI"].ToString(),
                        dataReader["SAYI_NO"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["KONU"].ToString(),
                        dataReader["EK_SAYISI"].ToString(),
                        dataReader["GEREGI"].ToString(),
                        dataReader["BILGI1"].ToString(),
                        dataReader["BILGI2"].ToString(),
                        dataReader["BILGI3"].ToString(),
                        dataReader["BILGI4"].ToString(),
                        dataReader["BILGI5"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SAYFA"].ToString()));
                }
                dataReader.Close();
                return evraks;
            }
            catch (Exception)
            {
                return new List<EvrakKayit>();
            }
        }

        public string Update(EvrakKayit entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("EvrakKayitGuncelle",
                    new SqlParameter("id",id),
                    new SqlParameter("@yazituru", entity.YaziTuru),
                    new SqlParameter("@cinsi", entity.Cinsi),
                    new SqlParameter("@neredengeldi", entity.NeredenGeldigi),
                    new SqlParameter("@sayino", entity.Sayino),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@konu", entity.Konu),
                    new SqlParameter("@eksayisi", entity.EkSayisi),
                    new SqlParameter("@geregi", entity.Geregi),
                    new SqlParameter("@bilgi1", entity.Bilgi1),
                    new SqlParameter("@bilgi2", entity.Bilgi2),
                    new SqlParameter("@bilgi3", entity.Bilgi3),
                    new SqlParameter("@bilgi4", entity.Bilgi4),
                    new SqlParameter("@bilgi5", entity.Bilgi5));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static EvrakKayitDal GetInstance()
        {
            if (evrakKayitDal == null)
            {
                evrakKayitDal = new EvrakKayitDal();
            }
            return evrakKayitDal;
        }
    }
}
