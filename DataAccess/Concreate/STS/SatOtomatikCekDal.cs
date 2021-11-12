using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class SatOtomatikCekDal : IRepository<SatOtomatikCek>
    {
        static SatOtomatikCekDal satOtomatikCekDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private SatOtomatikCekDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(SatOtomatikCek entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SatOtomatikCek Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatOtomatikCek> GetList()
        {
            try
            {
                List<SatOtomatikCek> otocek = new List<SatOtomatikCek>();
                dataReader = sqlServices.StoreReader("OtomatikCek");
                while (dataReader.Read())
                {
                    otocek.Add(new SatOtomatikCek(dataReader["AD_SOYAD"].ToString(), dataReader["DEPARTMAN"].ToString(),dataReader["BOLUM"].ToString(),
                        dataReader["BIRIM"].ToString(),dataReader["PROJE_KODU"].ToString()));
                }
                dataReader.Close();
                return otocek;
            }
            catch
            {
                return new List<SatOtomatikCek>();
            }
        }

        public string Update(SatOtomatikCek entity)
        {
            throw new NotImplementedException();
        }

        public static SatOtomatikCekDal GetInstance()
        {
            if (satOtomatikCekDal == null)
            {
                satOtomatikCekDal = new SatOtomatikCekDal();
            }
            return satOtomatikCekDal;
        }
         
    }
}

