using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarimAtolye;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarimAtolye
{
    public class AtolyeMalzemeDal //: IRepository<AtolyeMalzeme>
    {
        static AtolyeMalzemeDal atolyeMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AtolyeMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AtolyeMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BakimOnarimMalzemeKayit",
                    new SqlParameter("@formNo", entity.FormNo),
                    new SqlParameter("@sokulenStokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@sokulenSeriNo",entity.SeriNo),
                    new SqlParameter("@durum",entity.Durum),
                    new SqlParameter("@revizyon",entity.Revizyon),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@talepTarihi",entity.TalepTarihi),
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

        public AtolyeMalzeme Get(int abfNo)
        {
            throw new NotImplementedException();
        }

        public List<AtolyeMalzeme> GetList(int abfNo)
        {
            try
            {
                List<AtolyeMalzeme> atolyeMalzemes = new List<AtolyeMalzeme>();
                dataReader = sqlServices.StoreReader("AtolyeAbfMalzemeBul", new SqlParameter("@abfNo", abfNo));
                while (dataReader.Read())
                {
                    atolyeMalzemes.Add(new AtolyeMalzeme(
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["STOK_NO_CIKAN"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO_CIKAN"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["BIRIM"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public List<AtolyeMalzeme> AtolyeBakimOnarimMalzeme()
        {
            try
            {
                List<AtolyeMalzeme> atolyeMalzemes = new List<AtolyeMalzeme>();
                dataReader = sqlServices.StoreReader("AtolyeBakimMalzeme");
                while (dataReader.Read())
                {
                    atolyeMalzemes.Add(new AtolyeMalzeme(
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<AtolyeMalzeme> AtolyeMalzemeBul(string siparisNo)
        {
            try
            {
                List<AtolyeMalzeme> atolyeMalzemes = new List<AtolyeMalzeme>();
                dataReader = sqlServices.StoreReader("AtolyeMalzemeBul", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    atolyeMalzemes.Add(new AtolyeMalzeme(
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception ex)
            {
                return new List<AtolyeMalzeme>();
            }
        }

        public string Update(AtolyeMalzeme entity)
        {
            throw new NotImplementedException();
        }
        public static AtolyeMalzemeDal GetInstance()
        {
            if (atolyeMalzemeDal == null)
            {
                atolyeMalzemeDal = new AtolyeMalzemeDal();
            }
            return atolyeMalzemeDal;
        }
    }
}
