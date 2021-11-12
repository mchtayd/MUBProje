using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Depo
{
    public class KimyasalUrunlerDal //: IRepository<DestekDepoKimyasalUrunler>
    {
        static KimyasalUrunlerDal kimyasalUrunlerDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KimyasalUrunlerDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoKimyasalUrunler entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKimyasalUrunlerEkle",
                    new SqlParameter("@stokno", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim));
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
                dataReader = sqlServices.StoreReader("DestekDepoKimyasalUrunlerSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoKimyasalUrunler Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKimyasalUrunlerList", new SqlParameter("@id", id));
                DestekDepoKimyasalUrunler item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKimyasalUrunler(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepoKimyasalUrunler> GetList(int id)
        {
            try
            {
                List<DestekDepoKimyasalUrunler> malzemeKayits = new List<DestekDepoKimyasalUrunler>();
                dataReader = sqlServices.StoreReader("DestekDepoKimyasalUrunlerList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoKimyasalUrunler(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception ex)
            {
                return new List<DestekDepoKimyasalUrunler>();
            }
        }

        public string Update(DestekDepoKimyasalUrunler entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKimyasalUrunlerGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokno", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static KimyasalUrunlerDal GetInstance()
        {
            if (kimyasalUrunlerDal == null)
            {
                kimyasalUrunlerDal = new KimyasalUrunlerDal();
            }
            return kimyasalUrunlerDal;
        }
    }
}
