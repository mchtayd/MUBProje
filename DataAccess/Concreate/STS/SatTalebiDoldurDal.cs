using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class SatTalebiDoldurDal
    {
        static SatTalebiDoldurDal satMalListDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        bool result;
        private SatTalebiDoldurDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        /*public string Add(SatTalebiDoldur entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTalebiDoldurKaydet", new SqlParameter("@usbolgesi",entity.Usbolgesi));
                dataReader.Close();
                if (dataReader.Read())
                {
                    result = dataReader[0].ConBool();
                }
                if (result)
                {
                    return entity.Usbolgesi + " İsmiyle kayıtlı başka bir Üst Bölgesi bulunuyor.";
                }
                return entity.Usbolgesi+ "Üst Bölgesi" +entity.Bilforno+ "Bildirim/Form Numarası başarıyla eklendi." ;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }*/

        public string Delete(int id)
        {
            sqlServices.StoreReader("SatTalebiDoldurSil", new SqlParameter("@id",id));
            return "Başarıyla silindi.";
        }

        public SatTalebiDoldur Get(string bolgeAdi)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatBolgeProje", new SqlParameter("@bolgeAdi", bolgeAdi));
                SatTalebiDoldur item = null;
                while (dataReader.Read())
                {
                    item = new SatTalebiDoldur(dataReader["BOLGE_ADI"].ToString(),dataReader["PROJE"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SatTalebiDoldur> GetList()
        {
            try
            {
                List<SatTalebiDoldur> satTalebiDoldurs = new List<SatTalebiDoldur>();
                dataReader = sqlServices.StoreReader("SatTalebiDoldurList");
                while (dataReader.Read())
                {
                    satTalebiDoldurs.Add(new SatTalebiDoldur(dataReader["BOLGE_ADI"].ToString()));
                }
                dataReader.Close();
                return satTalebiDoldurs;
            }
            catch(Exception ex)
            {
                return new List<SatTalebiDoldur>();
            }
        }
        public List<SatTalebiDoldur> BolgeSatList(string bolgeAdi)
        {
            try
            {
                List<SatTalebiDoldur> satTalebiDoldurs = new List<SatTalebiDoldur>();
                dataReader = sqlServices.StoreReader("SatinAlmaYapilacaklar", new SqlParameter("@bolgeAdi",bolgeAdi));
                while (dataReader.Read())
                {
                    satTalebiDoldurs.Add(new SatTalebiDoldur(
                        dataReader["BOLGE_ADI"].ToString(), 
                        dataReader["FORM_NO"].ConInt()));
                }
                dataReader.Close();
                return satTalebiDoldurs;
            }
            catch (Exception ex)
            {
                return new List<SatTalebiDoldur>();
            }
        }

        /*public string Update(SatTalebiDoldur entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTalebiDoldurGuncelle", new SqlParameter("@id",entity.Id),new SqlParameter("@usbolgesi",entity.Usbolgesi),
                    new SqlParameter("@bilforno",entity.Bilforno));
                
                return entity.Usbolgesi + "Üst Bölgesi" + entity.Bilforno + "Bildirim/Form Numarası başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }*/

        public static SatTalebiDoldurDal GetInstance()
        {
            if (satMalListDal == null)
            {
                satMalListDal = new SatTalebiDoldurDal();
            }
            return satMalListDal;
        }


    }
}
