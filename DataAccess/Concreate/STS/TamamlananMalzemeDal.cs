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
    public class TamamlananMalzemeDal //: IRepository<TamamlananMalzeme>
    {
        static TamamlananMalzemeDal tamamlananMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TamamlananMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(TamamlananMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTamamlananMalzemelerEkle",
                    new SqlParameter("@stokno",entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@firma",entity.Firma),
                    new SqlParameter("@birimfiyat",entity.Birimfiyat),
                    new SqlParameter("@toplamfiyat",entity.Toplamfiyat),
                    new SqlParameter("@siparisno",entity.Siparisno));

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

        public TamamlananMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TamamlananMalzeme> GetList(string siparisno)
        {
            try
            {
                List<TamamlananMalzeme> malzemes = new List<TamamlananMalzeme>();
                dataReader = sqlServices.StoreReader("SatTamamlananMalzemelerListele",new SqlParameter("@siparisno",siparisno));
                while (dataReader.Read())
                {
                    malzemes.Add(new TamamlananMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["FIRMA"].ToString(),
                        dataReader["BIRIM_FIYATI"].ConDouble(),
                        dataReader["TOPLAM_FIYAT"].ConDouble(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return malzemes;
            }
            catch (Exception)
            {
                return new List<TamamlananMalzeme>();
            }


        }

        public string UpdateFiyat(TamamlananMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TamamlananSatMalzemeFiyatGuncelle",
                    new SqlParameter("@birimFiyati",entity.Birimfiyat),
                    new SqlParameter("@tutar",entity.Toplamfiyat),
                    new SqlParameter("@siparisNo",entity.Siparisno),
                    new SqlParameter("@stokNo",entity.Stokno));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Update(TamamlananMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("TamamlananSatFiyatUpdate",
                    new SqlParameter("@id", entity.Siparisno),
                    new SqlParameter("@birimFiyat", entity.Birimfiyat),
                    new SqlParameter("@toplamFiyat", entity.Toplamfiyat));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static TamamlananMalzemeDal GetInstance()
        {
            if (tamamlananMalzemeDal == null)
            {
                tamamlananMalzemeDal = new TamamlananMalzemeDal();
            }
            return tamamlananMalzemeDal;
        }
    }
}
