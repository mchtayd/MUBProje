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
    public class BildirimYetkiDal //: IRepository<BildirimYetki>
    {
        static BildirimYetkiDal bildirimYetkiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BildirimYetkiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(BildirimYetki entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BildirimYetkiAdd",
                    new SqlParameter("@personelAd",entity.Personel),
                    new SqlParameter("@personelId",entity.PersonelId),
                    new SqlParameter("@sorumluId",entity.SorumluId));

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
                sqlServices.Stored("BildirimYetkiDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BildirimYetki Get(string @personeAd)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BildirimYetkiList", new SqlParameter("@personeAd", personeAd));
                BildirimYetki item = null;
                while (dataReader.Read())
                {
                    item = new BildirimYetki(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SORUMLU_ID"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BildirimYetki> GetList(string personelAd)
        {
            try
            {
                List<BildirimYetki> bildirimYetkis = new List<BildirimYetki>();
                dataReader = sqlServices.StoreReader("BildirimYetkiList", new SqlParameter("@personeAd", personelAd));
                while (dataReader.Read())
                {
                    bildirimYetkis.Add(new BildirimYetki(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_AD"].ToString(),
                        dataReader["PERSONEL_ID"].ConInt(),
                        dataReader["SORUMLU_ID"].ToString()));

                }
                dataReader.Close();
                return bildirimYetkis;
            }
            catch (Exception)
            {
                return new List<BildirimYetki>();
            }
        }

        public string Update(BildirimYetki entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BildirimYetkiUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@personelAd", entity.Personel),
                    new SqlParameter("@personelId", entity.PersonelId),
                    new SqlParameter("@sorumluId", entity.SorumluId));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static BildirimYetkiDal GetInstance()
        {
            if (bildirimYetkiDal == null)
            {
                bildirimYetkiDal = new BildirimYetkiDal();
            }
            return bildirimYetkiDal;
        }
    }
}
