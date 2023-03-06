using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Yerleskeler
{
    public class YerlekseDal // : IRepository<Yerleske>
    {
        static YerlekseDal yerlekseDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YerlekseDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Yerleske entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YerleskeBilgileriKayit",
                    new SqlParameter("@yerleskeAdi", entity.YerleskeAdi),
                    new SqlParameter("@mulkiyetBilgileri", entity.MulkiyetBilgileri),
                    new SqlParameter("@adres", entity.YerleskeAdresi),
                    new SqlParameter("@aboneTuru", entity.AboneTuru),
                    new SqlParameter("@hizmetAlinanKurum", entity.HizmetAlinanKurum),
                    new SqlParameter("@tarih", entity.AboneTarihi),
                    new SqlParameter("@abonelikDurumu", entity.AbonelikDurumu),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@aboneTesisatNo", entity.AboneTesisatNo));

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

        public Yerleske Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YerleskeBilgileriList",new SqlParameter("@siparisNo",siparisNo));
                Yerleske item = null;
                while (dataReader.Read())
                {
                    item = new Yerleske(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["ABONE_TURU"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ABONA_TARIHI"].ConDate(),
                        dataReader["ABONELIK_DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Yerleske YerleskeBiigiCek(string yerleskeAdi, string aboneTuru)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YerleskeBilgiCek", new SqlParameter("@yerleskeAdi", yerleskeAdi), new SqlParameter("@aboneTuru", aboneTuru));
                Yerleske item = null;
                while (dataReader.Read())
                {
                    item = new Yerleske(
                         dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["ABONE_TURU"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ABONA_TARIHI"].ConDate(),
                        dataReader["ABONELIK_DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Yerleske> GetList(string siparisNo)
        {
            try
            {
                List<Yerleske> yerleskes = new List<Yerleske>();
                dataReader = sqlServices.StoreReader("YerleskeBilgileriList",new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    yerleskes.Add(new Yerleske(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["ABONE_TURU"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ABONA_TARIHI"].ConDate(),
                        dataReader["ABONELIK_DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return yerleskes;
            }
            catch (Exception)
            {
                return new List<Yerleske>();
            }
        }
        public List<Yerleske> AbonelikKontrol(string yerleskeAdi,string abonelikTuru,string hizmetAlinanKurum,string siparisNo)
        {
            try
            {
                List<Yerleske> yerleskes = new List<Yerleske>();
                dataReader = sqlServices.StoreReader("AbonelikKontrol", 
                    new SqlParameter("@yerleskeAdi",yerleskeAdi),
                    new SqlParameter("@abonelikTuru",abonelikTuru),
                    new SqlParameter("@hizmetAlinanKurum",hizmetAlinanKurum),
                    new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    yerleskes.Add(new Yerleske(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["ABONE_TURU"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ABONA_TARIHI"].ConDate(),
                        dataReader["ABONELIK_DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return yerleskes;
            }
            catch (Exception)
            {
                return new List<Yerleske>();
            }
        }

        public string Update(Yerleske entity)
        {
            throw new NotImplementedException();
        }
        public static YerlekseDal GetInstance()
        {
            if (yerlekseDal == null)
            {
                yerlekseDal = new YerlekseDal();
            }
            return yerlekseDal;
        }
    }
}
