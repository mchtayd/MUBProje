using DataAccess.Abstract;
using DataAccess.Database;
using Entity.BakimOnarim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.BakimOnarim
{
    public class IscilikDestekTabloAracDal // : IRepository<IscilikDestekTabloArac>
    {
        static IscilikDestekTabloAracDal aracDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IscilikDestekTabloAracDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(IscilikDestekTabloArac entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikAracEkle",
                    new SqlParameter("@plaka",entity.Plaka),
                    new SqlParameter("@bolum",entity.KullanildigiBolum),
                    new SqlParameter("@siparisNo",entity.SiparisNo));

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
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikAracSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IscilikDestekTabloArac Get(string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikList", new SqlParameter("@siparisNo", siparisNo));
                IscilikDestekTabloArac item = null;
                while (dataReader.Read())
                {
                    item = new IscilikDestekTabloArac(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["KULLANIDIGI_BOLUM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<IscilikDestekTabloArac> GetList()
        {
            try
            {
                List<IscilikDestekTabloArac> ıscilikDestekIsciliks = new List<IscilikDestekTabloArac>();
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikList");
                while (dataReader.Read())
                {
                    ıscilikDestekIsciliks.Add(new IscilikDestekTabloArac(
                        dataReader["ID"].ConInt(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["KULLANIDIGI_BOLUM"].ToString(),
                        dataReader["SIPARIS_NO"].ToString()));
                }
                dataReader.Close();
                return ıscilikDestekIsciliks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Update(IscilikDestekTabloArac entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IscilikDestekIscilikAracGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@bolum", entity.KullanildigiBolum),
                    new SqlParameter("@siparisNo", entity.SiparisNo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IscilikDestekTabloAracDal GetInstance()
        {
            if (aracDal == null)
            {
                aracDal = new IscilikDestekTabloAracDal();
            }
            return aracDal;
        }
    }
}
