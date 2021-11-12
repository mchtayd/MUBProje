using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TekilflerOnaylananDal
    {
        static TekilflerOnaylananDal tekilflerOnaylananDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private TekilflerOnaylananDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(TekliflerOnaylanan entity,string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifOnaylanan", new SqlParameter("@bf1", entity.Brf1), new SqlParameter("@bt1", entity.Btf1),
                    new SqlParameter("@if2", entity.Brf2), new SqlParameter("@it2", entity.Btf2), new SqlParameter("@uf3", entity.Brf3), new SqlParameter("@ut3", entity.Btf3),
                    new SqlParameter("@siparisno", siparisNo));

                dataReader.Close();
                return "";
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

        public TekliflerOnaylanan Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<TekliflerOnaylanan> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(TekliflerOnaylanan entity)
        {
            throw new NotImplementedException();
        }
        public static TekilflerOnaylananDal GetInstance()
        {
            if (tekilflerOnaylananDal == null)
            {
                tekilflerOnaylananDal = new TekilflerOnaylananDal();
            }
            return tekilflerOnaylananDal;
        }
    }
}
