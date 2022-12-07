using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class BarkodDal //: IRepository<Barkod>
    {
        static BarkodDal barkodDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BarkodDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Barkod entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodKayit",
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@barkodOlusturan", entity.BarkodOlusturan),
                    new SqlParameter("@sonCiktiTarihi", entity.SonCiktiTarihi));

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

        public Barkod Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodList", new SqlParameter("@id", id));
                Barkod item = null;
                while (dataReader.Read())
                {
                    item = new Barkod(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["BARKOD_OLUSTURAN"].ToString(),
                        dataReader["BARKOD_OLUSTURMA_TARIHI"].ConDate(),
                        dataReader["SON_CIKTI_TARIHI"].ConDate(),
                        dataReader["TEKRAR_ADETI"].ConInt(),
                        dataReader["SON_CIKTI_ALAN"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public Barkod BarkodKontrolList(string stokNo, string seriNo, string revizyon)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodKontrolList", new SqlParameter("@stokNo", stokNo), new SqlParameter("@seriNo", seriNo),
                    new SqlParameter("@revizyon", revizyon));
                Barkod item = null;
                while (dataReader.Read())
                {
                    item = new Barkod(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["BARKOD_OLUSTURAN"].ToString(),
                        dataReader["BARKOD_OLUSTURMA_TARIHI"].ConDate(),
                        dataReader["SON_CIKTI_TARIHI"].ConDate(),
                        dataReader["TEKRAR_ADETI"].ConInt(),
                        dataReader["SON_CIKTI_ALAN"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Barkod> GetList()
        {
            try
            {
                List<Barkod> barkods = new List<Barkod>();
                dataReader = sqlServices.StoreReader("BarkodList");
                while (dataReader.Read())
                {
                    barkods.Add(new Barkod(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["BARKOD_OLUSTURAN"].ToString(),
                        dataReader["BARKOD_OLUSTURMA_TARIHI"].ConDate(),
                        dataReader["SON_CIKTI_TARIHI"].ConDate(),
                        dataReader["TEKRAR_ADETI"].ConInt(),
                        dataReader["SON_CIKTI_ALAN"].ToString()));
                    
                }
                dataReader.Close();
                return barkods;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string BarkodTekrarCikti(Barkod entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BarkodTekrarCikti",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@sonCiktiTarihi", entity.SonCiktiTarihi),
                    new SqlParameter("@sonCiktiAlan", entity.SonCiktiAlan));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static BarkodDal GetInstance()
        {
            if (barkodDal == null)
            {
                barkodDal = new BarkodDal();
            }
            return barkodDal;
        }
    }
}
