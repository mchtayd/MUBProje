using DataAccess.Abstract;
using DataAccess.Concreate.BakimOnarim;
using DataAccess.Database;
using Entity.Egitim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.Egitim
{
    public class EgitimTalebiDal //: IRepository<EgitimTalebi>
    {
        static EgitimTalebiDal egitimTalebiDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private EgitimTalebiDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(EgitimTalebi entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("EgitimTalebiAdd",
                    new SqlParameter("@talepEden", entity.TalepEden),
                    new SqlParameter("@usBolgesi", entity.UsBolgesi),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@talepTarihi", entity.TalepTarihi),
                    new SqlParameter("@egitimTuru", entity.EgitimTuru),
                    new SqlParameter("@kisiSayisi", entity.KisiSayisi),
                    new SqlParameter("@dosyaYolu", entity.DosyaYolu));
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

        public EgitimTalebi Get(int id)
        {
            try
            {
                EgitimTalebi egitimTalebi = null;
                dataReader = sqlServices.StoreReader("EgitimTalepleriList", new SqlParameter("@id", id));
                while (dataReader.Read())
                {
                    egitimTalebi = new EgitimTalebi(
                        dataReader["ID"].ConInt(),
                        dataReader["TALEP_EDEN"].ToString(),
                        dataReader["US_BOLGESI"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["KAYIT_TARIHI"].ConDate(),
                        dataReader["TALEP_TARIHI"].ConDate(),
                        dataReader["EGITIM_TURU"].ToString(),
                        dataReader["KISI_SAYISI"].ToString(),
                        dataReader["PLANLAMA_YAPAN"].ToString(),
                        dataReader["PLANLAMA_TARIHI"].ToString(),
                        dataReader["DURUMU"].ToString(),
                        dataReader["DOSYA_YOLU"].ToString());
                }
                dataReader.Close();
                return egitimTalebi;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EgitimTalebi> GetList()
        {
            throw new NotImplementedException();
        }

        public string Update(EgitimTalebi entity)
        {
            throw new NotImplementedException();
        }
    }
}
