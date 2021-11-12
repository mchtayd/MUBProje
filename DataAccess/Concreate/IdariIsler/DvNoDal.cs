using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DvNoDal //: IRepository<DvNo>
    {
        static DvNoDal dvNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DvNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DvNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DvNo Get()
        {
            try
            {
                dataReader = sqlServices.StoreReader("DvNoGoster");
                DvNo item = null;
                while (dataReader.Read())
                {
                    item = new DvNo(dataReader["NUMARA"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DvNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                dataReader = sqlServices.StoreReader("DvNoArttir");
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string UpdateAzalt()
        {
            try
            {
                dataReader = sqlServices.StoreReader("DvNoAzalt");
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DvNoDal GetInstance()
        {
            if (dvNoDal == null)
            {
                dvNoDal = new DvNoDal();
            }
            return dvNoDal;
        }
    }
}
