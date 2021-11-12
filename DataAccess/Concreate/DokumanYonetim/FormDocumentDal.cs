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
    public class FormDocumentDal //: IRepository<FormDocument>
    {
        static FormDocumentDal dokumanDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        private FormDocumentDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(FormDocument entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("FormEkle", new SqlParameter("@tur", entity.Tur), new SqlParameter("@numarasi", entity.Numarasi), new SqlParameter("@tanimi", entity.Tanimi),
                    new SqlParameter("@revizyon", entity.Revizyon), new SqlParameter("@onaytarihi", entity.Onaytarihi), new SqlParameter("@yayintarihi", entity.Yayintarihi),
                    new SqlParameter("@dosyayolu", entity.Dosyayolu), new SqlParameter("@benzersiz", entity.Benzersiz));

                dataReader.Close();
                return "Form Başarıyla Eklendi.";
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

        public FormDocument Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<FormDocument> GetList(string benzersiz)
        {
            try
            {
                List<FormDocument> formDocuments = new List<FormDocument>();
                dataReader = sqlServices.StoreReader("FormListele", new SqlParameter("@benzersiz", benzersiz));
                while (dataReader.Read())
                {
                    formDocuments.Add(new FormDocument(dataReader["ID"].ConInt(),
                        dataReader["FORM_TURU"].ToString(),
                        dataReader["FORM_NUMARASI"].ToString(),
                        dataReader["FORM_TANIMI"].ToString(),
                        dataReader["FORM_REVIZYON"].ToString(),
                        dataReader["ONAY_TARIHI"].ConTime(),
                        dataReader["YAYIN_TARIHI"].ConTime(),
                        dataReader["DosyaYolu"].ToString(),
                        dataReader["Benzersiz"].ToString()));
                }
                dataReader.Close();
                return formDocuments;
            }
            catch
            {
                return new List<FormDocument>();
            }
        }

        public string Update(FormDocument entity)
        {
            try
            {
                sqlServices.Stored("FormGuncelle", new SqlParameter("@tur", entity.Tur), new SqlParameter("@numarasi", entity.Numarasi), new SqlParameter("@tanimi", entity.Tanimi),
                    new SqlParameter("@revizyon", entity.Revizyon), new SqlParameter("@onaytarihi", entity.Onaytarihi), new SqlParameter("@yayintarihi", entity.Yayintarihi),
                    new SqlParameter("@benzersiz", entity.Benzersiz));

                return "Dokuman Başaıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static FormDocumentDal GetInstance()
        {
            if (dokumanDal == null)
            {
                dokumanDal = new FormDocumentDal();
            }
            return dokumanDal;
        }
    }
}
