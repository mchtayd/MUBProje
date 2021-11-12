using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class IstenAyrilis
    {
        int id;
        string adsoyad, siparis, sat, butcekodu, butcekalemi, sicil, masyerino, masrafyeri, sirketbolum,sirketmail, oficemail, sirketcep, sirketkisakod, dahilino, isunvani, ayrilisnedeni,
            istenayrilisaciklama, dosyayolu, tc,hes,sigortasicilno,ikametgah,kan,esad,estelefon,medenidurumu,esisdurumu,cocuksayisi,dogumyeri,askerlikdurumu,askerliksinifi,rutbesi,
            gorevi,gorevyeri,tecilsebebi,muafnedeni,okul,okulbolum,dipnotu,siparisno;
        DateTime dogumtarihi, isegiristarihi, istenayrilistarihi;string askerlikbastarihi, askerlikbittarihi, tecilbittarihi;
        public int Id { get => id; set => id = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
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
        public string Ayrilisnedeni { get => ayrilisnedeni; set => ayrilisnedeni = value; }
        public string Istenayrilisaciklama { get => istenayrilisaciklama; set => istenayrilisaciklama = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Hes { get => hes; set => hes = value; }
        public string Sigortasicilno { get => sigortasicilno; set => sigortasicilno = value; }
        public string Ikametgah { get => ikametgah; set => ikametgah = value; }
        public string Kan { get => kan; set => kan = value; }
        public string Esad { get => esad; set => esad = value; }
        public string Estelefon { get => estelefon; set => estelefon = value; }
        public string Medenidurumu { get => medenidurumu; set => medenidurumu = value; }
        public string Esisdurumu { get => esisdurumu; set => esisdurumu = value; }
        public string Cocuksayisi { get => cocuksayisi; set => cocuksayisi = value; }
        public string Dogumyeri { get => dogumyeri; set => dogumyeri = value; }
        public string Askerlikdurumu { get => askerlikdurumu; set => askerlikdurumu = value; }
        public string Askerliksinifi { get => askerliksinifi; set => askerliksinifi = value; }
        public string Rutbesi { get => rutbesi; set => rutbesi = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Tecilsebebi { get => tecilsebebi; set => tecilsebebi = value; }
        public string Muafnedeni { get => muafnedeni; set => muafnedeni = value; }
        public string Okul { get => okul; set => okul = value; }
        public string Okulbolum { get => okulbolum; set => okulbolum = value; }
        public string Dipnotu { get => dipnotu; set => dipnotu = value; }
        public DateTime Dogumtarihi { get => dogumtarihi; set => dogumtarihi = value; }
        public DateTime Isegiristarihi { get => isegiristarihi; set => isegiristarihi = value; }
        public DateTime Istenayrilistarihi { get => istenayrilistarihi; set => istenayrilistarihi = value; }
        public string Askerlikbastarihi { get => askerlikbastarihi; set => askerlikbastarihi = value; }
        public string Askerlikbittarihi { get => askerlikbittarihi; set => askerlikbittarihi = value; }
        public string Tecilbittarihi { get => tecilbittarihi; set => tecilbittarihi = value; }
        public string Sirketbolum { get => sirketbolum; set => sirketbolum = value; }
        public string Gorevyeri { get => gorevyeri; set => gorevyeri = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }

        public IstenAyrilis(int id, string adsoyad, string siparis, string sat, string butcekodu, string butcekalemi, string sicil, string masyerino, string masrafyeri,string sirketbolum ,string sirketmail, 
            string oficemail, string sirketcep, string sirketkisakod, string dahilino, string isunvani, DateTime isegiristarihi, DateTime istenayrilistarihi, string ayrilisnedeni, string istenayrilisaciklama, string dosyayolu, 
            string tc, string hes, string sigortasicilno, string ikametgah, string kan, string esad, string estelefon, DateTime dogumtarihi, string medenidurumu, string esisdurumu, string cocuksayisi, string dogumyeri, 
            string askerlikdurumu, string askerliksinifi, string rutbesi, string gorevi,string gorevyeri, string askerlikbastarihi, string askerlikbittarihi, string tecilbittarihi, string tecilsebebi, string muafnedeni, string okul, string okulbolum, string dipnotu, string siparisno)
        {
            this.id = id;
            this.adsoyad = adsoyad;
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
            this.ayrilisnedeni = ayrilisnedeni;
            this.istenayrilisaciklama = istenayrilisaciklama;
            this.dosyayolu = dosyayolu;
            this.tc = tc;
            this.hes = hes;
            this.sigortasicilno = sigortasicilno;
            this.ikametgah = ikametgah;
            this.kan = kan;
            this.esad = esad;
            this.estelefon = estelefon;
            this.medenidurumu = medenidurumu;
            this.esisdurumu = esisdurumu;
            this.cocuksayisi = cocuksayisi;
            this.dogumyeri = dogumyeri;
            this.askerlikdurumu = askerlikdurumu;
            this.askerliksinifi = askerliksinifi;
            this.rutbesi = rutbesi;
            this.gorevi = gorevi;
            this.tecilsebebi = tecilsebebi;
            this.muafnedeni = muafnedeni;
            this.okul = okul;
            this.okulbolum = okulbolum;
            this.dipnotu = dipnotu;
            this.dogumtarihi = dogumtarihi;
            this.isegiristarihi = isegiristarihi;
            this.istenayrilistarihi = istenayrilistarihi;
            this.askerlikbastarihi = askerlikbastarihi;
            this.askerlikbittarihi = askerlikbittarihi;
            this.tecilbittarihi = tecilbittarihi;
            this.sirketbolum = sirketbolum;
            this.gorevyeri = gorevyeri;
            this.siparisno = siparisno;
        }

        public IstenAyrilis (string adsoyad, string siparis, string sat, string butcekodu, string butcekalemi, string sicil, string masyerino, string masrafyeri, string sirketbolum, string sirketmail,
            string oficemail, string sirketcep, string sirketkisakod, string dahilino, string isunvani, DateTime isegiristarihi, DateTime istenayrilistarihi, string ayrilisnedeni, string istenayrilisaciklama, string dosyayolu,
            string tc, string hes, string sigortasicilno, string ikametgah, string kan, string esad, string estelefon, DateTime dogumtarihi, string medenidurumu, string esisdurumu, string cocuksayisi, string dogumyeri,
            string askerlikdurumu, string askerliksinifi, string rutbesi, string gorevi, string gorevyeri, string askerlikbastarihi, string askerlikbittarihi, string tecilbittarihi, string tecilsebebi, string muafnedeni, string okul, string okulbolum, string dipnotu,string siparisno)
        {
            this.adsoyad = adsoyad;
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
            this.ayrilisnedeni = ayrilisnedeni;
            this.istenayrilisaciklama = istenayrilisaciklama;
            this.dosyayolu = dosyayolu;
            this.tc = tc;
            this.hes = hes;
            this.sigortasicilno = sigortasicilno;
            this.ikametgah = ikametgah;
            this.kan = kan;
            this.esad = esad;
            this.estelefon = estelefon;
            this.medenidurumu = medenidurumu;
            this.esisdurumu = esisdurumu;
            this.cocuksayisi = cocuksayisi;
            this.dogumyeri = dogumyeri;
            this.askerlikdurumu = askerlikdurumu;
            this.askerliksinifi = askerliksinifi;
            this.rutbesi = rutbesi;
            this.gorevi = gorevi;
            this.tecilsebebi = tecilsebebi;
            this.muafnedeni = muafnedeni;
            this.okul = okul;
            this.okulbolum = okulbolum;
            this.dipnotu = dipnotu;
            this.dogumtarihi = dogumtarihi;
            this.isegiristarihi = isegiristarihi;
            this.istenayrilistarihi = istenayrilistarihi;
            this.askerlikbastarihi = askerlikbastarihi;
            this.askerlikbittarihi = askerlikbittarihi;
            this.tecilbittarihi = tecilbittarihi;
            this.sirketbolum = sirketbolum;
            this.gorevyeri = gorevyeri;
            this.siparisno = siparisno;
        }
    }
}
