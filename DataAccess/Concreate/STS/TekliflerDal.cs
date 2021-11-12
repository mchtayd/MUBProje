using DataAccess.Abstract;
using DataAccess.Database;
using Entity.STS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.STS
{
    public class TekliflerDal
    {
        static TekliflerDal tekliflerDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private TekliflerDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Teklifler entity, string siparisNo)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SatTeklifEkle", new SqlParameter("@bf1", entity.Bf1), new SqlParameter("@bt1", entity.Bt1),
                    new SqlParameter("@if2", entity.If2), new SqlParameter("@it2", entity.It2), new SqlParameter("@uf3", entity.Uf3), new SqlParameter("@ut3",entity.Ut3),
                    new SqlParameter("@siparisno", siparisNo));

                dataReader.Close();
                return "";
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

        public Teklifler Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Teklifler> GetList(string siparisNo)
        {
            try
            {
                List<Teklifler> tekliflers = new List<Teklifler>();
                dataReader = sqlServices.StoreReader("SatTeklifListele", new SqlParameter("@siparisNo", siparisNo));
                while (dataReader.Read())
                {
                    tekliflers.Add(new Teklifler(dataReader["ID"].ConInt(), dataReader["BIRIM_FIYATI_1"].ConInt(), dataReader["TOPLAM_FIYAT_1"].ConInt(),
                         dataReader["BIRIM_FIYATI_2"].ConInt(), dataReader["TOPLAM_FIYAT_1"].ConInt(), dataReader["BIRIM_FIYATI_3"].ConInt(), dataReader["TOPLAM_FIYAT_3"].ConInt()));
                }
                dataReader.Close();
                return tekliflers;
            }
            catch
            {
                return new List<Teklifler>();
            }
        }

        public string Update(Teklifler entity)
        {
            throw new NotImplementedException();
        }
        public static TekliflerDal GetInstance()
        {
            if (tekliflerDal == null)
            {
                tekliflerDal = new TekliflerDal();
            }
            return tekliflerDal;
        }
    }
}
