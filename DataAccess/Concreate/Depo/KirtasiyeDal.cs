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
    public class KirtasiyeDal // : IRepository<DestekDepoKirtasiye>
    {
        static KirtasiyeDal kirtasiyeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KirtasiyeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoKirtasiye entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeKaydet",
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

        public string Delete(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoKirtasiye Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeList", new SqlParameter("@id", id));
                DestekDepoKirtasiye item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKirtasiye(
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
        public DestekDepoKirtasiye GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeList", new SqlParameter("@tanim", tanim));
                DestekDepoKirtasiye item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKirtasiye(
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
        public DestekDepoKirtasiye GetStokNo(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeListStokNo", new SqlParameter("@stokNo", stokNo));
                DestekDepoKirtasiye item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoKirtasiye(
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

        public List<DestekDepoKirtasiye> GetList(int id)
        {
            try
            {
                List<DestekDepoKirtasiye> malzemeKayits = new List<DestekDepoKirtasiye>();
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoKirtasiye(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return malzemeKayits;
            }
            catch (Exception)
            {
                return new List<DestekDepoKirtasiye>();
            }
        }

        public string Update(DestekDepoKirtasiye entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoKirtasiyeGuncelle",
                    new SqlParameter("@id", id),
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
        public static KirtasiyeDal GetInstance()
        {
            if (kirtasiyeDal == null)
            {
                kirtasiyeDal = new KirtasiyeDal();
            }
            return kirtasiyeDal;
        }
    }
}
