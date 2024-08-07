﻿using DataAccess.Abstract;
using DataAccess.Concreate;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class GorevAtamaPersonelManager // : IRepository<GorevAtamaPersonel>
    {
        static GorevAtamaPersonelManager gorevAtamaPersonelManager;
        GorevAtamaPersonelDal gorevAtamaPersonelDal;

        private GorevAtamaPersonelManager()
        {
            gorevAtamaPersonelDal = GorevAtamaPersonelDal.GetInstance();
        }
        public string Add(GorevAtamaPersonel entity)
        {
            try
            {
                return gorevAtamaPersonelDal.Add(entity);
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
                return gorevAtamaPersonelDal.Delete(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string IslemAdimiSorumlusuUpdate(int id, string islemAdimiSorumlusu)
        {
            try
            {
                return gorevAtamaPersonelDal.IslemAdimiSorumlusuUpdate(id, islemAdimiSorumlusu);
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
                return gorevAtamaPersonelDal.Get(benzersiz, departman);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GorevAtamaPersonel> GetList(int benzersiz,string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.GetList(benzersiz, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GetListPersonelBazli(string personelAdi)
        {
            try
            {
                return gorevAtamaPersonelDal.GetListPersonelBazli(personelAdi);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }

        public List<GorevAtamaPersonel> GetDevamEdenler(int benzersiz, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.GetDevamEdenler(benzersiz, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaGetList(int benzersizId)
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaGetList(benzersizId);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevliPersoneller()
        {
            try
            {
                return gorevAtamaPersonelDal.GorevliPersoneller();
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public GorevAtamaPersonel GorevSayilari(string personel)
        {
            try
            {
                return gorevAtamaPersonelDal.GorevSayilari(personel);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<GorevAtamaPersonel> PersonelGorevleri(string personel)
        {
            try
            {
                return gorevAtamaPersonelDal.PersonelGorevleri(personel);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> PersonelAtananArizaKayitlari(int benzersizId)
        {
            try
            {
                return gorevAtamaPersonelDal.PersonelAtananArizaKayitlari(benzersizId);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaAtolyeList()
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaAtolyeList();
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> GorevAtamaPersonelGor(int benzersiz, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.GorevAtamaPersonelGor(benzersiz, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimiGor(string adSoyad, string departman)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerim(adSoyad, departman);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimBakimOnarim(string adSoyad)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerimBakimOnarim(adSoyad);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> TamamlananGorevler()
        {
            try
            {
                return gorevAtamaPersonelDal.TamamlananGorevler();
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> TamamlananHataliGorevler(int benzersizId)
        {
            try
            {
                return gorevAtamaPersonelDal.TamamlananHataliGorevler(benzersizId);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<int> HataliGorevler()
        {
            try
            {
                return gorevAtamaPersonelDal.HataliGorevler();
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }
        public int HataliGorevlerId(int id)
        {
            try
            {
                return gorevAtamaPersonelDal.HataliGorevlerId(id);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<GorevAtamaPersonel> IsAkisGorevlerimSatinAlma(string adSoyad)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerimSatinAlma(adSoyad);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimIzin(string adSoyad)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerimIzin(adSoyad);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimAtolye(string adSoyad)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerimAtolye(adSoyad);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<GorevAtamaPersonel> IsAkisGorevlerimMif(string adSoyad)
        {
            try
            {
                return gorevAtamaPersonelDal.IsAkisGorevlerimMif(adSoyad);
            }
            catch (Exception)
            {
                return new List<GorevAtamaPersonel>();
            }
        }
        public List<string> BolumeBagliPersoneller(string bolum)
        {
            try
            {
                return gorevAtamaPersonelDal.BolumeBagliPersoneller(bolum);
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }


        public string Update(GorevAtamaPersonel entity,string yapilanIslmeler="")
        {
            try
            {
                return gorevAtamaPersonelDal.Update(entity, yapilanIslmeler);
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
                return gorevAtamaPersonelDal.SureDuzelt(id, sure);
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
                return gorevAtamaPersonelDal.HataliGorevSil(id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static GorevAtamaPersonelManager GetInstance()
        {
            if (gorevAtamaPersonelManager == null)
            {
                gorevAtamaPersonelManager = new GorevAtamaPersonelManager();
            }
            return gorevAtamaPersonelManager;
        }
    }
}
