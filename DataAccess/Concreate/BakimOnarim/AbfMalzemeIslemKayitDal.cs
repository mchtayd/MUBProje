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
    public class AbfMalzemeIslemKayitDal //: IRepository<AbfMalzemeIslemKayit>
    {
        static AbfMalzemeIslemKayitDal abfMalzemeIslemKayitDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AbfMalzemeIslemKayitDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static AbfMalzemeIslemKayitDal GetInstance()
        {
            if (abfMalzemeIslemKayitDal == null)
            {
                abfMalzemeIslemKayitDal = new AbfMalzemeIslemKayitDal();
            }
            return abfMalzemeIslemKayitDal;
        }

        public string Add(AbfMalzemeIslemKayit entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeIslemKayitlariAdd",
                    new SqlParameter("@benzersizId", entity.BenzersizId),
                    new SqlParameter("@islem", entity.Islem),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@islemYapan", entity.IslemYapan),
                    new SqlParameter("@gecenSure", entity.GecenSure),
                    new SqlParameter("@malzemeDurum", entity.MalzemeDurumu),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@revizyon", entity.Revizyon));

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

        public AbfMalzemeIslemKayit Get(int benzersizId,string islem, string stokNo,string seriNo,string revizyon)
        {
            try
            {
                AbfMalzemeIslemKayit item = null;
                dataReader = sqlServices.StoreReader("MalzemeIslemKayitlariGet", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@islem", islem), new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon));
                while (dataReader.Read())
                {
                    item = new AbfMalzemeIslemKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["ISLEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["GECEN_SURE"].ConInt(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfMalzemeIslemKayit> GetList(int benzersizId, string malzemeDurumu)
        {
            try
            {
                List<AbfMalzemeIslemKayit> abfMalzemeIslemKayits = new List<AbfMalzemeIslemKayit>();
                dataReader = sqlServices.StoreReader("MalzemeIslemKayitlariGetList", new SqlParameter("@benzersizId", benzersizId), new SqlParameter("@malzemeDurumu", malzemeDurumu));
                while (dataReader.Read())
                {
                    abfMalzemeIslemKayits.Add(new AbfMalzemeIslemKayit(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["ISLEM"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["ISLEM_YAPAN"].ToString(),
                        dataReader["GECEN_SURE"].ConInt(),
                        dataReader["MALZEME_DURUMU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString()));
                }
                dataReader.Close();
                return abfMalzemeIslemKayits;
            }

            catch (Exception)
            {
                return new List<AbfMalzemeIslemKayit>();
            }
        }

        public string Update(int id, int gecenSure)
        {
            try
            {
                sqlServices.Stored("MalzemeIslemKayitlariUpdate", new SqlParameter("@id", id), new SqlParameter("@gecenSure", gecenSure));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string MalzemeIslemKayitUpdate(int id, string stokNo,string seriNo,string revizyon)
        {
            try
            {
                sqlServices.Stored("MalzemeIslemKayitUpdate", new SqlParameter("@id", id), new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo), new SqlParameter("@revizyon", revizyon));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
