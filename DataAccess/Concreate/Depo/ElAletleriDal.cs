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
    public class ElAletleriDal // : IRepository<DestekDepoElAletleri>
    {
        static ElAletleriDal elAletleriDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ElAletleriDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(DestekDepoElAletleri entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriKaydet",
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
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoElAletleri Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriList", new SqlParameter("@id", id));
                DestekDepoElAletleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoElAletleri(
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
        public DestekDepoElAletleri GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriList", new SqlParameter("@tanim", tanim));
                DestekDepoElAletleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoElAletleri(
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
        public DestekDepoElAletleri GetStokNo(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriListStokNo", new SqlParameter("@stokNo", stokNo));
                DestekDepoElAletleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoElAletleri(
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


        public List<DestekDepoElAletleri> GetList(int id)
        {
            try
            {
                List<DestekDepoElAletleri> malzemeKayits = new List<DestekDepoElAletleri>();
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoElAletleri(
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
                return new List<DestekDepoElAletleri>();
            }
        }

        public string Update(DestekDepoElAletleri entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriGuncelle",
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
        public string FotoDuzelt(DestekDepoElAletleri entity, int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElAletleriFoto",
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static ElAletleriDal GetInstance()
        {
            if (elAletleriDal == null)
            {
                elAletleriDal = new ElAletleriDal();
            }
            return elAletleriDal;
        }
    }
}
