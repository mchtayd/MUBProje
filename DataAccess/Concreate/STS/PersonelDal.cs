using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class PersonelDal : IRepository<Personel>
    {
        static PersonelDal personelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;
        bool result;
        private PersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Personel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelKaydet", new SqlParameter("@sicilno", entity.Sicilno), new SqlParameter("@isim", entity.Isim),
                     new SqlParameter("@bolumid", entity.Bolumid), new SqlParameter("@birimid", entity.Birimid));
                if (dataReader.Read())
                {
                    result = dataReader[0].ConBool();
                }
                dataReader.Close();
                if (result)
                {
                    return entity.Sicilno + " Sicil Numarasıyla Zaten Bir Kayıt Var.";
                }
                return entity.Sicilno + " Sicil Numarasıyla Kayıt Başarılı Bir Şekilde Eklendi.";
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
                sqlServices.Stored("PersonelSil", new SqlParameter("@id", id));
                return "Personel Başarıyla Silindi.";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Personel Get(int id)
        {
            return null;
        }

        public List<Personel> GetList()
        {
            try
            {
                List<Personel> personels = new List<Personel>();
                dataReader = sqlServices.StoreReader("PersonelListesi");
                while (dataReader.Read())
                {
                    Personel personel = new Personel(dataReader["ID"].ConInt(), dataReader["SICILNO"].ToString(), dataReader["AD_SOYAD"].ToString(),
                        dataReader["BOLUM_ID"].ConInt(), dataReader["BOLUM"].ToString(), dataReader["BIRIM_ID"].ConInt(), dataReader["BIRIM"].ToString());
                    personels.Add(personel);
                }
                dataReader.Close();
                return personels;
            }
            catch
            {
                return new List<Personel>();
            }
        }

        public string Update(Personel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("PersonelGuncelle", new SqlParameter("@id", entity.Id), new SqlParameter("@sicilno", entity.Sicilno),
                    new SqlParameter("@isim", entity.Isim), new SqlParameter("@isim", entity.Isim), new SqlParameter("@bolumid", entity.Bolumid),
                    new SqlParameter("@birimid", entity.Birimid));
                dataReader.Close();
                return entity.Sicilno + " Sicil Numaralı Kayıt Başarıyla Güncellendi.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static PersonelDal GetInstance()
        {
            if (personelDal == null)
            {
                personelDal = new PersonelDal();
            }
            return personelDal;
        }
        public object[] Login(string sicilno, string sifre)
        
        {
            try
            {
                object[] infos = null;
                dataReader = sqlServices.StoreReader("PersonelLogin", new SqlParameter("@sicilno", sicilno), new SqlParameter("@sifre", sifre));
                if (dataReader.Read())
                {
                    int id, yetkiId; string isim, bolum, projekodu, masrafYeriNo, izinIdleri, mail, masrafYeriSorumlusu, personelSiparis, unvani, yetkiModu, sirketMail;

                    id = dataReader["ID"].ConInt();
                    isim = dataReader["AD_SOYAD"].ToString();
                    bolum = dataReader["SIRKET_BOLUM"].ToString();
                    projekodu = dataReader["PROJE_KODU"].ToString();
                    masrafYeriNo = dataReader["MASRAF_YERI_NO"].ToString();
                    yetkiId = dataReader["Id"].ConInt();
                    izinIdleri = dataReader["Izin_Idleri"].ToString();
                    mail = dataReader["OFICE_MAIL"].ToString();
                    masrafYeriSorumlusu = dataReader["MASRAF_YERI_SORUMLUSU"].ToString();
                    personelSiparis = dataReader["SIPARIS"].ToString();
                    unvani = dataReader["IS_UNVANI"].ToString();
                    yetkiModu = dataReader["YETKI_MODU"].ToString();
                    sirketMail = dataReader["SIRKET_MAIL"].ToString();

                    infos = new object[] { id, isim, bolum, projekodu, masrafYeriNo, yetkiId, izinIdleri, mail, masrafYeriSorumlusu, personelSiparis, unvani, yetkiModu, sirketMail };
                }
                dataReader.Close();
                return infos;
            }
            catch (Exception)
            {
                dataReader.Close();
                return null;
            }
        }
    }
}
