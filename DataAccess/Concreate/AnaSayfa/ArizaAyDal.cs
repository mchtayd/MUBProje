using DataAccess.Abstract;
using DataAccess.Database;
using Entity.AnaSayfa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.Concreate.AnaSayfa
{
    public class ArizaAyDal // : IRepository<ArizaAy>
    {
        static ArizaAyDal arizaAyDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private ArizaAyDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static ArizaAyDal GetInstance()
        {
            if (arizaAyDal == null)
            {
                arizaAyDal = new ArizaAyDal();
            }
            return arizaAyDal;
        }

        public string Add(ArizaAy entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArizaAy Get(string yil, string sektor, string il)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaAyGrafikleri", new SqlParameter("@yil", yil), new SqlParameter("@sektor", sektor), new SqlParameter("@il", il));
                ArizaAy arizaAy = null;
                while (dataReader.Read())
                {
                    arizaAy = new ArizaAy(
                        dataReader["OCAK"].ConInt(),
                        dataReader["ŞUBAT"].ConInt(),
                        dataReader["MART"].ConInt(),
                        dataReader["NİSAN"].ConInt(),
                        dataReader["MAYIS"].ConInt(),
                        dataReader["HAZİRAN"].ConInt(),
                        dataReader["TEMMUZ"].ConInt(),
                        dataReader["AĞUSTOS"].ConInt(),
                        dataReader["EYLÜL"].ConInt(),
                        dataReader["EKİM"].ConInt(),
                        dataReader["KASIM"].ConInt(),
                        dataReader["ARALIK"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConInt());
                }
                dataReader.Close();
                return arizaAy;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ArizaAy GetTumTamamlananlar(string yil)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaAyGrafikleriTumTamamlananlar", new SqlParameter("@yil", yil));
                ArizaAy arizaAy = null;
                while (dataReader.Read())
                {
                    arizaAy = new ArizaAy(
                        dataReader["OCAK"].ConInt(),
                        dataReader["ŞUBAT"].ConInt(),
                        dataReader["MART"].ConInt(),
                        dataReader["NİSAN"].ConInt(),
                        dataReader["MAYIS"].ConInt(),
                        dataReader["HAZİRAN"].ConInt(),
                        dataReader["TEMMUZ"].ConInt(),
                        dataReader["AĞUSTOS"].ConInt(),
                        dataReader["EYLÜL"].ConInt(),
                        dataReader["EKİM"].ConInt(),
                        dataReader["KASIM"].ConInt(),
                        dataReader["ARALIK"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConInt());
                }
                dataReader.Close();
                return arizaAy;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ArizaAy GetTumDevamEden(string yil)
        {
            try
            {
                dataReader = sqlServices.StoreReader("ArizaAyGrafikleriTumDevamEdenler", new SqlParameter("@yil", yil));
                ArizaAy arizaAy = null;
                while (dataReader.Read())
                {
                    arizaAy = new ArizaAy(
                        dataReader["OCAK"].ConInt(),
                        dataReader["ŞUBAT"].ConInt(),
                        dataReader["MART"].ConInt(),
                        dataReader["NİSAN"].ConInt(),
                        dataReader["MAYIS"].ConInt(),
                        dataReader["HAZİRAN"].ConInt(),
                        dataReader["TEMMUZ"].ConInt(),
                        dataReader["AĞUSTOS"].ConInt(),
                        dataReader["EYLÜL"].ConInt(),
                        dataReader["EKİM"].ConInt(),
                        dataReader["KASIM"].ConInt(),
                        dataReader["ARALIK"].ConInt(),
                        dataReader["GENEL_TOPLAM"].ConInt());
                }
                dataReader.Close();
                return arizaAy;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<ArizaAy> GetList()
        {
            throw new NotImplementedException();
        }
        public List<string> GetListArizaIlList()
        {
            try
            {
                List<string> list = new List<string>();
                dataReader = sqlServices.StoreReader("ArizaGrafikIl");
                while (dataReader.Read())
                {
                    list.Add(dataReader["IL"].ToString());
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public List<string> GetListArizaIlcelerList()
        {
            try
            {
                List<string> list = new List<string>();
                dataReader = sqlServices.StoreReader("ArizaGrafikIlce");
                while (dataReader.Read())
                {
                    list.Add(dataReader["ILCE"].ToString());
                }
                dataReader.Close();
                return list;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public string Update(ArizaAy entity)
        {
            throw new NotImplementedException();
        }
    }
}
