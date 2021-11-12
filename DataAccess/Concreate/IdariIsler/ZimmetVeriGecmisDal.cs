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
    public class ZimmetVeriGecmisDal //: IRepository<ZimmetVeriGecmis>
    {
        static ZimmetVeriGecmisDal zimmetVeriGecmisDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ZimmetVeriGecmisDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ZimmetVeriGecmis entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetVeriGecmisKayit",
                    new SqlParameter("@dvno",entity.Dvno),
                    new SqlParameter("@dvetiketno",entity.DvEtiketNo),
                    new SqlParameter("@dvtanim",entity.DvTanim),
                    new SqlParameter("@marka",entity.DvMarka),
                    new SqlParameter("@model",entity.DvModel),
                    new SqlParameter("@serino",entity.SeriNo),
                    new SqlParameter("@durumu",entity.Durumu),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@islemturu",entity.IslemTuru),
                    new SqlParameter("@islemYapan",entity.IslemYapan),
                    new SqlParameter("@verenPersonel",entity.VerenPersonel),
                    new SqlParameter("@verensicil",entity.VerenSicil),
                    new SqlParameter("@verenmasrafyerino",entity.VerenMasYeriNo),
                    new SqlParameter("@verenmasrafyeri",entity.VeremMasYeri),
                    new SqlParameter("@verenmasyerisorumlusu",entity.VerenMasSorumlusu),
                    new SqlParameter("@verenbolum",entity.VerenBolum),
                    new SqlParameter("@aktarimtarihi",entity.Tarih),
                    new SqlParameter("@alanPersonel",entity.AlanPersonel),
                    new SqlParameter("@alansicil",entity.AlanSicil),
                    new SqlParameter("@alanmasrafyerino",entity.AlanMasYeriNo),
                    new SqlParameter("@alanmasrafyeri",entity.AlanMasYeri),
                    new SqlParameter("@alanmasyerisorumlusu",entity.AlanMasSorumlusu),
                    new SqlParameter("@alanbolum",entity.AlanBolum),
                    new SqlParameter("@aktarimgerekcesi",entity.AktarimGerekcesi),
                    new SqlParameter("@depoadresi",entity.DepoAdresi),
                    new SqlParameter("@lokasyon",entity.Lokasyon),
                    new SqlParameter("@lokasyonbilgi",entity.LokasyonBilgi),
                    new SqlParameter("@dosyayolu",entity.DosyaYolu));

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

        public ZimmetVeriGecmis Get(string dvEtiketNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ZimmetVeriGecmisList",new SqlParameter("@dvetiketno", dvEtiketNo));
                ZimmetVeriGecmis item = null;
                while (dataReader.Read())
                {
                    item = new ZimmetVeriGecmis(
                        dataReader["ID"].ConInt(),
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["VEREN_PERSONEL"].ToString(),
                        dataReader["VEREN_SICIL"].ToString(),
                        dataReader["VEREN_MAS_YERI_NO"].ToString(),
                        dataReader["VEREN_MAS_YERI"].ToString(),
                        dataReader["VEREN_MAS_YER_SOR"].ToString(),
                        dataReader["VEREN_BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConTime(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_SICIL"].ToString(),
                        dataReader["ALAN_MAS_YERI_NO"].ToString(),
                        dataReader["ALAN_MAS_YERI"].ToString(),
                        dataReader["ALAN_MAS_YER_SOR"].ToString(),
                        dataReader["ALAN_BOLUM"].ToString(),
                        dataReader["AKTARIM_GEREKCESI"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["LOKASYON_BILGI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ZimmetVeriGecmis> GetList()
        {
            try
            {
                List<ZimmetVeriGecmis> zimmetVeriGecmis = new List<ZimmetVeriGecmis>();
                dataReader = sqlServices.StoreReader("ZimmetVeriGecmisList");
                while (dataReader.Read())
                {
                    zimmetVeriGecmis.Add(new ZimmetVeriGecmis(
                        dataReader["ID"].ConInt(),
                        dataReader["DV_NO"].ConInt(),
                        dataReader["DV_ETIKET_NO"].ToString(),
                        dataReader["DV_TANIM"].ToString(),
                        dataReader["MARKA"].ToString(),
                        dataReader["MODEL"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["MIKTAR"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["VEREN_PERSONEL"].ToString(),
                        dataReader["VEREN_SICIL"].ToString(),
                        dataReader["VEREN_MAS_YERI_NO"].ToString(),
                        dataReader["VEREN_MAS_YERI"].ToString(),
                        dataReader["VEREN_MAS_YER_SOR"].ToString(),
                        dataReader["VEREN_BOLUM"].ToString(),
                        dataReader["AKTARIM_TARIHI"].ConTime(),
                        dataReader["ALAN_PERSONEL"].ToString(),
                        dataReader["ALAN_SICIL"].ToString(),
                        dataReader["ALAN_MAS_YERI_NO"].ToString(),
                        dataReader["ALAN_MAS_YERI"].ToString(),
                        dataReader["ALAN_MAS_YER_SOR"].ToString(),
                        dataReader["ALAN_BOLUM"].ToString(),
                        dataReader["AKTARIM_GEREKCESI"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["LOKASYON"].ToString(),
                        dataReader["LOKASYON_BILGI"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return zimmetVeriGecmis;

            }
            catch (Exception)
            {
                return new List<ZimmetVeriGecmis>();
            }
        }

        public string Update(ZimmetVeriGecmis entity)
        {
            throw new NotImplementedException();
        }
        public static ZimmetVeriGecmisDal GetInstance()
        {
            if (zimmetVeriGecmisDal == null)
            {
                zimmetVeriGecmisDal = new ZimmetVeriGecmisDal();
            }
            return zimmetVeriGecmisDal;
        }
    }
}
