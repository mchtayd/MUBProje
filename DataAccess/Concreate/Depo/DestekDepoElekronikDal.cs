using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Depo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Concreate.Depo
{
    public class DestekDepoElekronikDal //: IRepository<DestekDepoElekronik>
    {
        static DestekDepoElekronikDal destekDepoElekronikDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DestekDepoElekronikDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static DestekDepoElekronikDal GetInstance()
        {
            if (destekDepoElekronikDal == null)
            {
                destekDepoElekronikDal = new DestekDepoElekronikDal();
            }
            return destekDepoElekronikDal;
        }

        public string Add(DestekDepoElekronik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElektronikAdd",
                    new SqlParameter("@stokNo", entity.Stokno),
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
                sqlServices.Stored("DestekDepoElektronikDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DestekDepoElekronik Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElektronikList", new SqlParameter("@id", id));
                DestekDepoElekronik item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoElekronik(
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

        public List<DestekDepoElekronik> GetList()
        {
            try
            {
                List<DestekDepoElekronik> destekDepoElekroniks = new List<DestekDepoElekronik>();
                dataReader = sqlServices.StoreReader("DestekDepoElektronikList");
                while (dataReader.Read())
                {
                    destekDepoElekroniks.Add(new DestekDepoElekronik(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return destekDepoElekroniks;
            }
            catch (Exception)
            {
                return new List<DestekDepoElekronik>();
            };
        }

        public string Update(DestekDepoElekronik entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoElektronikUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@stokNo", entity.Stokno),
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
    }
}
