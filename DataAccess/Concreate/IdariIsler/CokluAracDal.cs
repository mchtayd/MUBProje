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
    public class CokluAracDal //: IRepository<CokluArac>
    {
        static CokluAracDal cokluAracDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private CokluAracDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(CokluArac entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("CokuAracList",
                    new SqlParameter("@siparisNo", entity.SiparisNo),
                    new SqlParameter("@plaka", entity.Plaka),
                    new SqlParameter("@baslangicKm", entity.BaslangicKm),
                    new SqlParameter("@bitisKm", entity.BitisKm),
                    new SqlParameter("@toplamKm", entity.ToplamKm),
                    new SqlParameter("@aciklama", entity.Aciklama),
                    new SqlParameter("@baslangicTarihi", entity.BaslangicTarihi),
                    new SqlParameter("@bitisTarihi", entity.BitisTarihi));

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

        public CokluArac Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<CokluArac> GetList(string siparisNo)
        {
            try
            {
                List<CokluArac> cokluAracs = new List<CokluArac>();
                dataReader = sqlServices.StoreReader("CokuAracListGoster", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    cokluAracs.Add(new CokluArac(
                        dataReader["ID"].ConInt(),
                        dataReader["SIPARIS_NO"].ToString(),
                        dataReader["PLAKA"].ToString(),
                        dataReader["BASLANGIC_KM"].ConInt(),
                        dataReader["BITIS_KM"].ConInt(),
                        dataReader["TOPLAM_KM"].ConInt(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["BASLANGIC_TARIHI"].ConDate(),
                        dataReader["BITIS_TARIHI"].ConDate()));
                }
                dataReader.Close();
                return cokluAracs;
            }
            catch (Exception)
            {
                return new List<CokluArac>();
            }
        }

        public string Update(CokluArac entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("CokluAracUpdate", 
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@baslangicKm",entity.BaslangicKm),
                    new SqlParameter("@bitisKm",entity.BitisKm),
                    new SqlParameter("@toplamKm",entity.ToplamKm),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@baslangicTarihi",entity.BaslangicTarihi),
                    new SqlParameter("@bitisTarihi",entity.BitisTarihi));

                dataReader.Close();
                return "OK";

            }
            catch (Exception)
            {
                return "OK";
            }
        }
        public static CokluAracDal GetInstance()
        {
            if (cokluAracDal == null)
            {
                cokluAracDal = new CokluAracDal();
            }
            return cokluAracDal;
        }
    }
}
