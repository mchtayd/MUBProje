using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ZimmetAktarim
    {
        int id, dvno,isAkisNo; string dvEtiketNo, dvTanim, dvMarka, dvModel, seriNo, durumu, miktar, islemTuru, personelAd, sicil, masYeriNo, masYeri, masYeriSorumlusu, bolum; string aktarimTarihi; string depoAdresi, lokasyon, lokasyonBilgi, aktarimGerekcesi, sayfa, fotoYolu, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public int Dvno { get => dvno; set => dvno = value; }
        public string DvEtiketNo { get => dvEtiketNo; set => dvEtiketNo = value; }
        public string DvTanim { get => dvTanim; set => dvTanim = value; }
        public string DvMarka { get => dvMarka; set => dvMarka = value; }
        public string DvModel { get => dvModel; set => dvModel = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Durumu { get => durumu; set => durumu = value; }
        public string Miktar { get => miktar; set => miktar = value; }
        public string IslemTuru { get => islemTuru; set => islemTuru = value; }
        public string PersonelAd { get => personelAd; set => personelAd = value; }
        public string Sicil { get => sicil; set => sicil = value; }
        public string MasYeriNo { get => masYeriNo; set => masYeriNo = value; }
        public string MasYeri { get => masYeri; set => masYeri = value; }
        public string MasYeriSorumlusu { get => masYeriSorumlusu; set => masYeriSorumlusu = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string AktarimTarihi { get => aktarimTarihi; set => aktarimTarihi = value; }
        public string DepoAdresi { get => depoAdresi; set => depoAdresi = value; }
        public string Lokasyon { get => lokasyon; set => lokasyon = value; }
        public string LokasyonBilgi { get => lokasyonBilgi; set => lokasyonBilgi = value; }
        public string AktarimGerekcesi { get => aktarimGerekcesi; set => aktarimGerekcesi = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string FotoYolu { get => fotoYolu; set => fotoYolu = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }

        public ZimmetAktarim(int id, int isAkisNo,int dvno, string dvEtiketNo, string dvTanim, string dvMarka, string dvModel, string seriNo, string durumu, string miktar, string islemTuru, string personelAd, string sicil, string masYeriNo, string masYeri, string masYeriSorumlusu, string bolum, string aktarimTarihi, string depoAdresi, string lokasyon, string lokasyonBilgi, string aktarimGerekcesi, string sayfa,string fotoYolu,string dosyaYolu)
        {
            this.id = id;
            this.dvno = dvno;
            this.dvEtiketNo = dvEtiketNo;
            this.dvTanim = dvTanim;
            this.dvMarka = dvMarka;
            this.dvModel = dvModel;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
            this.islemTuru = islemTuru;
            this.personelAd = personelAd;
            this.sicil = sicil;
            this.masYeriNo = masYeriNo;
            this.masYeri = masYeri;
            this.masYeriSorumlusu = masYeriSorumlusu;
            this.bolum = bolum;
            this.aktarimTarihi = aktarimTarihi;
            this.depoAdresi = depoAdresi;
            this.lokasyon = lokasyon;
            this.lokasyonBilgi = lokasyonBilgi;
            this.aktarimGerekcesi = aktarimGerekcesi;
            this.sayfa = sayfa;
            this.fotoYolu = fotoYolu;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }

        public ZimmetAktarim(int dvno, int isAkisNo,string dvEtiketNo, string dvTanim, string dvMarka, string dvModel, string seriNo, string durumu, string miktar, string islemTuru, string personelAd, string sicil, string masYeriNo, string masYeri, string masYeriSorumlusu, string bolum, string aktarimTarihi, string depoAdresi, string lokasyon, string lokasyonBilgi, string aktarimGerekcesi, string fotoYolu,string dosyaYolu)
        {
            this.dvno = dvno;
            this.dvEtiketNo = dvEtiketNo;
            this.dvTanim = dvTanim;
            this.dvMarka = dvMarka;
            this.dvModel = dvModel;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
            this.islemTuru = islemTuru;
            this.personelAd = personelAd;
            this.sicil = sicil;
            this.masYeriNo = masYeriNo;
            this.masYeri = masYeri;
            this.masYeriSorumlusu = masYeriSorumlusu;
            this.bolum = bolum;
            this.aktarimTarihi = aktarimTarihi;
            this.depoAdresi = depoAdresi;
            this.lokasyon = lokasyon;
            this.lokasyonBilgi = lokasyonBilgi;
            this.aktarimGerekcesi = aktarimGerekcesi;
            this.FotoYolu = fotoYolu;
            this.dosyaYolu = dosyaYolu;
            this.isAkisNo = isAkisNo;
        }

        public ZimmetAktarim(int dvno, string dvEtiketNo, string dvTanim, string dvMarka, string dvModel, string seriNo, string durumu, string miktar)
        {
            this.dvno = dvno;
            this.dvEtiketNo = dvEtiketNo;
            this.dvTanim = dvTanim;
            this.dvMarka = dvMarka;
            this.dvModel = dvModel;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
        }

        public ZimmetAktarim(string personelAd, string bolum)
        {
            this.personelAd = personelAd;
            this.bolum = bolum;
        }
    }
}
