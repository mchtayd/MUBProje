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
    public class KonaklamaGecmisDal // : IRepository<KonaklamaGecmis>
    {
        static KonaklamaGecmisDal konaklamaGecmisDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private KonaklamaGecmisDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(KonaklamaGecmis entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("KonaklamaGecmisEkle",
                    new SqlParameter("@restarihi",entity.Restarihi),
                    new SqlParameter("@personel",entity.Personel),
                    new SqlParameter("@konaklamail",entity.Konaklamail),
                    new SqlParameter("@otel",entity.Oteladi),
                    new SqlParameter("@guntutar",entity.Guntutar),
                    new SqlParameter("@toptutar",entity.Toptutar),
                    new SqlParameter("@konaklanangun",entity.Konaklamagun),
                    new SqlParameter("@giristarihi",entity.Giristarihi),
                    new SqlParameter("@cikistarihi",entity.Cikistarihi),
                    new SqlParameter("@proje",entity.Proje),
                    new SqlParameter("@aciklama",entity.Aciklama),
                    new SqlParameter("@butcekodu", entity.Butcekodu),
                    new SqlParameter("@ay", entity.Ay));
                
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

        public KonaklamaGecmis Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<KonaklamaGecmis> GetList()
        {
            try
            {
                List<KonaklamaGecmis> konaklamaGecmis = new List<KonaklamaGecmis>();
                dataReader = sqlServices.StoreReader("KonaklamaGecmisList");
                while (dataReader.Read())
                {
                    konaklamaGecmis.Add(new KonaklamaGecmis(
                        dataReader["ID"].ConInt(),
                        dataReader["RES_TARIHI"].ConDate(),
                        dataReader["PERSONEL"].ToString(),
                        dataReader["KONAKLAMA_IL"].ToString(),
                        dataReader["OTEL"].ToString(),
                        dataReader["GUN_TUTAR"].ConDouble(),
                        dataReader["TOP_TUTAR"].ConDouble(),
                        dataReader["KONAKLANAN_GUN"].ConInt(),
                        dataReader["GIRIS_TARIHI"].ConDate(),
                        dataReader["CIKIS_TARIHI"].ConDate(),
                        dataReader["PROJE"].ToString(),
                        dataReader["ACIKLAMA"].ToString(),
                        dataReader["BUTCE_KODU"].ToString(),
                        dataReader["AY"].ToString()));
                }
                dataReader.Close();
                return konaklamaGecmis;
            }
            catch (Exception)
            {
                return new List<KonaklamaGecmis>();
            }
        }

        public string Update(KonaklamaGecmis entity)
        {
            throw new NotImplementedException();
        }
        public static KonaklamaGecmisDal GetInstance()
        {
            if (konaklamaGecmisDal == null)
            {
                konaklamaGecmisDal = new KonaklamaGecmisDal();
            }
            return konaklamaGecmisDal;
        }
    }
}
