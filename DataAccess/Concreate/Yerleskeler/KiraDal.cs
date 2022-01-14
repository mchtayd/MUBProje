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
    public class KiraDal // : IRepository<Kira>
    {
        static KiraDal kiraDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KiraDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Kira entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KiraBilgileriKayit",
                    new SqlParameter("@yerleskeAdi",entity.YerleskeAdi),
                    new SqlParameter("@yerleskeAdresi",entity.YerleskeAdresi),
                    new SqlParameter("@mulkiyetBilgileri",entity.MulkiyetBilgileri),
                    new SqlParameter("@adiSoyadi",entity.AdiSoyadi),
                    new SqlParameter("@tc",entity.Tc),
                    new SqlParameter("@ikametgah",entity.Ikametgah),
                    new SqlParameter("@telefon",entity.Telefon),
                    new SqlParameter("@bankaSubesi",entity.BankaSubesi),
                    new SqlParameter("@ibanNo",entity.IbanNo),
                    new SqlParameter("@kiraBaslangicTarihi",entity.KiraBaslangicTarihi),
                    new SqlParameter("@kiraTutar",entity.KiraTutar),
                    new SqlParameter("@depozito",entity.Depozito),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu),
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
            throw new NotImplementedException();
        }

        public Kira Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KiraBilgileriList",new SqlParameter("@id", id));
                Kira item = null;
                while (dataReader.Read())
                {
                    item = new Kira(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["IKAMETGAH"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BANKA_SUBESI"].ToString(),
                        dataReader["IBAN_NO"].ToString(),
                        dataReader["KIRA_BASLANGIC_TARIHI"].ConTime(),
                        dataReader["KIRA_TUTAR"].ConDouble(),
                        dataReader["DEPOZITO"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Kira> GetList()
        {
            try
            {
                List<Kira> kiras = new List<Kira>();
                dataReader = sqlServices.StoreReader("KiraBilgileriList");
                while (dataReader.Read())
                {
                    kiras.Add(new Kira(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["IKAMETGAH"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BANKA_SUBESI"].ToString(),
                        dataReader["IBAN_NO"].ToString(),
                        dataReader["KIRA_BASLANGIC_TARIHI"].ConTime(),
                        dataReader["KIRA_TUTAR"].ConDouble(),
                        dataReader["DEPOZITO"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return kiras;
            }
            catch (Exception)
            {
                return new List<Kira>();
            }
        }
        public List<Kira> YerleskeKontrol(string yerleskeAdi,string yerleskeAdresi,string mulkiyetBilgileri,string siparisNo)
        {
            try
            {
                List<Kira> kiras = new List<Kira>();
                dataReader = sqlServices.StoreReader("YerleskeKontrol",
                    new SqlParameter("@yerleskeAdi",yerleskeAdi),
                    new SqlParameter("@yerleskeAdresi",yerleskeAdresi),
                    new SqlParameter("@mulkiyetBilgileri",mulkiyetBilgileri),
                    new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    kiras.Add(new Kira(
                        dataReader["ID"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["MULKIYET_BILGILERI"].ToString(),
                        dataReader["ADI_SOYADI"].ToString(),
                        dataReader["TC"].ToString(),
                        dataReader["IKAMETGAH"].ToString(),
                        dataReader["TELEFON_NO"].ToString(),
                        dataReader["BANKA_SUBESI"].ToString(),
                        dataReader["IBAN_NO"].ToString(),
                        dataReader["KIRA_BASLANGIC_TARIHI"].ConTime(),
                        dataReader["KIRA_TUTAR"].ConDouble(),
                        dataReader["DEPOZITO"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return kiras;
            }
            catch (Exception)
            {
                return new List<Kira>();
            }
        }

        public string Update(Kira entity)
        {
            throw new NotImplementedException();
        }
        public static KiraDal GetInstance()
        {
            if (kiraDal == null)
            {
                kiraDal = new KiraDal();
            }
            return kiraDal;
        }
    }
}
