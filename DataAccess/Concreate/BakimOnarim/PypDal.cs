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
    public class PypDal // : IRepository<Pyp>
    {
        static PypDal pypDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private PypDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Pyp entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PYPKayit",
                    new SqlParameter("@pypNo",entity.PypNo),
                    new SqlParameter("@sorumluPersonel",entity.SorumluPersonel),
                    new SqlParameter("@siparisTuru",entity.SiparisTuru),
                    new SqlParameter("@islemTuru",entity.IslemTuru),
                    new SqlParameter("@hesaplamaNedeni",entity.HesaplamaNedeni));

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
                sqlServices.Stored("PYPDelete",new SqlParameter("@id",id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Pyp Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PYPList", new SqlParameter("@id",id));
                Pyp item = null;
                while (dataReader.Read())
                {
                    item = new Pyp(
                        dataReader["ID"].ConInt(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA_NEDENI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pyp> GetList()
        {
            try
            {
                List<Pyp> pyps = new List<Pyp>();
                dataReader = sqlServices.StoreReader("PYPList");
                while (dataReader.Read())
                {
                    pyps.Add(new Pyp(
                        dataReader["ID"].ConInt(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_PERSONEL"].ToString(),
                        dataReader["SIPARIS_TURU"].ToString(),
                        dataReader["ISLEM_TURU"].ToString(),
                        dataReader["HESAPLAMA_NEDENI"].ToString()));
                }
                dataReader.Close();
                return pyps;
            }
            catch (Exception ex)
            {
                return new List<Pyp>();
            }
        }

        public string Update(Pyp entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PYPGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluPersonel", entity.SorumluPersonel),
                    new SqlParameter("@siparisTuru", entity.SiparisTuru),
                    new SqlParameter("@islemTuru", entity.IslemTuru),
                    new SqlParameter("@hesaplamaNedeni", entity.HesaplamaNedeni));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PypDal GetInstance()
        {
            if (pypDal == null)
            {
                pypDal = new PypDal();
            }
            return pypDal;
        }
    }
}
