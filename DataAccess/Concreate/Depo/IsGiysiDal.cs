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
    public class IsGiysiDal // : IRepository<DestekDepoIsGiysi>
    {
        static IsGiysiDal ısGiysiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IsGiysiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoIsGiysi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiKaydet",
                    new SqlParameter("@stokno", entity.Stokno),
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
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoIsGiysi Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiList", new SqlParameter("@id", id));
                DestekDepoIsGiysi item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoIsGiysi(
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
        public DestekDepoIsGiysi GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiList", new SqlParameter("@tanim", tanim));
                DestekDepoIsGiysi item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoIsGiysi(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["BIRIM"].ToString());

                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<DestekDepoIsGiysi> GetList(int id)
        {
            try
            {
                List<DestekDepoIsGiysi> malzemeKayits = new List<DestekDepoIsGiysi>();
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoIsGiysi(
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
                return new List<DestekDepoIsGiysi>();
            }
        }

        public string Update(DestekDepoIsGiysi entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoIsGiysiGuncelle",
                    new SqlParameter("@id", id),
                    new SqlParameter("@stokno", entity.Stokno),
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
        public static IsGiysiDal GetInstance()
        {
            if (ısGiysiDal == null)
            {
                ısGiysiDal = new IsGiysiDal();
            }
            return ısGiysiDal;
        }
    }
}
