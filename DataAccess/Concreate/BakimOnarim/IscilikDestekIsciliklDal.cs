using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IscilikDestekIsciliklDal  //: IRepository<IscilikDestekIscilik>
    {
        static IscilikDestekIsciliklDal iscilikDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IscilikDestekIsciliklDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IscilikDestekIscilik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikEkle",
                    new SqlParameter("@iscilikTuru",entity.IscilikTuru),
                    new SqlParameter("@destekTuru",entity.DestekTuru),
                    new SqlParameter("@destekNedeniPersonel",entity.DestekNedeniPersonel),
                    new SqlParameter("@baslamaTarihiPersonel",entity.BaslamaTarihiPersonel),
                    new SqlParameter("@bitisTarihiPersonel",entity.BitisTarihiPersonel),
                    new SqlParameter("@toplamSurePersonel",entity.ToplamSurePersonel),
                    new SqlParameter("@destekNedeniArac",entity.DestekNedeniArac),
                    new SqlParameter("@baslamaTarihiArac",entity.BaslamaTarihiArac),
                    new SqlParameter("@bitisTarihiArac",entity.BitisTarihiArac),
                    new SqlParameter("@toplamSureArac",entity.ToplamSureArac),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

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
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikDelete",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekIscilik Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikList",new SqlParameter("@siparisNo",siparisNo));
                IscilikDestekIscilik item = null;
                while (dataReader.Read())
                {
                    item = new IscilikDestekIscilik(
                        dataReader["ID"].ConInt(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["DESTEK_TURU"].ToString(),
                        dataReader["DESTEK_NEDENI_PERSONEL"].ToString(),
                        dataReader["BASLAMA_TARIHI_PERSONEL"].ConTime(),
                        dataReader["BITIS_TARIHI_PERSONEL"].ConTime(),
                        dataReader["TOPLAM_SURE_PERSONEL"].ToString(),
                        dataReader["DESTEK_NEDENI_ARAC"].ToString(),
                        dataReader["BASLAMA_TARIHI_ARAC"].ConTime(),
                        dataReader["BITIS_TARIHI_ARAC"].ConTime(),
                        dataReader["TOPLAM_SURE_ARAC"].ToString(),
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

        public List<IscilikDestekIscilik> GetList(string adSoyad,string plaka)
        {
            try
            {
                List<IscilikDestekIscilik> ıscilikDestekIsciliks = new List<IscilikDestekIscilik>();
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikList",new SqlParameter("@adSoyad",adSoyad),
                    new SqlParameter("@plaka",plaka));
                while (dataReader.Read())
                {
                    ıscilikDestekIsciliks.Add(new IscilikDestekIscilik(
                        dataReader["ID"].ConInt(),
                        dataReader["ISCILIK_TURU"].ToString(),
                        dataReader["DESTEK_TURU"].ToString(),
                        dataReader["DESTEK_NEDENI_PERSONEL"].ToString(),
                        dataReader["BASLAMA_TARIHI_PERSONEL"].ConTime(),
                        dataReader["BITIS_TARIHI_PERSONEL"].ConTime(),
                        dataReader["TOPLAM_SURE_PERSONEL"].ToString(),
                        dataReader["DESTEK_NEDENI_ARAC"].ToString(),
                        dataReader["BASLAMA_TARIHI_ARAC"].ConTime(),
                        dataReader["BITIS_TARIHI_ARAC"].ConTime(),
                        dataReader["TOPLAM_SURE_ARAC"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return ıscilikDestekIsciliks;
            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<IscilikDestekIscilik>();
            }
        }
        public List<IscilikDestekTablo> GetListCellClickPersonel(string siparisNo)
        {
            try
            {
                List<IscilikDestekTablo> ıscilikDestekIsciliks = new List<IscilikDestekTablo>();
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikListPersonel", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    ıscilikDestekIsciliks.Add(new IscilikDestekTablo(
                        dataReader["ID"].ConInt(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["GOREVI"].ToString(),
                        dataReader["PERSONEL_BOLUM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return ıscilikDestekIsciliks;
            }
            catch (Exception ex)
            {
                return new List<IscilikDestekTablo>();
            }
        }
        public List<IscilikDestekTabloArac> GetListCellClickArac(string siparisNo)
        {
            try
            {
                List<IscilikDestekTabloArac> ıscilikDestekIsciliks = new List<IscilikDestekTabloArac>();
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikListArac", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    ıscilikDestekIsciliks.Add(new IscilikDestekTabloArac(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["KULLANIDIGI_BOLUM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return ıscilikDestekIsciliks;
            }
            catch (Exception ex)
            {
                return new List<IscilikDestekTabloArac>();
            }
        }

        public string Update(IscilikDestekIscilik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikGuncelle",
                    new SqlParameter("@iscilikTuru", entity.IscilikTuru),
                    new SqlParameter("@destekTuru", entity.DestekTuru),
                    new SqlParameter("@destekNedeniPersonel", entity.DestekNedeniPersonel),
                    new SqlParameter("@baslamaTarihiPersonel", entity.BaslamaTarihiPersonel),
                    new SqlParameter("@bitisTarihiPersonel", entity.BitisTarihiPersonel),
                    new SqlParameter("@toplamSurePersonel", entity.ToplamSurePersonel),
                    new SqlParameter("@destekNedeniArac", entity.DestekNedeniArac),
                    new SqlParameter("@baslamaTarihiArac", entity.BaslamaTarihiArac),
                    new SqlParameter("@bitisTarihiArac", entity.BitisTarihiArac),
                    new SqlParameter("@toplamSureArac", entity.ToplamSureArac),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikDestekIsciliklDal GetInstance()
        {
            if (iscilikDal == null)
            {
                iscilikDal = new IscilikDestekIsciliklDal();
            }
            return iscilikDal;
        }
    }
}
