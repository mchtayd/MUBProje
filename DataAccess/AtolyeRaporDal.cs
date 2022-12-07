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
    public class AtolyeRaporDal //: IRepository<AtolyeRapor>
    {
        static AtolyeRaporDal atolyeRaporDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private AtolyeRaporDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(AtolyeRapor entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AtolyeRapor Get()
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeIslemAdimlariRapor");
                AtolyeRapor item = null;
                while (dataReader.Read())
                {
                    item = new AtolyeRapor(
                        dataReader["400"].ConInt(),
                        dataReader["500"].ConInt(),
                        dataReader["600"].ConInt(),
                        dataReader["700"].ConInt(),
                        dataReader["800"].ConInt(),
                        dataReader["900"].ConInt(),
                        dataReader["1000"].ConInt(),
                        dataReader["1100"].ConInt(),
                        dataReader["1200"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<AtolyeRapor> GetList()
        {
            try
            {
                List<AtolyeRapor> atolyeRapors = new List<AtolyeRapor>();
                dataReader = sqlServices.StoreReader("AtolyeIslemAdimlariRapor");
                while (dataReader.Read())
                {
                    atolyeRapors.Add(new AtolyeRapor(
                        dataReader["400"].ConInt(),
                        dataReader["500"].ConInt(),
                        dataReader["600"].ConInt(),
                        dataReader["700"].ConInt(),
                        dataReader["800"].ConInt(),
                        dataReader["900"].ConInt(),
                        dataReader["1000"].ConInt(),
                        dataReader["1100"].ConInt(),
                        dataReader["1200"].ConInt()));
                }
                dataReader.Close();
                return atolyeRapors;
            }
            catch (Exception)
            {
                return new List<AtolyeRapor>();
            }
        }

        public string Update(AtolyeRapor entity)
        {
            throw new NotImplementedException();
        }
        public static AtolyeRaporDal GetInstance()
        {
            if (atolyeRaporDal == null)
            {
                atolyeRaporDal = new AtolyeRaporDal();
            }
            return atolyeRaporDal;
        }
    }
}
