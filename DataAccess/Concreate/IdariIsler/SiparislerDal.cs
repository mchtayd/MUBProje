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
    public class SiparislerDal 
    {
        static SiparislerDal siparislerDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private SiparislerDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(Siparisler entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MevcutKadroEkle",new SqlParameter("@proje",entity.Proje),new SqlParameter("@SiparisNo",entity.Siparisno),new SqlParameter("@personelYonetici",entity.Personelyonetici),
                    new SqlParameter("@personel",entity.Personel),new SqlParameter("@personelDepo",entity.Personeldepo),new SqlParameter("@toplamPersonel",entity.Personeltoplam),new SqlParameter("@yoneticiArac",entity.Yoneticiarac),
                    new SqlParameter("@araziArac",entity.Araziarac),new SqlParameter("@toplamArac",entity.Toplamarac),new SqlParameter("@sat",entity.Sat),new SqlParameter("@donemyil",entity.Donemyil),
                    new SqlParameter("@satkategori",entity.Satkategori), new SqlParameter("@benzersiz",entity.Benzersiz));

                dataReader.Close();
                return "Siparis Numarası Başarıyla Oluşturuldu.";
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
                dataReader = sqlServices.StoreReader("MevcutKadroSil", new SqlParameter("@id", id));
                dataReader.Close();
                return "Sipariş Numarası Başarıyla silindi.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }

        public Siparisler Get(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("MevcutKadroCek",new SqlParameter("@id",id));
                Siparisler item = null;
                while (dataReader.Read())
                {
                    item=new Siparisler(dataReader["ID"].ConInt(), dataReader["PROJE"].ToString(), dataReader["SIPARIS_NO"].ToString(), dataReader["PERSONEL_YONETICI"].ConInt(), dataReader["PERSONEL"].ConInt(),
                        dataReader["PERSONEL_DEPO"].ConInt(), dataReader["TOPLAM_PERSONEL"].ConInt(), dataReader["YONETICI_ARAC"].ConInt(), dataReader["ARAZI_ARAC"].ConInt(), dataReader["TOPLAM_ARAC"].ConInt(),
                        dataReader["SAT"].ToString(), dataReader["DONEM_YIL"].ToString(), dataReader["SAT_KATEGORİ"].ToString(),dataReader["Benzersiz"].ToString(),dataReader["MEVCUT_PERSONEL"].ConInt());
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Siparisler> GetList(string benzersiz)
        {
            try
            {
                List <Siparisler> siparislers = new List<Siparisler>();
                dataReader = sqlServices.StoreReader("MevcutKadroListele", new SqlParameter("@benzersiz",benzersiz));
                while (dataReader.Read())
                {
                    siparislers.Add(new Siparisler(
                        dataReader["ID"].ConInt(),
                        dataReader["PROJE"].ToString(),
                        dataReader["SIPARIS_NO"].ToString(), 
                        dataReader["PERSONEL_YONETICI"].ConInt(), 
                        dataReader["PERSONEL"].ConInt(),
                        dataReader["PERSONEL_DEPO"].ConInt(), 
                        dataReader["TOPLAM_PERSONEL"].ConInt(), 
                        dataReader["YONETICI_ARAC"].ConInt(), 
                        dataReader["ARAZI_ARAC"].ConInt(), 
                        dataReader["TOPLAM_ARAC"].ConInt(),
                        dataReader["SAT"].ToString(), 
                        dataReader["DONEM_YIL"].ToString(), 
                        dataReader["SAT_KATEGORİ"].ToString(), 
                        dataReader["Benzersiz"].ToString(),
                        dataReader["MEVCUT_PERSONEL"].ConInt()));
                }
                dataReader.Close();
                return siparislers;
            }
            catch (Exception ex)
            {
                return new List<Siparisler>();
            }
        }

        public string Update(Siparisler entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("SiparisGuncelle", new SqlParameter("@proje", entity.Proje), new SqlParameter("@SiparisNo", entity.Siparisno), new SqlParameter("@personelYonetici", entity.Personelyonetici),
                    new SqlParameter("@personel", entity.Personel), new SqlParameter("@personelDepo", entity.Personeldepo), new SqlParameter("@toplamPersonel", entity.Personeltoplam), new SqlParameter("@yoneticiArac", entity.Yoneticiarac),
                    new SqlParameter("@araziArac", entity.Araziarac), new SqlParameter("@toplamArac", entity.Toplamarac), new SqlParameter("@sat", entity.Sat), new SqlParameter("@donemyil", entity.Donemyil),
                    new SqlParameter("@satkategori", entity.Satkategori), new SqlParameter("@benzersiz", entity.Benzersiz));

                dataReader.Close();
                return entity.Siparisno + "Siparis Numarası Başarıyla Güncellendi";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static SiparislerDal GetInstance()
        {
            if (siparislerDal == null)
            {
                siparislerDal = new SiparislerDal();
            }
            return siparislerDal;
        }
        public int ToplamPers()
        {
            try
            {
                int personel = -1;
                dataReader = sqlServices.StoreReader("Toplampersonel");
                if (dataReader.Read())
                {
                    personel = dataReader["ToplamDeger"].ConInt();
                }
                dataReader.Close();
                return personel;
            }
            catch
            {
                return -1;
            }
        }
        public int ToplamArac()
        {
            try
            {
                int arac = -1;
                dataReader = sqlServices.StoreReader("Toplamarac");
                if (dataReader.Read())
                {
                    arac = dataReader["Toplamarac"].ConInt();
                }
                dataReader.Close();
                return arac;
            }
            catch
            {
                return -1;
            }
        }
        public int KontejanKontrol(string siparisno)
        {
            try
            {
                int personel = -1;
                dataReader = sqlServices.StoreReader("PersonelKontenjan",new SqlParameter("@siparisno",siparisno));
                if (dataReader.Read())
                {
                    personel = dataReader["TOPLAM_PERSONEL"].ConInt();
                }
                dataReader.Close();
                return personel;
            }
            catch(Exception EX)
            {
                return -1;
            }
        }
        public int KontejanKontrolMevcut(string siparisno)
        {
            try
            {
                int personel = -1;
                dataReader = sqlServices.StoreReader("PersonelKontejanKontrolMevcut", new SqlParameter("@siparisno", siparisno));
                if (dataReader.Read())
                {
                    personel = dataReader["MEVCUT_PERSONEL"].ConInt();
                }
                dataReader.Close();
                return personel;
            }
            catch
            {
                return -1;
            }
        }
        public string KontejanMevcutGuncelle(string siparisno,int mevcut)
        {
            try
            {
                string islem = "OK";
                dataReader = sqlServices.StoreReader("PersonelKontejanGuncelle", new SqlParameter("@siparisno", siparisno), new SqlParameter("@mevcutkadro",mevcut));
                dataReader.Close();
                return islem;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string KontejanMevcutAzalt(string siparisno, int kontenjan)
        {
            try
            {
                string islem = "OK";
                dataReader = sqlServices.StoreReader("MevcutKadroAzalt", new SqlParameter("@siparisno", siparisno), new SqlParameter("@kontenjan", kontenjan));
                dataReader.Close();
                return islem;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
