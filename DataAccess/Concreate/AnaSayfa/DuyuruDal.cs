using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class DuyuruDal //: IRepository<Duyuru>
    {
        static DuyuruDal duyuruDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DuyuruDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Duyuru entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuyuruAdd",
                    new SqlParameter("@konu", entity.Konu),
                    new SqlParameter("@duyuruMesaj", entity.DuyuruMesaj),
                    new SqlParameter("@tarihBaslangic", entity.BaslangicTarih),
                    new SqlParameter("@tarihBitis", entity.BitisTarih),
                    new SqlParameter("@durum", entity.Durum),
                    new SqlParameter("@duyuruYapan", entity.DuyuruYapan));

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
                sqlServices.Stored("DuyuruDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Duyuru Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuyuruList", new SqlParameter("@id", id));
                Duyuru duyuru = null;
                while (dataReader.Read())
                {
                    duyuru = new Duyuru(
                        dataReader["ID"].ConInt(),
                        dataReader["KONU"].ToString(),
                        dataReader["DUYURU_MESAJI"].ToString(),
                        dataReader["TARIH_BASLANGIC"].ConDate(),
                        dataReader["TARIH_BITIS"].ConDate(),
                        dataReader["DURUM"].ToString(),
                        dataReader["DUYURU_YAPAN"].ToString());
                }
                dataReader.Close();
                return duyuru;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Duyuru> GetList()
        {
            try
            {
                List<Duyuru> duyurus = new List<Duyuru>();
                dataReader = sqlServices.StoreReader("DuyuruList");
                while (dataReader.Read())
                {
                    duyurus.Add(new Duyuru(
                        dataReader["ID"].ConInt(),
                        dataReader["KONU"].ToString(),
                        dataReader["DUYURU_MESAJI"].ToString(),
                        dataReader["TARIH_BASLANGIC"].ConDate(),
                        dataReader["TARIH_BITIS"].ConDate(),
                        dataReader["DURUM"].ToString(),
                        dataReader["DUYURU_YAPAN"].ToString()));
                }
                dataReader.Close();
                return duyurus;
            }
            catch (Exception)
            {
                return new List<Duyuru>();
            }
        }

        public string Update(Duyuru entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DuyuruUpdate",
                    new SqlParameter("@konu", entity.Konu),
                    new SqlParameter("@duyuruMesaj", entity.DuyuruMesaj),
                    new SqlParameter("@tarihBaslangic", entity.BaslangicTarih),
                    new SqlParameter("@tarihBitis", entity.BitisTarih));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DuyuruDal GetInstance()
        {
            if (duyuruDal == null)
            {
                duyuruDal = new DuyuruDal();
            }
            return duyuruDal;
        }
    }
}
