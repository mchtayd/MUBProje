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
    public class ButceKoduDal // : IRepository<ButceKodu>
    {
        static ButceKoduDal butceKoduDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ButceKoduDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(ButceKodu entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceKoduKalemiEkle",
                    new SqlParameter("@butceKoduKalemi",entity.ButceKoduKalemi),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@giderKarsiyalacakFirma",entity.GiderKarsilayacakFirma));

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
                sqlServices.Stored("ButceKoduKalemiSil",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ButceKodu Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceKoduKalemiListele",new SqlParameter("@id",id));
                ButceKodu item = null;
                while (dataReader.Read())
                {
                    item = new ButceKodu(
                        dataReader["ID"].ConInt(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["GIDER_KARSILAYACAK_FIRMA"].ToString(),
                        dataReader["COMBO_ID"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ButceKodu ButceKoduComboBilgiList(string baslik)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceKoduComboIdList", new SqlParameter("@baslik", baslik));
                ButceKodu item = null;
                while (dataReader.Read())
                {
                    item = new ButceKodu(
                        dataReader["ID"].ConInt(),
                        dataReader["BASLIK"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ButceKodu> GetList()
        {
            try
            {
                List<ButceKodu> butceKodus = new List<ButceKodu>();
                dataReader = sqlServices.StoreReader("ButceKoduKalemiListele");
                while (dataReader.Read())
                {
                    butceKodus.Add(new ButceKodu(
                        dataReader["ID"].ConInt(),
                        dataReader["BUTCE_KODU_KALEMI"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["GIDER_KARSILAYACAK_FIRMA"].ToString(),
                        dataReader["COMBO_ID"].ToString()));
                }
                dataReader.Close();
                return butceKodus;
            }
            catch (Exception)
            {
                return new List<ButceKodu>();
            }
        }

        public string Update(ButceKodu entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ButceKoduKalemiGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@butceKoduKalemi",entity.ButceKoduKalemi),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@giderKarsilayacakFirma",entity.GiderKarsilayacakFirma),
                    new SqlParameter("@comboId",entity.ComboId));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ButceKoduDal GetInstance()
        {
            if (butceKoduDal == null)
            {
                butceKoduDal = new ButceKoduDal();
            }
            return butceKoduDal;
        }
    }
}
