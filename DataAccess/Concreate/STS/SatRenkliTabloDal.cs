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
    public class SatRenkliTabloDal
    {
        static SatRenkliTabloDal satRenkliTabloDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SatRenkliTabloDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }

        public string Add(SatRenkliTablo entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("RenkliTabloEkle",
                    new SqlParameter("@firmaadi", entity.Firmaadi),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@siparisid", entity.Siparisid),
                    new SqlParameter("@durum", entity.Durum),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu));

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

        public SatRenkliTablo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<SatRenkliTablo> GetList(string firmaadi, string durum)
        {
            try
            {
                List<SatRenkliTablo> sats = new List<SatRenkliTablo>();
                dataReader = sqlServices.StoreReader("RenkliTabloListe", new SqlParameter("@firmaadi", firmaadi), new SqlParameter("@durum", durum));
                while (dataReader.Read())
                {
                    sats.Add(new SatRenkliTablo(
                        dataReader["ID"].ConInt(),
                        dataReader["FIRMA_ADI"].ToString(),
                        dataReader["TARIH"].ConTime(),
                        dataReader["SIPARIS_ID"].ToString(),
                        dataReader["DURUM"].ToString(),
                        dataReader["EX_DOSYA_YOLU"].ToString()));
                }
                dataReader.Close();
                return sats;
            }
            catch (Exception e)
            {
                return new List<SatRenkliTablo>();
            }
        }

        public string Update(SatRenkliTablo entity)
        {
            throw new NotImplementedException();
        }

        public static SatRenkliTabloDal GetInstance()
        {
            if (satRenkliTabloDal == null)
            {
                satRenkliTabloDal = new SatRenkliTabloDal();
            }
            return satRenkliTabloDal;
        }
    }
}
