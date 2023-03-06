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
    public class ServisFormuDal //: IRepository<ServisFormu>
    {
        static ServisFormuDal servisFormuDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ServisFormuDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(ServisFormu entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuKayit",
                    new SqlParameter("@isAkisNo",entity.IsAkisNo),
                    new SqlParameter("@firma",entity.Firma),
                    new SqlParameter("@usBolgesi",entity.UsBolgesi),
                    new SqlParameter("@servisFormNo",entity.ServisFormNo),
                    new SqlParameter("@mudehaleTuru",entity.MudehaleTuru),
                    new SqlParameter("@servisTarihi",entity.ServisTarihi),
                    new SqlParameter("@jenaratorCalismaSaati",entity.JenaratorCalismaSaati),
                    new SqlParameter("@iseBaslamaTarihi",entity.IsBaslamaTarihi),
                    new SqlParameter("@isBitisTarihi",entity.IsBitisTarihi),
                    new SqlParameter("@marka",entity.Marka),
                    new SqlParameter("@model",entity.Model),
                    new SqlParameter("@seriNo",entity.SeriNo),
                    new SqlParameter("@guc",entity.Guc),
                    new SqlParameter("@servisRaporu",entity.ServisRaporu),
                    new SqlParameter("@servisYetkilisi",entity.ServisYetkilisi),
                    new SqlParameter("@musteri",entity.Musteri),
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
            try
            {
                sqlServices.Stored("ServisFormuSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ServisFormu Get(int isAkisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuList",new SqlParameter("@isAkisNo",isAkisNo));
                ServisFormu item = null;
                while (dataReader.Read())
                {
                    item = new ServisFormu(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["SERVIS_FORM_NO"].ToString(),
                        dataReader["MUDEHALE_TURU"].ToString(),
                        dataReader["SERVIS_TARIHI"].ConDate(),
                        dataReader["JENARATOR_CALISMA_SAATI"].ConInt(),
                        dataReader["ISE_BASLAMA_TARIHI_SAATI"].ConDate(),
                        dataReader["IS_BITIS_TARIHI_SAATI"].ConDate(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GUC"].ToString(),
                        dataReader["SERVIS_RAPORU"].ToString(),
                        dataReader["SERVIS_YETKILISI"].ToString(),
                        dataReader["MUSTERI"].ToString(),
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
        public string IsAkisNoDuzelt(int id, int isAkisNo, string dosyaYolu)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuDuzelt",
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

        public List<ServisFormu> GetList(int isAkisNo)
        {
            try
            {
                List<ServisFormu> servisFormus = new List<ServisFormu>();
                dataReader = sqlServices.StoreReader("ServisFormuList", new SqlParameter("@isAkisNo", isAkisNo));
                while (dataReader.Read())
                {
                    servisFormus.Add(new ServisFormu(
                        dataReader["ID"].ConInt(),
                        dataReader["IS_AKIS_NO"].ConInt(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["SERVIS_FORM_NO"].ToString(),
                        dataReader["MUDEHALE_TURU"].ToString(),
                        dataReader["SERVIS_TARIHI"].ConDate(),
                        dataReader["JENARATOR_CALISMA_SAATI"].ConInt(),
                        dataReader["ISE_BASLAMA_TARIHI_SAATI"].ConDate(),
                        dataReader["IS_BITIS_TARIHI_SAATI"].ConDate(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["GUC"].ToString(),
                        dataReader["SERVIS_RAPORU"].ToString(),
                        dataReader["SERVIS_YETKILISI"].ToString(),
                        dataReader["MUSTERI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return servisFormus;
            }
            catch (Exception)
            {
                return new List<ServisFormu>();
            }
        }

        public string Update(ServisFormu entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ServisFormuGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@firma", entity.Firma),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@servisFormNo", entity.ServisFormNo),
                    new SqlParameter("@mudehaleTuru", entity.MudehaleTuru),
                    new SqlParameter("@servisTarihi", entity.ServisTarihi),
                    new SqlParameter("@jenaratorCalismaSaati", entity.JenaratorCalismaSaati),
                    new SqlParameter("@iseBaslamaTarihi", entity.IsBaslamaTarihi),
                    new SqlParameter("@isBitisTarihi", entity.IsBitisTarihi),
                    new SqlParameter("@marka", entity.Marka),
                    new SqlParameter("@model", entity.Model),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@guc", entity.Guc),
                    new SqlParameter("@servisRaporu", entity.ServisRaporu),
                    new SqlParameter("@servisYetkilisi", entity.ServisYetkilisi),
                    new SqlParameter("@musteri", entity.Musteri));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ServisFormuDal GetInstance()
        {
            if (servisFormuDal == null)
            {
                servisFormuDal = new ServisFormuDal();
            }
            return servisFormuDal;
        }
    }
}
