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
    public class AtolyeAltMalzemeDal //: IRepository<AtolyeAltMalzeme>
    {
        static AtolyeAltMalzemeDal atolyeAltMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AtolyeAltMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AtolyeAltMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeMalzemeler",
                    new SqlParameter("@stokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@sokulenSeriNo",entity.SokulenSeriNo),
                    new SqlParameter("@takilanSeriNo",entity.TakilanSeriNo),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@sayac",entity.Sayac),
                    new SqlParameter("@revizyon",entity.Revizyon),
                    new SqlParameter("@malzemeyeYapilanIslem",entity.MalzemeyeYapilanIslem),
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

        public AtolyeAltMalzeme Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<AtolyeAltMalzeme> GetList(string siparisNo)
        {
            try
            {
                List<AtolyeAltMalzeme> atolyeAltMalzemes = new List<AtolyeAltMalzeme>();
                dataReader = sqlServices.StoreReader("AtolyeMalzemelerListele",new SqlParameter("@siparisNo",siparisNo));
                while (dataReader.Read())
                {
                    atolyeAltMalzemes.Add(new AtolyeAltMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SOKULEN_SERI_NO"].ToString(),
                        dataReader["TAKILAN_SERI_NO"].ToString(),
                        dataReader["MIKTAR"].ConDouble(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["SAYAC"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MALZEMEYE_YAPILAN_ISLEM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return atolyeAltMalzemes;

            }
            catch (Exception)
            {
                return new List<AtolyeAltMalzeme>();
            }
        }

        public string Update(AtolyeAltMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeMalzemelerGuncelle",
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@sokulenSeriNo", entity.SokulenSeriNo),
                    new SqlParameter("@takilanSeriNo", entity.TakilanSeriNo),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@sayac", entity.Sayac),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@malzemeyeYapilanIslem", entity.MalzemeyeYapilanIslem),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AtolyeAltMalzemeDal GetInstance()
        {
            if (atolyeAltMalzemeDal == null)
            {
                atolyeAltMalzemeDal = new AtolyeAltMalzemeDal();
            }
            return atolyeAltMalzemeDal;
        }
    }
}
