using DataAccess.Abstract;
using DataAccess.Database;
using Entity.DokumanYonetim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.DokumanYonetim
{
    public class DokumanDal //: IRepository<Dokuman>
    {
        static DokumanDal dokumanDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private DokumanDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Dokuman entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("DokumanEkle", new SqlParameter("@tur", entity.Tur), new SqlParameter("@numarasi", entity.Numarasi), new SqlParameter("@tanimi", entity.Tanimi),
                    new SqlParameter("@revizyon", entity.Revizyon), new SqlParameter("@onaytarihi", entity.Onaytarihi), new SqlParameter("@yayintarihi", entity.Yayintarihi),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu), new SqlParameter("@benzersiz", entity.Benzersiz));

                dataReader.Close();
                return "Dokuman Başarıyla Eklendi.";
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
                dataReader = sqlServices.StoreReader("DokumanSil",new SqlParameter("@id",id));
                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Dokuman Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dokuman> GetList(string benzersiz)
        {
            try
            {
                List<Dokuman> dokumen = new List<Dokuman>();
                dataReader = sqlServices.StoreReader("DokumanListele", new SqlParameter("@benzersiz", benzersiz));
                while (dataReader.Read())
                {
                    dokumen.Add(new Dokuman(dataReader["ID"].ConInt(),
                        dataReader["DOKUMAN_TURU"].ToString(),
                        dataReader["DOKUMAN_NUMARASI"].ToString(),
                        dataReader["DOKUMAN_TANIM"].ToString(),
                        dataReader["DOKUMAN_REVIZYON"].ToString(),
                        dataReader["ONAY_TARIHI"].ConTime(),
                        dataReader["YAYIN_TARIHI"].ConTime(),
                        dataReader["DosyaYolu"].ToString(),
                        dataReader["Benzersiz"].ToString()));
                }
                dataReader.Close();
                return dokumen;
            }
            catch
            {
                return new List<Dokuman>();
            }
        }

        public string Update(Dokuman entity)
        {
            try
            {
                sqlServices.Stored("DokumanGuncelle", new SqlParameter("@tur", entity.Tur), new SqlParameter("@numarasi", entity.Numarasi), new SqlParameter("@tanimi", entity.Tanimi),
                    new SqlParameter("@revizyon", entity.Revizyon), new SqlParameter("@onaytarihi", entity.Onaytarihi), new SqlParameter("@yayintarihi", entity.Yayintarihi),
                    new SqlParameter("@benzersiz", entity.Benzersiz));

                return "Dokuman Başaıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static DokumanDal GetInstance()
        {
            if (dokumanDal == null)
            {
                dokumanDal = new DokumanDal();
            }
            return dokumanDal;
        }
    }
}
