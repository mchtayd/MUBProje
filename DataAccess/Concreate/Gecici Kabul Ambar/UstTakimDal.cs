using DataAccess.Abstract;
using DataAccess.Database;
using Entity.Gecic_Kabul_Ambar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UglyToad.PdfPig.Graphics.Operations.General;

namespace DataAccess.Concreate.Gecici_Kabul_Ambar
{
    public class UstTakimDal// : IRepository<UstTakim>
    {
        static UstTakimDal ustTakimDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private UstTakimDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(UstTakim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UstTakimAdd", 
                    new SqlParameter("@stokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@ilgiliFirma",entity.IlgiliFirma));

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
                sqlServices.Stored("UstTakimDelete", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public UstTakim Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UstTakimList", new SqlParameter("@id", id));
                UstTakim item = null;
                while (dataReader.Read())
                {
                    item = new UstTakim(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UstTakim> GetList()
        {
            try
            {
                List<UstTakim> ustTakims = new List<UstTakim>();
                dataReader = sqlServices.StoreReader("UstTakimList");
                while (dataReader.Read())
                {
                    ustTakims.Add(new UstTakim(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["ILGILI_FIRMA"].ToString()));
                }
                dataReader.Close();
                return ustTakims;
            }
            catch (Exception)
            {
                return new List<UstTakim>();
            }
        }

        public string Update(UstTakim entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("UstTakimUpdate",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@stokNo", entity.StokNo),
                    new SqlParameter("@tanim", entity.Tanim),
                    new SqlParameter("@ilgiliFirma", entity.IlgiliFirma));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static UstTakimDal GetInstance()
        {
            if (ustTakimDal == null)
            {
                ustTakimDal = new UstTakimDal();
            }
            return ustTakimDal;
        }
    }
}
