using DataAccess.Abstract;
using DataAccess.Database;
using Entity;
using Entity.Yerleskeler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate
{
    public class GorevAtamaPersonelDal //: IRepository<GorevAtamaPersonel>
    {
        static GorevAtamaPersonelDal gorevAtamaPersonelDal;
        SqlServices sqlServices;
        SqlDataReader dataReader;

        private GorevAtamaPersonelDal()
        {
            sqlServices = SqlDatabase.GetInstance();
        }
        public string Add(GorevAtamaPersonel entity)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelEkle",
                    new SqlParameter("@benzersiz", entity.BenzersizId),
                    new SqlParameter("@departman", entity.Departman),
                    new SqlParameter("@gorevAtanacakPersonel", entity.GorevAtanacakPersonel),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@tarih", entity.Tarih),
                    new SqlParameter("@yapilanIslemler", entity.YapilanIslem),
                    new SqlParameter("@calismaSuresi", entity.CalismaSuresi));

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
                sqlServices.Stored("GorevAtananIslemAdimiSil", new SqlParameter("@id", id));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public GorevAtamaPersonel Get(int benzersiz, string departman)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelListele",
                    new SqlParameter("@benzersiz", benzersiz), new SqlParameter("@departman", departman));
                GorevAtamaPersonel item = null;
                while (dataReader.Read())
                {
                    item = new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0);
                }
                dataReader.Close();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevAtananIslemAdimlariList",
                    new SqlParameter("@benzersiz", benzersiz), new SqlParameter("@depoartman", departman));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GetListPersonelBazli(string personel)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("PersonelGorevleri",
                    new SqlParameter("@personelAdi", personel));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(dataReader["BENZERSIZ_ID"].ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }

        public List<GorevAtamaPersonel> GetDevamEdenler(int benzersiz, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevAtanaPersonelListDevamEden",
                    new SqlParameter("@benzersizId", benzersiz), new SqlParameter("@departman", departman));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }

        public List<GorevAtamaPersonel> GorevAtamaGetList(int benzersizId)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("IslemAdimSureleriniDuzelt", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevliPersoneller()
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                List<GorevAtamaPersonel> gorevAtamasMiktar = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevliPersoneller");
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["SIRKET_BOLUM"].ToString()));
                }
                dataReader.Close();
                int index = 0;
                double toplamDevamEdenSure = 0;
                foreach (GorevAtamaPersonel item in gorevAtamaPersonels)
                {
                    gorevAtamasMiktar.Clear(); 
                    dataReader = sqlServices.StoreReader("GorevliPersonellerMiktar", new SqlParameter("@personelAdi", item.GorevAtanacakPersonel));
                    while (dataReader.Read())
                    {
                        TimeSpan toplamSureDevamEden = DateTime.Now - dataReader["TARIH"].ConDate();
                        gorevAtamasMiktar.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        toplamSureDevamEden.Days.ConDouble()));
                    }
                    gorevAtamaPersonels[index].Sure = gorevAtamasMiktar.Count().ToString();
                    dataReader.Close();

                    int aktarimSuresiGun = 0;
                    dataReader = sqlServices.StoreReader("PersonelTamamlananGorevSuresi", new SqlParameter("@personelAdi", item.GorevAtanacakPersonel));
                    while (dataReader.Read())
                    {
                        aktarimSuresiGun = dataReader["ToplamAktarimSuresi"].ConInt();
                    }
                    dataReader.Close();

                    foreach (GorevAtamaPersonel item2 in gorevAtamasMiktar)
                    {
                        toplamDevamEdenSure += item2.BeklemeSuresi.ConDouble();
                    }
                    GorevAtamaPersonel gorevAtamaPersonel = null;
                    dataReader = sqlServices.StoreReader("PersonelGorevSayisi", new SqlParameter("@personelAdi", item.GorevAtanacakPersonel));
                    while (dataReader.Read())
                    {
                        gorevAtamaPersonel = new GorevAtamaPersonel(item.GorevAtanacakPersonel, dataReader["DEVAM_EDEN_GOREV_SAYISI"].ConInt(), dataReader["TAMAMLANAN_GOREV_AYISI"].ConInt(), dataReader["DEVAM_EDEN_GOREV_SAYISI"].ConInt() + dataReader["TAMAMLANAN_GOREV_AYISI"].ConInt(), toplamDevamEdenSure / dataReader["DEVAM_EDEN_GOREV_SAYISI"].ConInt(), 
                            aktarimSuresiGun.ConDouble());
                    }

                    dataReader.Close();

                    gorevAtamaPersonels[index].DevamEdenGorev = gorevAtamaPersonel.DevamEdenGorev.ConInt();
                    gorevAtamaPersonels[index].TamamlananGorev = gorevAtamaPersonel.TamamlananGorev.ConInt();
                    gorevAtamaPersonels[index].ToplamGorevSayisi = gorevAtamaPersonel.ToplamGorevSayisi.ConInt();

                    double tamamlananOrt = Math.Round(gorevAtamaPersonel.TamamlananGorevOrtSure.ConDouble(), 1);
                    gorevAtamaPersonels[index].TamamlananGorevOrtSure = tamamlananOrt;
                    if (gorevAtamaPersonels[index].TamamlananGorevOrtSure.ToString() == "NaN")
                    {
                        gorevAtamaPersonels[index].TamamlananGorevOrtSure = 0;
                    }

                    double devamOrt = Math.Round(gorevAtamaPersonel.DevamEdenSureOrtGun.ConDouble(), 1);
                    gorevAtamaPersonels[index].DevamEdenSureOrtGun = devamOrt;
                    if (gorevAtamaPersonels[index].DevamEdenSureOrtGun.ToString()=="NaN")
                    {
                        gorevAtamaPersonels[index].DevamEdenSureOrtGun = 0;
                    }
                    index++;
                    toplamDevamEdenSure = 0;
                }

                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public GorevAtamaPersonel GorevSayilari(string personel)
        {
            return null;
            //try
            //{
            //    GorevAtamaPersonel gorevAtamaPersonel = null;
            //    dataReader = sqlServices.StoreReader("PersonelGorevSayisi", new SqlParameter("@personelAdi", personel));
            //    while (dataReader.Read()) 
            //    {
            //        gorevAtamaPersonel = new GorevAtamaPersonel(personel, dataReader["DEVAM_EDEN_GOREV_SAYISI"].ConInt(), dataReader["TAMAMLANAN_GOREV_AYISI"].ConInt(), dataReader["DEVAM_EDEN_GOREV_SAYISI"].ConInt() + dataReader["TAMAMLANAN_GOREV_AYISI"].ConInt());
            //    }
            //    dataReader.Close();
            //    return gorevAtamaPersonel;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
            
        }
        public List<GorevAtamaPersonel> PersonelGorevleri(string personel)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("GorevliPersonellerMiktar", new SqlParameter("@personelAdi", personel));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> PersonelAtananArizaKayitlari(int benzersizId)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("PersonelAtananAriza", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }

        public string IslemAdimiSorumlusuUpdate(int id, string islemAdimiSorumlusu)
        {
            try
            {
                sqlServices.Stored("GorevAtananPersonelUpdate", new SqlParameter("@id", id), new SqlParameter("@islemAdimiSorumlusu", islemAdimiSorumlusu));
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<GorevAtamaPersonel> GorevAtamaAtolyeList()
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("IslemAdimiSorumlusuAtolyeList");
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        //public List<int> GorevAtamaAtolyeList()
        //{
        //    try
        //    {
        //        List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
        //        dataReader = sqlServices.StoreReader("IslemAdimiSorumlusuAtolyeList");
        //        while (dataReader.Read())
        //        {
        //            gorevAtamaPersonels.Add(new GorevAtamaPersonel(
        //                dataReader["ID"].ConInt(),
        //                dataReader["BENZERSIZ_ID"].ConInt(),
        //                dataReader["DEPARTMAN"].ToString(),
        //                dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
        //                dataReader["ISLEM_ADIMI"].ToString(),
        //                dataReader["TARIH"].ConDate(),
        //                dataReader["SURE"].ToString(),
        //                dataReader["YAPILAN_ISLEMLER"].ToString(),
        //                dataReader["CALISMA_SURESI"].ConOnlyTime(),
        //                "",
        //                0));
        //        }
        //        dataReader.Close();
        //        return gorevAtamaPersonels;

        //    }
        //    catch (Exception ex)
        //    {
        //        dataReader.Close();
        //        return new List<GorevAtamaPersonel>();
        //    }
        //}
        public List<GorevAtamaPersonel> GorevAtamaPersonelGor(int benzersiz, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("PersonelGorevAtamaGor",
                    new SqlParameter("@benzersizId", benzersiz), new SqlParameter("@departman", departman));
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerim(string adSoyad, string departman)
        {
            try
            {
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", departman));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    if (departman == "BAKIM ONARIM")
                    {
                        gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                    }
                    if (departman == "İZİN")
                    {
                        gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["IS_AKIS_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                    }
                    if (departman == "SATIN ALMA")
                    {
                        gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["SAT_FORM_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                    }
                    if (departman == "BAKIM ONARIM ATOLYE")
                    {
                        gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ID"].ToString(),
                        (toplamSure.Days).ConInt()));
                    }

                    if (departman == "MİF")
                    {
                        gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ID"].ToString(),
                        (toplamSure.Days).ConInt()));
                    }
                    //else
                    //{
                    //    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                    //    dataReader["ID"].ConInt(),
                    //    dataReader["BENZERSIZ_ID"].ConInt(),
                    //    dataReader["DEPARTMAN"].ToString(),
                    //    dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                    //    dataReader["ISLEM_ADIMI"].ToString(),
                    //    dataReader["TARIH"].ConDate(),
                    //    dataReader["SURE"].ToString(),
                    //    dataReader["YAPILAN_ISLEMLER"].ToString(),
                    //    dataReader["CALISMA_SURESI"].ConOnlyTime(),
                    //    dataReader["ID"].ToString()));
                    //}
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimBakimOnarim(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", "BAKIM ONARIM"));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ABF_FORM_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> TamamlananGorevler()
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("TamamlananGorevler");
                while (dataReader.Read())
                {
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> TamamlananHataliGorevler(int benzersizId)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("TamamlananHataliGorevler", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        "",
                        0));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }

        public List<int> HataliGorevler()
        {
            try
            {
                SqlDataReader dataReader;
                List<int> idler = new List<int>();
                dataReader = sqlServices.StoreReader("HataliGorevler");
                while (dataReader.Read())
                {
                    idler.Add(dataReader["BENZERSIZ_ID"].ConInt());
                }
                dataReader.Close();
                return idler;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<int>();
            }
        }
        public int HataliGorevlerId(int benzersizId)
        {
            try
            {
                int id = 0;
                SqlDataReader dataReader;
                dataReader = sqlServices.StoreReader("HataliGorevlerId", new SqlParameter("@benzersizId", benzersizId));
                while (dataReader.Read())
                {
                    id = dataReader["ID"].ConInt();
                }
                dataReader.Close();
                return id;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return 0;
            }
        }

        public List<GorevAtamaPersonel> IsAkisGorevlerimSatinAlma(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", "SATIN ALMA"));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["SAT_FORM_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimAtolye(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", "BAKIM ONARIM ATOLYE"));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["ID"].ToString(),
                        (toplamSure.Days).ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimIzin(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", "İZİN"));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["IS_AKIS_NO"].ToString(),
                        (toplamSure.Days).ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimMif(string adSoyad)
        {
            try
            {
                SqlDataReader dataReader;
                List<GorevAtamaPersonel> gorevAtamaPersonels = new List<GorevAtamaPersonel>();
                dataReader = sqlServices.StoreReader("AtolyeGorevlerimiGor",
                    new SqlParameter("@adSoyad", adSoyad),
                    new SqlParameter("@departman", "MİF"));
                while (dataReader.Read())
                {
                    TimeSpan toplamSure = DateTime.Now - dataReader["TARIH"].ConDate();
                    gorevAtamaPersonels.Add(new GorevAtamaPersonel(
                        dataReader["ID"].ConInt(),
                        dataReader["BENZERSIZ_ID"].ConInt(),
                        dataReader["DEPARTMAN"].ToString(),
                        dataReader["GOREV_ATANACAK_PERSONEL"].ToString(),
                        dataReader["ISLEM_ADIMI"].ToString(),
                        dataReader["TARIH"].ConDate(),
                        dataReader["SURE"].ToString(),
                        dataReader["YAPILAN_ISLEMLER"].ToString(),
                        dataReader["CALISMA_SURESI"].ConOnlyTime(),
                        dataReader["BENZERSIZ_ID"].ToString(),
                        (toplamSure.Days).ConInt()));
                }
                dataReader.Close();
                return gorevAtamaPersonels;

            }
            catch (Exception ex)
            {
                dataReader.Close();
                return new List<GorevAtamaPersonel>();
            }
        }

        public List<string> BolumeBagliPersoneller(string bolum)
        {
            try
            {
                SqlDataReader dataReader;
                List<string> personeller = new List<string>();
                dataReader = sqlServices.StoreReader("BolumeBagliPersoneller", new SqlParameter("@sirketBolum", bolum));
                while (dataReader.Read())
                {
                    personeller.Add(dataReader["AD_SOYAD"].ToString());
                }
                dataReader.Close();
                return personeller;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public string Update(GorevAtamaPersonel entity, string yapilanIslemler)
        {
            try
            {
                dataReader = sqlServices.StoreReader("GorevAtananPersonelSureGuncelle",
                    new SqlParameter("@id", entity.Id),
                    new SqlParameter("@personel", entity.GorevAtanacakPersonel),
                    new SqlParameter("@benzersiz", entity.BenzersizId),
                    new SqlParameter("@departman", entity.Departman),
                    new SqlParameter("@islemAdimi", entity.IslemAdimi),
                    new SqlParameter("@sure", entity.Sure),
                    new SqlParameter("@calismaSuresi", entity.CalismaSuresi),
                    new SqlParameter("@yapilanIslemler", yapilanIslemler));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string SureDuzelt(int id, string sure)
        {
            try
            {
                dataReader = sqlServices.StoreReader("AtolyeIslemAdimlariSureDuzelt",
                    new SqlParameter("@id", id),
                    new SqlParameter("@sure", sure));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string HataliGorevSil(int id)
        {
            try
            {
                dataReader = sqlServices.StoreReader("HataliGorevSil",
                    new SqlParameter("@id", id));

                dataReader.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaPersonelDal GetInstance()
        {
            if (gorevAtamaPersonelDal == null)
            {
                gorevAtamaPersonelDal = new GorevAtamaPersonelDal();
            }
            return gorevAtamaPersonelDal;
        }
    }
}
