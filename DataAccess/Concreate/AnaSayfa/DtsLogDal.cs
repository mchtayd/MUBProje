using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class DtsLogDal //: IRepository<DtsLog>
    {
        static DtsLogDal dtsLogDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DtsLogDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static DtsLogDal GetInstance()
        {
            if (dtsLogDal == null)
            {
                dtsLogDal = new DtsLogDal();
            }
            return dtsLogDal;
        }

        public string Add(DtsLog entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DTSLogKayit",
                    new SqlParameter("@personelAdi", entity.PersonelAdi),
                    new SqlParameter("@islemTarihi",entity.IslemTarihi),
                    new SqlParameter("@sayfa",entity.Sayfa),
                    new SqlParameter("@islem",entity.Islem));

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
            throw new NotImplementedException();
        }

        public DtsLog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DtsLog> GetList(string personelAdi,DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                List<DtsLog> list = new List<DtsLog>();
                dataReader = sqlServices.StoreReader("DTSLogKayitList",
                    new SqlParameter("@personelAdi", personelAdi),
                    new SqlParameter("@basTarihi", basTarihi),
                    new SqlParameter("@bitTarihi", bitTarihi));

                while (dataReader.Read())
                {
                    list.Add(new DtsLog(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["ISLEM_TARIHI"].ConDate(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ISLEM"].ToString()));
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }
        public List<DtsLog> GetListIslem(string personelAdi, DateTime basTarihi, DateTime bitTarihi, string islem)
        {
            try
            {
                List<DtsLog> list = new List<DtsLog>();
                dataReader = sqlServices.StoreReader("DTSLogKayitListIslem",
                    new SqlParameter("@personelAdi", personelAdi),
                    new SqlParameter("@basTarihi", basTarihi),
                    new SqlParameter("@bitTarihi", bitTarihi),
                    new SqlParameter("@islem", islem));

                while (dataReader.Read())
                {
                    list.Add(new DtsLog(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["ISLEM_TARIHI"].ConDate(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ISLEM"].ToString()));
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }

        public List<DtsLog> GetListTumu(DateTime basTarihi, DateTime bitTarihi)
        {
            try
            {
                List<DtsLog> list = new List<DtsLog>();
                dataReader = sqlServices.StoreReader("DTSLogKayitListTumu", new SqlParameter("@basTarihi", basTarihi), new SqlParameter("@bitTarihi", bitTarihi));

                while (dataReader.Read())
                {
                    list.Add(new DtsLog(
                        dataReader["ID"].ConInt(),
                        dataReader["PERSONEL_ADI"].ToString(),
                        dataReader["ISLEM_TARIHI"].ConDate(),
                        dataReader["SAYFA"].ToString(),
                        dataReader["ISLEM"].ToString()));
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<DtsLog>();
            }
        }


        public string Update(DtsLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
