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
    public class IsAkisNoDal //: IRepository<IsAkisNo>
    {
        static IsAkisNoDal isAkiNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IsAkisNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IsAkisNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IsAkisNo Get()
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAkisNoList");
                IsAkisNo item = null;
                while (dataReader.Read())
                {
                    item = new IsAkisNo(dataReader["ID"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<IsAkisNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                //dataReader = sqlServices.StoreReader("IsAkisNoUpdate",new SqlParameter("@isAkisNo", isAkisNo));
                dataReader = sqlServices.StoreReader("IsAkisNo");
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
        public string UpdateKontrolsuz()
        {
            try
            {
                dataReader = sqlServices.StoreReader("IsAkisNoGuncelle");
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static IsAkisNoDal GetInstance()
        {
            if (isAkiNoDal == null)
            {
                isAkiNoDal = new IsAkisNoDal();
            }
            return isAkiNoDal;
        }
    }
}
