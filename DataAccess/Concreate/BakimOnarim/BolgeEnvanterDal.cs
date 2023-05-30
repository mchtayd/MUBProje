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
    public class BolgeEnvanterDal //: IRepository<BolgeEnvanter>
    {
        static BolgeEnvanterDal bolgeEnvanterDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BolgeEnvanterDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static BolgeEnvanterDal GetInstance()
        {
            if (bolgeEnvanterDal == null)
            {
                bolgeEnvanterDal = new BolgeEnvanterDal();
            }
            return bolgeEnvanterDal;
        }


        public string Add(BolgeEnvanter entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeEnvanterAdd",
                    new SqlParameter("@kategori", entity.Kategori),
                    new SqlParameter("@donanim", entity.Donanim),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@nsn", entity.Nsn),
                    new SqlParameter("@guncellemTarihi", entity.GuncellemeTarihi),
                    new SqlParameter("@mubBilgisi", entity.MubBilgisi),
                    new SqlParameter("@bolgeId", entity.BolgeId));

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
                sqlServices.Stored("BolgeEnvanterSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public BolgeEnvanter Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<BolgeEnvanter> GetList(int bolgeId)
        {
            try
            {
                List<BolgeEnvanter> bolgeEnvanters = new List<BolgeEnvanter>();
                dataReader = sqlServices.StoreReader("BolgeEnvanterList", new SqlParameter("@bolgeId", bolgeId));
                while (dataReader.Read())
                {
                    bolgeEnvanters.Add(new BolgeEnvanter(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLGE_ID"].ConInt(),
                        dataReader["KATEGORI"].ToString(),
                        dataReader["DONANIM"].ToString(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["SERI_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["NSN"].ToString(),
                        dataReader["GUNCELLEME_TARIHI"].ConDate(),
                        dataReader["MUB_BILGISI"].ToString()));
                }
                dataReader.Close();
                return bolgeEnvanters;
            }
            catch (Exception)
            {
                return new List<BolgeEnvanter>();
            }
        }

        public string Update(BolgeEnvanter entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeEnvanterGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@kategori", entity.Kategori),
                    new SqlParameter("@donanim", entity.Donanim),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@seriNo", entity.SeriNo),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@nsn", entity.Nsn),
                    new SqlParameter("@guncellemTarihi", entity.GuncellemeTarihi),
                    new SqlParameter("@mubBilgisi", entity.MubBilgisi),
                    new SqlParameter("@bolgeId", entity.BolgeId));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
