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
    public class MalzemeStokDal //: IRepository<MalzemeStok>
    {
        static MalzemeStokDal malzemeStokDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private MalzemeStokDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(MalzemeStok entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeStok",
                    new SqlParameter("@stokNo",entity.StokNo),
                    new SqlParameter("@tanim",entity.Tanim),
                    new SqlParameter("@malzemeKulYer",entity.MalzemeninKulYer),
                    new SqlParameter("@malzemeUstTakim",entity.MalzemeUstTakim),
                    new SqlParameter("@dosyaYolu",entity.DosyaYolu));
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

        public MalzemeStok Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MalzemeList",new SqlParameter("@id",id));
                MalzemeStok item = null;
                while (dataReader.Read())
                {
                    item = new MalzemeStok(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MALZEMENIN_KUL_YER"].ToString(),
                        dataReader["MALZEME_UST_TAKIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MalzemeStok> GetList()
        {
            try
            {
                List<MalzemeStok> malzemeStoks = new List<MalzemeStok>();
                dataReader = sqlServices.StoreReader("MalzemeList",new SqlParameter("@id",0));
                while (dataReader.Read())
                {
                    malzemeStoks.Add(new MalzemeStok(
                        dataReader["ID"].ConInt(),
                        dataReader["STOK_NO"].ToString(),
                        dataReader["TANIM"].ToString(),
                        dataReader["MALZEMENIN_KUL_YER"].ToString(),
                        dataReader["MALZEME_UST_TAKIM"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return malzemeStoks;
            }
            catch (Exception)
            {
                return new List<MalzemeStok>();
            }
        }

        public string Update(MalzemeStok entity)
        {
            throw new NotImplementedException();
        }
        public static MalzemeStokDal GetInstance()
        {
            if (malzemeStokDal == null)
            {
                malzemeStokDal = new MalzemeStokDal();
            }
            return malzemeStokDal;
        }
    }
}
