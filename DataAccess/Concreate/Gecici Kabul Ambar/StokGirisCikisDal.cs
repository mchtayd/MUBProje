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
    public class StokGirisCikisDal //: IRepository<StokGirisCıkıs>
    {
        static StokGirisCikisDal stokGirisCikisDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private StokGirisCikisDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(StokGirisCıkıs entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisEkle",
                    new SqlParameter("@islemturu",entity.Islemturu),
                    new SqlParameter("@stokno",entity.Stokno),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@miktar",entity.Miktar),
                    new SqlParameter("@birim",entity.Birim),
                    new SqlParameter("@istenentarih",entity.Istenentarih),
                    new SqlParameter("@depono",entity.Depono),
                    new SqlParameter("@depoadresi",entity.Depoadresi),
                    new SqlParameter("@malzemeyeri",entity.Malzemeyeri),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@serino",entity.Serino),
                    new SqlParameter("@lotno",entity.Lotno),
                    new SqlParameter("@revizyon",entity.Revizyon));
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
                dataReader = sqlServices.StoreReader("StokGirisCikisSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public StokGirisCıkıs Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisList",new SqlParameter("@id",id));
                StokGirisCıkıs item = null;
                while (dataReader.Read())
                {
                    item = new StokGirisCıkıs(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConTime(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["MALZEME_YERI"].ToString(),
                        dataReader["ACIKLAMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<StokGirisCıkıs> GetList(int id)
        {
            try
            {
                List<StokGirisCıkıs> stokGirisCıkıs = new List<StokGirisCıkıs>();
                dataReader = sqlServices.StoreReader("StokGirisCikisList",new SqlParameter("@id",id));
                while (dataReader.Read())
                {
                    stokGirisCıkıs.Add(new StokGirisCıkıs(dataReader["ID"].ConInt(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ISLEM_TARIH"].ConTime(),
                        dataReader["DEPO_NO"].ToString(),
                        dataReader["DEPO_ADRESI"].ToString(),
                        dataReader["MALZEME_YERI"].ToString(),
                        dataReader["ACIKLAMA"].ToString()));
                }
                dataReader.Close();
                return stokGirisCıkıs;
            }
            catch (Exception)
            {
                return new List<StokGirisCıkıs>();
            }
        }

        public string Update(StokGirisCıkıs entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("StokGirisCikisGuncelle",
                   new SqlParameter("@id", id),
                   new SqlParameter("@islemturu", entity.Islemturu),
                   new SqlParameter("@stokno", entity.Stokno),
                   new SqlParameter("@tanim", entity.Tanim),
                   new SqlParameter("@miktar", entity.Miktar),
                   new SqlParameter("@birim", entity.Birim),
                   new SqlParameter("@istenentarih", entity.Istenentarih),
                   new SqlParameter("@depono", entity.Depono),
                   new SqlParameter("@depoadresi", entity.Depoadresi),
                   new SqlParameter("@malzemeyeri", entity.Malzemeyeri),
                   new SqlParameter("@aciklama", entity.Aciklama));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static StokGirisCikisDal GetInstance()
        {
            if (stokGirisCikisDal == null)
            {
                stokGirisCikisDal = new StokGirisCikisDal();
            }
            return stokGirisCikisDal;
        }
    }
}
