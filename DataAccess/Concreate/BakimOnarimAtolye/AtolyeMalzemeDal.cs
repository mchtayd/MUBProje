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

        public AtolyeMalzeme Get(string stokNo,string seriNo,string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeMalzemeGet", new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon));
                AtolyeMalzeme atolyeMalzeme = null;
                while (dataReader.Read())
                {
                    atolyeMalzeme = new AtolyeMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TESLIM_DURUMU"].ToString()); 
                }
                dataReader.Close();
                return atolyeMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
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
                return null;
            }
        }
        public List<AtolyeMalzeme> GetListDTS(int abfNo)
        {
            try
            {
                List<AtolyeMalzeme> atolyeMalzemes = new List<AtolyeMalzeme>();
                dataReader = sqlServices.StoreReader("AtolyeAbfMalzemeBulDTS", new SqlParameter("@abfNo", abfNo));
                while (dataReader.Read())
                {
                    atolyeMalzemes.Add(new AtolyeMalzeme(
                        dataReader["ABF_FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["SOKULEN_TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["YAPILACAK_ISLEM"].ToString(),
                        dataReader["SOKULEN_REVIZYON_NO"].ToString(),
                        dataReader["SOKULEN_MIKTAR"].ConDouble(),
                        dataReader["AB_TARIH_SAAT"].ConDate(),
                        dataReader["SOKULEN_BIRIM"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception ex)
            {
                return null;
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
                        dataReader["ID"].ConInt(),
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TESLIM_DURUMU"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception)
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
                        dataReader["ID"].ConInt(),
                        dataReader["FORM_NO"].ConInt(),
                        dataReader["SOKULEN_STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["TESLIM_DURUMU"].ToString()));
                }
                dataReader.Close();
                return atolyeMalzemes;
            }
            catch (Exception)
            {
                return new List<AtolyeMalzeme>();
            }
        }

        public string Update(int id, string teslimDurumu)
        {
            try
            {
                sqlServices.Stored("AtolyeMalzemeTeslimiupdate", new SqlParameter("@id", id), new SqlParameter("@teslimDurumu", teslimDurumu));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
