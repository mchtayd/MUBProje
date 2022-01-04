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
    public class AbfFormNoDal // : IRepository<AbfFormNo>
    {
        static AbfFormNoDal abfFormNoDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AbfFormNoDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(AbfFormNo entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AbfFormNo Get()
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfFormList");
                AbfFormNo item = null;
                while (dataReader.Read())
                {
                    item = new AbfFormNo(dataReader["FORM_NO"].ConInt());
                }
                dataReader.Close();
                return item;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AbfFormNo> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            try
            {
                dataReader = sqlServices.StoreReader("AbfFormGuncelle");
                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static AbfFormNoDal GetInstance()
        {
            if (abfFormNoDal == null)
            {
                abfFormNoDal = new AbfFormNoDal();
            }
            return abfFormNoDal;
        }
    }
}
