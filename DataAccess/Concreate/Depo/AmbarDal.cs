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
    public class AmbarDal // : IRepository<DestekDepoAmbar>
    {
        static AmbarDal ambarDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AmbarDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoAmbar entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoAmbarKaydet",
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
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
                dataReader = sqlServices.StoreReader("DestekDepoAmbarSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoAmbar Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoAmbarList", new SqlParameter("@id", id));
                DestekDepoAmbar item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoAmbar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DestekDepoAmbar GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoAmbarList", new SqlParameter("@tanim", tanim));
                DestekDepoAmbar item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoAmbar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DestekDepoAmbar GetStok(string stok)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoAmbarListStok", new SqlParameter("@stok", stok));
                DestekDepoAmbar item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoAmbar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DestekDepoAmbar> GetList(int id)
        {
            try
            {
                List<DestekDepoAmbar> malzemeKayits = new List<DestekDepoAmbar>();
                dataReader = sqlServices.StoreReader("DestekDepoAmbarList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoAmbar(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception ex)
            {
                return new List<DestekDepoAmbar>();
            }
        }

        public string Update(DestekDepoAmbar entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoAmbarGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokno", entity.Stokno),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static AmbarDal GetInstance()
        {
            if (ambarDal == null)
            {
                ambarDal = new AmbarDal();
            }
            return ambarDal;
        }
    }
}
