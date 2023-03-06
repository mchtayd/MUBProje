using DataAccess.Abstract;
using DataAccess.Database;
using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.IdariIsler
{
    public class StokDal // : IRepository<Stok>
    {
        static StokDal stokDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private StokDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Stok entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Stok Get(string tanim)
        {
            try
            {
                dataReader = sqlServices.StoreReader("IdariIslerStokList", new SqlParameter("@tanim", tanim));
                Stok item = null;
                while (dataReader.Read())
                {
                    item = new Stok(
                            dataReader["ID"].ConInt(),
                            dataReader["STOK_NO"].ToString(),
                            dataReader["TANIM"].ToString(),
                            dataReader["BIRIM"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public List<Stok> GetList()
        {
            try
            {
                List<Stok> stoks = new List<Stok>();
                dataReader = sqlServices.StoreReader("IdariIslerStokList");
                while (dataReader.Read())
                {
                    stoks.Add(new Stok(
                            dataReader["ID"].ConInt(),
                                dataReader["STOK_NO"].ToString(),
                                dataReader["TANIM"].ToString(),
                                dataReader["BIRIM"].ToString()));
                }
                dataReader.Close();
                return stoks;
            }
            catch (Exception)
            {
                return new List<Stok>();
            }
            
        }

        public string Update(Stok entity)
        {
            throw new NotImplementedException();
        }
        public static StokDal GetInstance()
        {
            if (stokDal == null)
            {
                stokDal = new StokDal();
            }
            return stokDal;
        }
    }
}
