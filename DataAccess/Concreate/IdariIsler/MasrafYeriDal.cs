using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class MasrafYeriDal // : IRepository<MasrafYeri>
    {
        static MasrafYeriDal masrafYeriDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MasrafYeriDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(MasrafYeri entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MAsrafYeriEkle",
                    new SqlParameter("@masrafYeriNo",entity.MasrafYeriNo),
                    new SqlParameter("@masrafYeri",entity.MasrafYeriBilgi));
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
                sqlServices.Stored("MAsrafYeriSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public MasrafYeri Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MAsrafYeriList", new SqlParameter("@id", id));
                MasrafYeri item = null;
                while (dataReader.Read())
                {
                    item = new MasrafYeri(
                        dataReader["ID"].ConInt(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MasrafYeri> GetList()
        {
            try
            {
                List<MasrafYeri> masrafYeris = new List<MasrafYeri>();
                dataReader = sqlServices.StoreReader("MAsrafYeriList");
                while (dataReader.Read())
                {
                    masrafYeris.Add(new MasrafYeri(
                        dataReader["ID"].ConInt(),
                        dataReader["MASRAF_YERI_NO"].ToString(),
                        dataReader["MASRAF_YERI"].ToString()));
                }
                dataReader.Close();
                return masrafYeris;
            }
            catch (Exception)
            {
                return new List<MasrafYeri>();
            }
        }

        public string Update(MasrafYeri entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MAsrafYeriGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@masrafYeriNo",entity.MasrafYeriNo),
                    new SqlParameter("@masrafYeri",entity.MasrafYeriBilgi));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static MasrafYeriDal GetInstance()
        {
            if (masrafYeriDal == null)
            {
                masrafYeriDal = new MasrafYeriDal();
            }
            return masrafYeriDal;
        }
    }
}
