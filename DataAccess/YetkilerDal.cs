using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class YetkilerDal //: IRepository<Yetki>
    {
        static YetkilerDal yetkilerDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private YetkilerDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Yetki entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YetkilerEkle",
                    new SqlParameter("@name", entity.Name),
                    new SqlParameter("@izinIdler", entity.IzinIdleri));

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

        public Yetki Get(string isim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YetkileriCek", new SqlParameter("@isim", isim));
                Yetki item = null;
                while (dataReader.Read())
                {
                    item = new Yetki(dataReader["Id"].ConInt(), dataReader["Name"].ToString(), dataReader["Izin_Idleri"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Yetki> GetList()
        {
            try
            {
                List<Yetki> yetkilers = new List<Yetki>();
                dataReader = sqlServices.StoreReader("YetkileriCek");
                while (dataReader.Read())
                {
                    Yetki yetkiler = new Yetki(dataReader["Id"].ConInt(), dataReader["Name"].ToString(), dataReader["Izin_Idleri"].ToString());
                    yetkilers.Add(yetkiler);
                }
                dataReader.Close();
                return yetkilers;
            }
            catch
            {
                return new List<Yetki>();
            }
        }

        public string Update(Yetki entity,int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("YetkiGuncelle",
                    new SqlParameter("@id",id),
                    new SqlParameter("@izinler",entity.IzinIdleri));
                
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static YetkilerDal GetInstance()
        {
            if (yetkilerDal == null)
            {
                yetkilerDal = new YetkilerDal();
            }
            return yetkilerDal;
        }
    }
}
