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
    public class IslemAdimlariDal // : IRepository<IslemAdimlari>
    {
        static IslemAdimlariDal islemAdimlariDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private IslemAdimlariDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(IslemAdimlari entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IslemAdimlariEkle",
                    new SqlParameter("@islemAdimi",entity.IslemaAdimi),
                    new SqlParameter("@departman",entity.Departman));

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

        public IslemAdimlari Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IslemAdimlari> GetList(string departman)
        {
            try
            {
                List<IslemAdimlari> ıslemAdimlaris = new List<IslemAdimlari>();
                dataReader = sqlServices.StoreReader("IslemAdimlariList",new SqlParameter("@departman",departman));
                while (dataReader.Read())
                {
                    ıslemAdimlaris.Add(new IslemAdimlari(
                        dataReader["ID"].ConInt(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["DEPARTMAN"].ToString()));
                }
                dataReader.Close();
                return ıslemAdimlaris;
            }
            catch (Exception ex)
            {
                return new List<IslemAdimlari>();
            }
        }

        public string Update(IslemAdimlari entity)
        {
            throw new NotImplementedException();
        }
        public static IslemAdimlariDal GetInstance()
        {
            if (islemAdimlariDal == null)
            {
                islemAdimlariDal = new IslemAdimlariDal();
            }
            return islemAdimlariDal;
        }
    }
}
