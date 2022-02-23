using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class GorevAtamaPersonelDal //: IRepository<GorevAtamaPersonel>
    {
        static GorevAtamaPersonelDal gorevAtamaPersonelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private GorevAtamaPersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(GorevAtamaPersonel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelEkle",
                    new SqlParameter("@benzersiz", entity.BenzersizId),
                    new SqlParameter("@departman", entity.Departman),
                    new SqlParameter("@gorevAtanacakPersonel", entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@yapilanIslemler", entity.YapilanIslem),
                    new SqlParameter("@calismaSuresi", entity.CalismaSuresi));

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
                sqlServices.Stored("GorevAtananIslemAdimiSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public GorevAtamaPersonel Get(int benzersiz, string departman)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelListele",
                    new SqlParameter("@benzersiz", benzersiz), new SqlParameter("@departman", departman));
                GorevAtamaPersonel item = null;
                while (dataReader.Read())
                {
                    item = new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevAtananIslemAdimlariList",
                    new SqlParameter("@benzersiz", benzersiz), new SqlParameter("@depoartman", departman));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaGetList(int benzersizId)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("IslemAdimSureleriniDuzelt",new SqlParameter("@benzersizId",benzersizId));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaPersonelGor(int benzersiz, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("PersonelGorevAtamaGor",
                    new SqlParameter("@benzersizId", benzersiz), new SqlParameter("@departman", departman));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> AtolyeGorevlerimiGor(string adSoyad)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                return new List<GorevAtamaPersonel>();
            }
        }

        public string Update(GorevAtamaPersonel entity, string yapilanIslemler)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelSureGuncelle",
                    new SqlParameter("@benzersiz", entity.BenzersizId),
                    new SqlParameter("@departman", entity.Departman),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@sure", entity.Sure),
                    new SqlParameter("@calismaSuresi", entity.CalismaSuresi),
                    new SqlParameter("@yapilanIslemler", yapilanIslemler));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SureDuzelt(int id,string sure)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeIslemAdimlariSureDuzelt",
                    new SqlParameter("@id", id),
                    new SqlParameter("@sure", sure));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaPersonelDal GetInstance()
        {
            if (gorevAtamaPersonelDal == null)
            {
                gorevAtamaPersonelDal = new GorevAtamaPersonelDal();
            }
            return gorevAtamaPersonelDal;
        }
    }
}
