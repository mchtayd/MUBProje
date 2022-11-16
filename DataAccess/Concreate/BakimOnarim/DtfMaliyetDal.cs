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
    public class DtfMaliyetDal //: IRepository<DtfMaliyet>
    {
        static DtfMaliyetDal dtfMaliyetDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private DtfMaliyetDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(DtfMaliyet entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfYaklasikMaliyetEkle",
                    new SqlParameter("@benzersizId", entity.BenzersizId),
                    new SqlParameter("@isTanimi", entity.IsTanimi),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@pBirimi", entity.PBirimi),
                    new SqlParameter("@birimTutar", entity.BirimTutar),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar));

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
                sqlServices.Stored("DtfMaliyetSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DtfMaliyet Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DtfMaliyet> GetList(int benzersizId)
        {
            try
            {
                List<DtfMaliyet> dtfMaliyets = new List<DtfMaliyet>();
                dataReader = sqlServices.StoreReader("DtfYaklasikMaliyetList", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    dtfMaliyets.Add(new DtfMaliyet(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["IS_TANIMI"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["P_BIRIMI"].ToString(),
                        dataReader["BIRIM_TUTAR"].ConDouble(),
                        dataReader["TOPLAM_TUTAR"].ConDouble()));
                }
                dataReader.Close();
                return dtfMaliyets;
            }
            catch (Exception)
            {
                return new List<DtfMaliyet>();
            }
        }

        public string Update(DtfMaliyet entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DtfYaklasikMaliyetGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@benzersizId", entity.BenzersizId),
                    new SqlParameter("@isTanimi", entity.IsTanimi),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@pBirimi", entity.PBirimi),
                    new SqlParameter("@birimTutar", entity.BirimTutar),
                    new SqlParameter("@toplamTutar", entity.ToplamTutar));
                
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DtfMaliyetDal GetInstance()
        {
            if (dtfMaliyetDal == null)
            {
                dtfMaliyetDal = new DtfMaliyetDal();
            }
            return dtfMaliyetDal;
        }
    }
}
