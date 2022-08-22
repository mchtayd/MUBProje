using DataAccess.Abstract;
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
    public class LoginDal //: IRepository<Login>
    {
        static LoginDal loginDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private LoginDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(Login entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("LoginEkle",
                    new SqlParameter("@personelId", entity.PersonelId),
                    new SqlParameter("@sicilNo", entity.SicilNo),
                    new SqlParameter("@sifre", entity.Sifre));

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

        public Login Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Login> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(Login entity)
        {
            throw new NotImplementedException();
        }
        public static LoginDal GetInstance()
        {
            if (loginDal == null)
            {
                loginDal = new LoginDal();
            }
            return loginDal;
        }
    }
}
