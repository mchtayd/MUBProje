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
    public class SirketBolumDal //: IRepository<SirketBolum>
    {
        static SirketBolumDal sirketBolumDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SirketBolumDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(SirketBolum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SirketBolumAdd",
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@bagliOlduguBolum", entity.BagliOlduguBolum),
                    new SqlParameter("@bolumNo", entity.BolumNo));

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
            try
            {
                sqlServices.Stored("SirketBolumDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SirketBolum Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SirketBolumLlist", new SqlParameter("@id", id));
                SirketBolum sirketBolum = null;
                while(dataReader.Read())
                {
                    sirketBolum = new SirketBolum(
                        dataReader["ID"].ConInt(),
                        dataReader["BAGLI_OLDUGU_BOLUM"].ToString(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["BOLUM_NO"].ConInt());

                }

                dataReader.Close();
                return sirketBolum;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SirketBolum> GetList(string bolumAdi)
        {
            try
            {
                List<SirketBolum> sirketBolums = new List<SirketBolum>();
                dataReader = sqlServices.StoreReader("SirketBolumLlist", new SqlParameter("@bolumAdi", bolumAdi));
                while(dataReader.Read()) 
                {
                    sirketBolums.Add(new SirketBolum(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["BAGLI_OLDUGU_BOLUM"].ToString(),
                        dataReader["BOLUM_NO"].ConInt()));
                }
                dataReader.Close();
                return sirketBolums;
            }
            catch (Exception)
            {
                return new List<SirketBolum>();
            }
        }
        public List<SirketBolum> GetListBolumNo(int bolumNo)
        {
            try
            {
                List<SirketBolum> sirketBolums = new List<SirketBolum>();
                dataReader = sqlServices.StoreReader("SirketBolumNoList", new SqlParameter("@bolumNo", bolumNo));
                while (dataReader.Read())
                {
                    sirketBolums.Add(new SirketBolum(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLUM"].ToString(),
                        dataReader["BAGLI_OLDUGU_BOLUM"].ToString(),
                        dataReader["BOLUM_NO"].ConInt()));
                }
                dataReader.Close();
                return sirketBolums;
            }
            catch (Exception)
            {
                return new List<SirketBolum>();
            }
        }

        public string Update(SirketBolum entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SirketBolumUpdate",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@bolum", entity.Bolum),
                    new SqlParameter("@bagliOlduguBolum", entity.BagliOlduguBolum));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SirketBolumDal GetInstance()
        {
            if (sirketBolumDal == null)
            {
                sirketBolumDal = new SirketBolumDal();
            }
            return sirketBolumDal;
        }
    }
}
