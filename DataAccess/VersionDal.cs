using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VersionDal // : IRepository<VersionBilgi>
    {
        static VersionDal versionDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private VersionDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(VersionBilgi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtsVersionEkle",
                    new SqlParameter("@version",entity.VersionNo),
                    new SqlParameter("@dosyayolu",entity.Dosyayolu));
                
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

        public VersionBilgi Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<VersionBilgi> GetList()
        {
            try
            {
                List<VersionBilgi> versionBilgis = new List<VersionBilgi>();
                dataReader = sqlServices.StoreReader("DtsVersionList");
                while (dataReader.Read())
                {
                    versionBilgis.Add(new VersionBilgi(
                        dataReader["ID"].ConInt(), 
                        dataReader["VERSION"].ToString(),
                        dataReader["DOSYAYOLU"].ToString()));
                }
                dataReader.Close();
                return versionBilgis;
            }
            catch (Exception EX)
            {
                return new List<VersionBilgi>();
            }
        }

        public string Update(VersionBilgi entity)
        {
            throw new NotImplementedException();
        }
        public static VersionDal GetInstance()
        {
            if (versionDal == null)
            {
                versionDal = new VersionDal();
            }
            return versionDal;
        }
    }
}
