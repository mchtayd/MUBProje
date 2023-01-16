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
    public class YerleskeSatDal //: IRepository<YerleskeSat>
    {
        static YerleskeSatDal yerleskeSatDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private YerleskeSatDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(YerleskeSat entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YerleskeSatKaydiEkle",
                    new SqlParameter("@satFormNo", entity.IsAkisNo),
                    new SqlParameter("@satNo", entity.SatNo),
                    new SqlParameter("@yerleskeAdi", entity.YerleskeAdi),
                    new SqlParameter("@giderTuru", entity.GiderTuru),
                    new SqlParameter("@yerleskeAdresi", entity.YerleskeAdresi),
                    new SqlParameter("@hizmetAlinanKurum", entity.Kurum),
                    new SqlParameter("@aboneTesisatNo", entity.AboneTesisatNo),
                    new SqlParameter("@istenenTarih", entity.IstenenTarih),
                    new SqlParameter("@donem", entity.Donem),
                    new SqlParameter("@tutar", entity.Tutar),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

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

        public YerleskeSat Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YerleskeSatKaydiGetList", new SqlParameter("@id", id));
                YerleskeSat item = null;
                while (dataReader.Read())
                {
                    item = new YerleskeSat(
                        dataReader["ID"].ConInt(),
                        dataReader["SAT_FORM_NO"].ConInt(),
                        dataReader["SAT_NO"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["GIDER_TURU"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ISTENEN_TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TUTAR"].ConDouble(),
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

        public List<YerleskeSat> GetList(string yerleskeAdi)
        {
            try
            {
                List<YerleskeSat> yerleskeSats = new List<YerleskeSat>();
                dataReader = sqlServices.StoreReader("YerleskeSatKaydiList", new SqlParameter("@yerleskeAdi", yerleskeAdi));
                while (dataReader.Read())
                {
                    yerleskeSats.Add(new YerleskeSat(
                        dataReader["ID"].ConInt(),
                        dataReader["SAT_FORM_NO"].ConInt(),
                        dataReader["SAT_NO"].ConInt(),
                        dataReader["YERLESKE_ADI"].ToString(),
                        dataReader["GIDER_TURU"].ToString(),
                        dataReader["YERLESKE_ADRESI"].ToString(),
                        dataReader["HIZMET_ALINAN_KURUM"].ToString(),
                        dataReader["ABONE_TESISAT_NO"].ToString(),
                        dataReader["ISTENEN_TARIH"].ConDate(),
                        dataReader["DONEM"].ToString(),
                        dataReader["TUTAR"].ConDouble(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return yerleskeSats;
            }
            catch (Exception)
            {
                return new List<YerleskeSat>();
            }
        }

        public string Update(YerleskeSat entity)
        {
            throw new NotImplementedException();
        }
        public static YerleskeSatDal GetInstance()
        {
            if (yerleskeSatDal == null)
            {
                yerleskeSatDal = new YerleskeSatDal();
            }
            return yerleskeSatDal;
        }
    }
}
