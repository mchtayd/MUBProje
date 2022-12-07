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
    public class TemizlikUrunleriDal // : IRepository<DestekDepoTemizlikUrunleri>
    {
        static TemizlikUrunleriDal temizlikUrunleriDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private TemizlikUrunleriDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoTemizlikUrunleri entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoTemizklikUrunleriKaydet",
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
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoTemizlikUrunleri Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriList", new SqlParameter("@id", id));
                DestekDepoTemizlikUrunleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoTemizlikUrunleri(
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
        public DestekDepoTemizlikUrunleri GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriList", new SqlParameter("@tanim", tanim));
                DestekDepoTemizlikUrunleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoTemizlikUrunleri(
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
        public DestekDepoTemizlikUrunleri GetStokNo(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriListStokNo", new SqlParameter("@stokNo", stokNo));
                DestekDepoTemizlikUrunleri item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoTemizlikUrunleri(
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

        public List<DestekDepoTemizlikUrunleri> GetList(int id)
        {
            try
            {
                List<DestekDepoTemizlikUrunleri> malzemeKayits = new List<DestekDepoTemizlikUrunleri>();
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoTemizlikUrunleri(
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
                return new List<DestekDepoTemizlikUrunleri>();
            }
        }

        public string Update(DestekDepoTemizlikUrunleri entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoTemizlikUrunleriGuncelle",
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
        public static TemizlikUrunleriDal GetInstance()
        {
            if (temizlikUrunleriDal == null)
            {
                temizlikUrunleriDal = new TemizlikUrunleriDal();
            }
            return temizlikUrunleriDal;
        }
    }
}
