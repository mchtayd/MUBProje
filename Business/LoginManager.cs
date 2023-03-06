using DataAccess;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginManager // : IRepository<Login>
    {
        static LoginManager loginManager;
        LoginDal loginDal;


        private LoginManager()
        {
            loginDal = LoginDal.GetInstance();
        }

        public string Add(Login entity)
        {
            try
            {
                return loginDal.Add(entity);
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
        public static LoginManager GetInstance()
        {
            if (loginManager == null)
            {
                loginManager = new LoginManager();
            }
            return loginManager;
        }
    }
}
