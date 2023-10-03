using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class PersonelKayit
    {
        int id; string adsoyad, heskodu, sigortasicilno, ikametgah, kangrubu, esad, estelefon, medenidurumu, esisdurumu, dogumyeri, okul,
            bolum, siparis, sat, butcekodu, butcekalemi, sicil, masyerino, masrafyeri, masrafYeriSorumlusu, sirketmail, oficemail, sirketcep, sirketkisakod, dahilino, isunvani, askerlikdurumu, askerliksinifi, rubesi,
            gorevi, gorevyeri, tecilsebebi, muafnedeni, sirketbolum, tc, cocuksayisi, maas, iase, kirayardimi, diplomanotu, siparisno, dosyayolu, fotoyolu, projeKodu, kgbNo;
        DateTime dogumtarihi, isegiristarihi, kgbTarih; string askerlikbastarihi, askerlikbittarihi, tecilbittarihi, yetkiModu;

        public int Id { get => id; set => id = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Cocuksayisi { get => cocuksayisi; set => cocuksayisi = value; }
        public string Maas { get => maas; set => maas = value; }
        public string Iase { get => iase; set => iase = value; }
        public string Kirayardimi { get => kirayardimi; set => kirayardimi = value; }
        public string Diplomanotu { get => diplomanotu; set => diplomanotu = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Heskodu { get => heskodu; set => heskodu = value; }
        public string Sigortasicilno { get => sigortasicilno; set => sigortasicilno = value; }
        public string Ikametgah { get => ikametgah; set => ikametgah = value; }
        public string Kangrubu { get => kangrubu; set => kangrubu = value; }
        public string Esad { get => esad; set => esad = value; }
        public string Estelefon { get => estelefon; set => estelefon = value; }
        public string Medenidurumu { get => medenidurumu; set => medenidurumu = value; }
        public string Esisdurumu { get => esisdurumu; set => esisdurumu = value; }
        public string Dogumyeri { get => dogumyeri; set => dogumyeri = value; }
        public string Okul { get => okul; set => okul = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Siparis { get => siparis; set => siparis = value; }
        public string Sat { get => sat; set => sat = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }
        public string Butcekalemi { get => butcekalemi; set => butcekalemi = value; }
        public string Sicil { get => sicil; set => sicil = value; }
        public string Masyerino { get => masyerino; set => masyerino = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Sirketmail { get => sirketmail; set => sirketmail = value; }
        public string Oficemail { get => oficemail; set => oficemail = value; }
        public string Sirketcep { get => sirketcep; set => sirketcep = value; }
        public string Sirketkisakod { get => sirketkisakod; set => sirketkisakod = value; }
        public string Dahilino { get => dahilino; set => dahilino = value; }
        public string Isunvani { get => isunvani; set => isunvani = value; }
        public string Askerlikdurumu { get => askerlikdurumu; set => askerlikdurumu = value; }
        public string Askerliksinifi { get => askerliksinifi; set => askerliksinifi = value; }
        public string Rubesi { get => rubesi; set => rubesi = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Gorevyeri { get => gorevyeri; set => gorevyeri = value; }
        public string Tecilsebebi { get => tecilsebebi; set => tecilsebebi = value; }
        public string Muafnedeni { get => muafnedeni; set => muafnedeni = value; }
        public DateTime Dogumtarihi { get => dogumtarihi; set => dogumtarihi = value; }
        public DateTime Isegiristarihi { get => isegiristarihi; set => isegiristarihi = value; }
        public string Askerlikbastarihi { get => askerlikbastarihi; set => askerlikbastarihi = value; }
        public string Askerlikbittarihi { get => askerlikbittarihi; set => askerlikbittarihi = value; }
        public string Tecilbittarihi { get => tecilbittarihi; set => tecilbittarihi = value; }
        public string SiparisNo { get => siparisno; set => siparisno = value; }
        public string Sirketbolum { get => sirketbolum; set => sirketbolum = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Fotoyolu { get => fotoyolu; set => fotoyolu = value; }
        public string MasrafYeriSorumlusu { get => masrafYeriSorumlusu; set => masrafYeriSorumlusu = value; }
        public string ProjeKodu { get => projeKodu; set => projeKodu = value; }
        public string KgbNo { get => kgbNo; set => kgbNo = value; }
        public DateTime KgbTarih { get => kgbTarih; set => kgbTarih = value; }
        public string YetkiModu { get => yetkiModu; set => yetkiModu = value; }

        public PersonelKayit(int id, string adsoyad, string tc, string heskodu, string sigortasicilno, string ikametgah, string kangrubu, string esad,
            string estelefon, DateTime dogumtarihi, string medenidurumu, string esisdurumu, string cocuksayisi, string dogumyeri,
            string okul, string bolum, string diplomanotu, string siparis, string sat, string butcekodu, string butcekalemi,
            string sicil, string masyerino, string masrafyeri, string masrafYeriSorumlusu, string sirketbolum, string sirketmail, string oficemail, string sirketcep, string sirketkisakod,
            string dahilino, string isunvani, DateTime isegiristarihi, string askerlikdurumu, string askerliksinifi, string rubesi, string gorevi, string askerlikbastarihi,
            string askerlikbittarihi, string gorevyeri, string tecilbittarihi, string tecilsebebi, string muafnedeni,
            string siparisno, string dosyayolu, string fotoyolu,string projeKodu,string kgbno, DateTime kgbTarih)
        {
            this.id = id;
            this.tc = tc;
            this.cocuksayisi = cocuksayisi;
            this.diplomanotu = diplomanotu;
            this.adsoyad = adsoyad;
            this.heskodu = heskodu;
            this.sigortasicilno = sigortasicilno;
            this.ikametgah = ikametgah;
            this.kangrubu = kangrubu;
            this.esad = esad;
            this.estelefon = estelefon;
            this.medenidurumu = medenidurumu;
            this.esisdurumu = esisdurumu;
            this.dogumyeri = dogumyeri;
            this.okul = okul;
            this.bolum = bolum;
            this.siparis = siparis;
            this.sat = sat;
            this.butcekodu = butcekodu;
            this.butcekalemi = butcekalemi;
            this.sicil = sicil;
            this.masyerino = masyerino;
            this.masrafyeri = masrafyeri;
            this.sirketmail = sirketmail;
            this.oficemail = oficemail;
            this.sirketcep = sirketcep;
            this.sirketkisakod = sirketkisakod;
            this.dahilino = dahilino;
            this.isunvani = isunvani;
            this.askerlikdurumu = askerlikdurumu;
            this.askerliksinifi = askerliksinifi;
            this.rubesi = rubesi;
            this.gorevi = gorevi;
            this.gorevyeri = gorevyeri;
            this.tecilsebebi = tecilsebebi;
            this.muafnedeni = muafnedeni;
            this.dogumtarihi = dogumtarihi;
            this.isegiristarihi = isegiristarihi;
            this.askerlikbastarihi = askerlikbastarihi;
            this.askerlikbittarihi = askerlikbittarihi;
            this.tecilbittarihi = tecilbittarihi;
            this.siparisno = siparisno;
            this.sirketbolum = sirketbolum;
            this.dosyayolu = dosyayolu;
            this.fotoyolu = fotoyolu;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.projeKodu = projeKodu;
            this.kgbNo = kgbno;
            this.kgbTarih = kgbTarih;
        }
        //kaydet
        public PersonelKayit(string adsoyad, string tc, string heskodu, string sigortasicilno, string ikametgah, string kangrubu, string esad,
            string estelefon, DateTime dogumtarihi, string medenidurumu, string esisdurumu, string cocuksayisi, string dogumyeri,
            string okul, string bolum, string diplomanotu, string siparis, string sat, string butcekodu, string butcekalemi,
            string sicil, string masyerino, string masrafyeri, string masrafYeriSorumlusu, string sirketbolum, string sirketmail, string oficemail, string sirketcep, string sirketkisakod,
            string dahilino, string isunvani, DateTime isegiristarihi, string askerlikdurumu, string askerliksinifi, string rubesi, string gorevi, string askerlikbastarihi,
            string askerlikbittarihi, string gorevyeri, string tecilbittarihi, string tecilsebebi, string muafnedeni,
            string siparisno, string dosyayolu, string fotoyolu,string projeKodu,string kgbNo,DateTime kgbTarih, string yetkiModu)
        {
            this.tc = tc;
            this.cocuksayisi = cocuksayisi;
            this.diplomanotu = diplomanotu;
            this.adsoyad = adsoyad;
            this.heskodu = heskodu;
            this.sigortasicilno = sigortasicilno;
            this.ikametgah = ikametgah;
            this.kangrubu = kangrubu;
            this.esad = esad;
            this.estelefon = estelefon;
            this.medenidurumu = medenidurumu;
            this.esisdurumu = esisdurumu;
            this.dogumyeri = dogumyeri;
            this.okul = okul;
            this.bolum = bolum;
            this.siparis = siparis;
            this.sat = sat;
            this.butcekodu = butcekodu;
            this.butcekalemi = butcekalemi;
            this.sicil = sicil;
            this.masyerino = masyerino;
            this.masrafyeri = masrafyeri;
            this.sirketmail = sirketmail;
            this.oficemail = oficemail;
            this.sirketcep = sirketcep;
            this.sirketkisakod = sirketkisakod;
            this.dahilino = dahilino;
            this.isunvani = isunvani;
            this.askerlikdurumu = askerlikdurumu;
            this.askerliksinifi = askerliksinifi;
            this.rubesi = rubesi;
            this.gorevi = gorevi;
            this.gorevyeri = gorevyeri;
            this.tecilsebebi = tecilsebebi;
            this.muafnedeni = muafnedeni;
            this.dogumtarihi = dogumtarihi;
            this.isegiristarihi = isegiristarihi;
            this.askerlikbastarihi = askerlikbastarihi;
            this.askerlikbittarihi = askerlikbittarihi;
            this.tecilbittarihi = tecilbittarihi;
            this.siparisno = siparisno;
            this.sirketbolum = sirketbolum;
            this.dosyayolu = dosyayolu;
            this.fotoyolu = fotoyolu;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.projeKodu = projeKodu;
            this.kgbNo = kgbNo;
            this.kgbTarih = kgbTarih;
            this.YetkiModu = yetkiModu;
        }

        public PersonelKayit(int id, string adsoyad, string tc, string heskodu, string sigortasicilno, string ikametgah, string kangrubu, string esad,
            string estelefon, DateTime dogumtarihi, string medenidurumu, string esisdurumu, string cocuksayisi, string dogumyeri,
            string okul, string bolum, string diplomanotu, string siparis, string sat, string butcekodu, string butcekalemi,
            string sicil, string masyerino, string masrafyeri, string masrafYeriSorumlusu, string sirketbolum, string sirketmail, string oficemail, string sirketcep, string sirketkisakod,
            string dahilino, string isunvani, DateTime isegiristarihi, string askerlikdurumu, string askerliksinifi, string rubesi, string gorevi, string askerlikbastarihi,
            string askerlikbittarihi, string gorevyeri, string tecilbittarihi, string tecilsebebi, string muafnedeni,string projeKodu, string kgbno,DateTime kgbTarih)
        {
            this.id = id;
            this.adsoyad = adsoyad;
            this.heskodu = heskodu;
            this.sigortasicilno = sigortasicilno;
            this.ikametgah = ikametgah;
            this.kangrubu = kangrubu;
            this.esad = esad;
            this.estelefon = estelefon;
            this.medenidurumu = medenidurumu;
            this.esisdurumu = esisdurumu;
            this.dogumyeri = dogumyeri;
            this.okul = okul;
            this.bolum = bolum;
            this.siparis = siparis;
            this.sat = sat;
            this.butcekodu = butcekodu;
            this.butcekalemi = butcekalemi;
            this.sicil = sicil;
            this.masyerino = masyerino;
            this.masrafyeri = masrafyeri;
            this.sirketmail = sirketmail;
            this.oficemail = oficemail;
            this.sirketcep = sirketcep;
            this.sirketkisakod = sirketkisakod;
            this.dahilino = dahilino;
            this.isunvani = isunvani;
            this.askerlikdurumu = askerlikdurumu;
            this.askerliksinifi = askerliksinifi;
            this.rubesi = rubesi;
            this.gorevi = gorevi;
            this.gorevyeri = gorevyeri;
            this.tecilsebebi = tecilsebebi;
            this.muafnedeni = muafnedeni;
            this.sirketbolum = sirketbolum;
            this.tc = tc;
            this.cocuksayisi = cocuksayisi;
            this.diplomanotu = diplomanotu;
            this.dogumtarihi = dogumtarihi;
            this.isegiristarihi = isegiristarihi;
            this.askerlikbastarihi = askerlikbastarihi;
            this.askerlikbittarihi = askerlikbittarihi;
            this.tecilbittarihi = tecilbittarihi;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.projeKodu = projeKodu;
            this.kgbNo = kgbno;
            this.kgbTarih = kgbTarih;
        }

        public PersonelKayit(string oficemail)
        {
            this.oficemail = oficemail;
        }

        public PersonelKayit(string adsoyad, string sirketbolum, string projeKodu) : this(adsoyad)
        {
            this.sirketbolum = sirketbolum;
            this.projeKodu = projeKodu;
        }

        public PersonelKayit(int id, string adsoyad)
        {
            this.id = id;
            this.adsoyad = adsoyad;
        }

        public PersonelKayit(int id, string adsoyad, string siparis, string masyerino, string masrafYeriSorumlusu, string sirketmail, string gorevi, string sirketbolum, string projeKodu) : this(id, adsoyad)
        {
            this.siparis = siparis;
            this.masyerino = masyerino;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
            this.sirketmail = sirketmail;
            this.gorevi = gorevi;
            this.sirketbolum = sirketbolum;
            this.projeKodu = projeKodu;
        }

        public PersonelKayit(string adsoyad, string sicil, string sirketmail, string sirketcep, string sirketkisakod, string isunvani, string sirketbolum, string fotoyolu)
        {
            this.adsoyad= adsoyad;
            this.sicil= sicil;
            this.sirketmail=sirketmail;
            this.sirketcep = sirketcep;
            this.sirketkisakod = sirketkisakod;
            this.isunvani = isunvani;
            this.sirketbolum = sirketbolum;
            this.fotoyolu = fotoyolu;
        }
    }
}
