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
    public class CayOcagiDal // : IRepository<DestekDepoCayOcagi>
    {
        static CayOcagiDal cayOcagiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private CayOcagiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DestekDepoCayOcagi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoCayOcagiKaydet",
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
                dataReader = sqlServices.StoreReader("DestekDepoCayOcagiSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public DestekDepoCayOcagi Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepocayOcagiList", new SqlParameter("@id", id));
                DestekDepoCayOcagi item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoCayOcagi(
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
        public DestekDepoCayOcagi GetTanim(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepocayOcagiList", new SqlParameter("@tanim", tanim));
                DestekDepoCayOcagi item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoCayOcagi(
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
        public DestekDepoCayOcagi GetStokNo(string stokNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepocayOcagiListStokNo", new SqlParameter("@stok", stokNo));
                DestekDepoCayOcagi item = null;
                while (dataReader.Read())
                {
                    item = new DestekDepoCayOcagi(
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

        public List<DestekDepoCayOcagi> GetList(int id)
        {
            try
            {
                List<DestekDepoCayOcagi> malzemeKayits = new List<DestekDepoCayOcagi>();
                dataReader = sqlServices.StoreReader("DestekDepocayOcagiList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    malzemeKayits.Add(new DestekDepoCayOcagi(
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
                return new List<DestekDepoCayOcagi>();
            }
        }

        public string Update(DestekDepoCayOcagi entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DestekDepoCayOcagiGuncelle",
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
        public static CayOcagiDal GetInstance()
        {
            if (cayOcagiDal == null)
            {
                cayOcagiDal = new CayOcagiDal();
            }
            return cayOcagiDal;
        }
    }
}
