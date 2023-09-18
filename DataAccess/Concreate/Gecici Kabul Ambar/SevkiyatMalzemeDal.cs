using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class SevkiyatMalzemeDal //: IRepository<SevkiyatMalzeme>
    {
        static SevkiyatMalzemeDal sevkiyatMalzemeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SevkiyatMalzemeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public static SevkiyatMalzemeDal GetInstance()
        {
            if (sevkiyatMalzemeDal == null)
            {
                sevkiyatMalzemeDal = new SevkiyatMalzemeDal();
            }
            return sevkiyatMalzemeDal;
        }

        public string Add(SevkiyatMalzeme entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SevkiyatMalzemeDal",
                    new SqlParameter("@benzersizId", entity.BenzersizId),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@seriLotNo", entity.SeriLotNo),
                    new SqlParameter("@revizyon", entity.Revizyon),
                    new SqlParameter("@miktar", entity.Miktar),
                    new SqlParameter("@birim", entity.Birim),
                    new SqlParameter("@abfNo", entity.AbfNo),
                    new SqlParameter("@tarih", entity.Tarih));

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
                sqlServices.Stored("SevkiyatMalzemeDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public SevkiyatMalzeme Get(int id)
        {
            try
            {
                sqlServices.StoreReader("SevkiyatMalzemeList", new SqlParameter("@benzersizId", new SqlParameter("@id", id)));
                SevkiyatMalzeme sevkiyatMalzeme = null;
                while (dataReader.Read())
                {
                    sevkiyatMalzeme = new SevkiyatMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["TARIH"].ConDate());
                }
                dataReader.Close();
                return sevkiyatMalzeme;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SevkiyatMalzeme> GetList(int benzersizId)
        {
            try
            {
                List<SevkiyatMalzeme> sevkiyatMalzemes = new List<SevkiyatMalzeme>();
                sqlServices.StoreReader("SevkiyatMalzemeList", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    sevkiyatMalzemes.Add(new SevkiyatMalzeme(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["SERI_LOT_NO"].ToString(),
                        dataReader["REVIZYON"].ToString(),
                        dataReader["MIKTAR"].ConInt(),
                        dataReader["BIRIM"].ToString(),
                        dataReader["ABF_NO"].ToString(),
                        dataReader["TARIH"].ConDate()));
                }

                dataReader.Close();
                return sevkiyatMalzemes;
            }
            catch (Exception)
            {
                return new List<SevkiyatMalzeme>();
            }
        }

        public string Update(SevkiyatMalzeme entity)
        {
            throw new NotImplementedException();
        }
    }
}
