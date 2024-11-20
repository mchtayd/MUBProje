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
    public class DestekDepoDal //: IRepository<DestekDepo>
    {
        static DestekDepoDal destekDepoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DestekDepoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static DestekDepoDal GetInstance()
        {
            if (destekDepoDal == null)
            {
                destekDepoDal = new DestekDepoDal();
            }
            return destekDepoDal;
        }

        public string Add(DestekDepo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoMalzemeAdd",
                    new SqlParameter("@malzemeTuru", entity.MalzemeTuru),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu),
                    new SqlParameter("@malzemeTakipTuru", entity.MalzemeTuru),
                    new SqlParameter("@kayitYapan", entity.KayitYapan));

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
                sqlServices.Stored("DestekDepoMalzemeDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepo Get(int id)
        {
            try
            {
                DestekDepo item = null;
                dataReader = sqlServices.StoreReader("DestekDepoMalzemeList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    item = new DestekDepo(
                        dataReader["ID"].ConInt(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["MALZEME_TAKIP_TURU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DestekDepo> GetList()
        {
            try
            {
                List<DestekDepo> destekDepos = new List<DestekDepo>();
                dataReader = sqlServices.StoreReader("DestekDepoMalzemeList");
                while (dataReader.Read())
                {
                    destekDepos.Add(new DestekDepo(dataReader["ID"].ConInt(),
                        dataReader["MALZEME_TURU"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString(),
                        dataReader["MALZEME_TAKIP_TURU"].ToString(),
                        dataReader["KAYIT_YAPAN"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate()));
                }
                dataReader.Close();
                return destekDepos;
            }
            catch (Exception)
            {
                return new List<DestekDepo>();
            }
        }

        public string Update(DestekDepo entity)
        {
            throw new NotImplementedException();
        }
    }
}
