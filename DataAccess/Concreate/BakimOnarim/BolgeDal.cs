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
    public class BolgeDal //: IRepository<Bolge>
    {
        static BolgeDal bolgeDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private BolgeDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Bolge entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeEkle",
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@ilgiliPersonel", entity.IlgiliPersonel),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@telefon", entity.Telefon),
                    new SqlParameter("@faturaAdresi", entity.FaturaAdresi),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluSicil", entity.SorumluSicil),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis),
                    new SqlParameter("@ssPersonel", entity.SsPersonel),
                    new SqlParameter("@sspRutbe", entity.SsRutbe),
                    new SqlParameter("@sspGorev", entity.SspGorev),
                    new SqlParameter("@depo", entity.Depo));

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
                dataReader = sqlServices.StoreReader("BolgeSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Bolge Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeListele", new SqlParameter("@id", id));
                Bolge item = null;
                while (dataReader.Read())
                {
                    item = new Bolge(
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["ILGILI_PERSONEL"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["TELEFON"].ToString(),
                        dataReader["FATURA_ADRESI"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_SICIL"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ToString(),
                        dataReader["GARANTI_BITIS"].ToString(),
                        dataReader["SS_PERSONEL"].ToString(),
                        dataReader["SSP_RUTBE"].ToString(),
                        dataReader["SSP_GOREV"].ToString(),
                        dataReader["DEPO"].ToString());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Bolge> GetList()
        {
            try
            {
                List<Bolge> bolges = new List<Bolge>();
                dataReader = sqlServices.StoreReader("BolgeListele");
                while (dataReader.Read())
                {
                    bolges.Add(new Bolge(
                        dataReader["ID"].ConInt(),
                        dataReader["BOLGE_ADI"].ToString(),
                        dataReader["ILGILI_PERSONEL"].ToString(),
                        dataReader["BIRLIK_ADRESI"].ToString(),
                        dataReader["TELEFON"].ToString(),
                        dataReader["FATURA_ADRESI"].ToString(),
                        dataReader["PYP_NO"].ToString(),
                        dataReader["SORUMLU_SICIL"].ToString(),
                        dataReader["IL"].ToString(),
                        dataReader["ILCE"].ToString(),
                        dataReader["PROJE"].ToString(),
                        dataReader["GARANTI_BASLAMA"].ToString(),
                        dataReader["GARANTI_BITIS"].ToString(),
                        dataReader["SS_PERSONEL"].ToString(),
                        dataReader["SSP_RUTBE"].ToString(),
                        dataReader["SSP_GOREV"].ToString(),
                        dataReader["DEPO"].ToString()));
                }
                dataReader.Close();
                return bolges;
            }
            catch (Exception)
            {
                return new List<Bolge>();
            }
            
        }

        public string Update(Bolge entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("BolgeGuncelle",
                    new SqlParameter("@id",entity.Id),
                    new SqlParameter("@bolgeAdi", entity.BolgeAdi),
                    new SqlParameter("@ilgiliPersonel", entity.IlgiliPersonel),
                    new SqlParameter("@birlikAdresi", entity.BirlikAdresi),
                    new SqlParameter("@telefon", entity.Telefon),
                    new SqlParameter("@faturaAdresi", entity.FaturaAdresi),
                    new SqlParameter("@pypNo", entity.PypNo),
                    new SqlParameter("@sorumluSicil", entity.SorumluSicil),
                    new SqlParameter("@il", entity.Il),
                    new SqlParameter("@ilce", entity.Ilce),
                    new SqlParameter("@proje", entity.Proje),
                    new SqlParameter("@garantiBaslama", entity.GarantiBaslama),
                    new SqlParameter("@garantiBitis", entity.GarantiBitis),
                    new SqlParameter("@ssPersonel", entity.SsPersonel),
                    new SqlParameter("@sspRutbe", entity.SsRutbe),
                    new SqlParameter("@sspGorev", entity.SspGorev),
                    new SqlParameter("@depo", entity.Depo));

                dataReader.Close();
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static BolgeDal GetInstance()
        {
            if (bolgeDal == null)
            {
                bolgeDal = new BolgeDal();
            }
            return bolgeDal;
        }
    }
}
