using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Konaklama
    {
        int id,isakisno; string talepturu, formno, butcekodu, siparisno, adsoyad, gorevi, masrafyerino, masrafyeri,tc; string hes, email, kisakod, otelsehir, otelad; double gunukucret, toplamucret; DateTime giristarihi, cikistarihi; string konaklamasuresi, onay, dosyayolu, sayfa; int satNo; string donem, gerekce;

        public int Id { get => id; set => id = value; }
        public string Talepturu { get => talepturu; set => talepturu = value; }
        public string Formno { get => formno; set => formno = value; }
        public string Butcekodu { get => butcekodu; set => butcekodu = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Hes { get => hes; set => hes = value; }
        public string Email { get => email; set => email = value; }
        public string Kisakod { get => kisakod; set => kisakod = value; }
        public string Otelsehir { get => otelsehir; set => otelsehir = value; }
        public string Otelad { get => otelad; set => otelad = value; }
        public double Gunukucret { get => gunukucret; set => gunukucret = value; }
        public double Toplamucret { get => toplamucret; set => toplamucret = value; }
        public DateTime Giristarihi { get => giristarihi; set => giristarihi = value; }
        public DateTime Cikistarihi { get => cikistarihi; set => cikistarihi = value; }
        public string Konaklamasuresi { get => konaklamasuresi; set => konaklamasuresi = value; }
        public string Onay { get => onay; set => onay = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public int SatNo { get => satNo; set => satNo = value; }
        public string Donem { get => donem; set => donem = value; }
        public string Gerekce { get => gerekce; set => gerekce = value; }

        public Konaklama(int id, int isakisno, string talepturu, string formno,string butcekodu, string siparisno, string adsoyad, string gorevi, string masrafyerino, string masrafyeri, string tc, string hes, string email, string kisakod, string otelsehir, string otelad, double gunlukucret, double toplamucret, DateTime giristarihi, DateTime cikistarihi, string konaklamasuresi, string onay,string dosyayolu, string sayfa,int satNo,string donem,string gerekce)
        {
            this.Id = id;
            this.isakisno = isakisno;
            this.Talepturu = talepturu;
            this.Butcekodu = butcekodu;
            this.Siparisno = siparisno;
            this.Adsoyad = adsoyad;
            this.Gorevi = gorevi;
            this.Masrafyerino = masrafyerino;
            this.Masrafyeri = masrafyeri;
            this.Tc = tc;
            this.Hes = hes;
            this.Email = email;
            this.Kisakod = kisakod;
            this.Otelsehir = otelsehir;
            this.Otelad = otelad;
            this.Giristarihi = giristarihi;
            this.Cikistarihi = cikistarihi;
            this.Konaklamasuresi = konaklamasuresi;
            this.Onay = onay;
            this.Formno = formno;
            this.gunukucret = gunlukucret;
            this.toplamucret = toplamucret;
            this.dosyayolu = dosyayolu;
            this.sayfa = sayfa;
            this.satNo = satNo;
            this.donem = donem;
            this.gerekce = gerekce;
        }

        public Konaklama(int isakisno,string talepturu, string formno,string butcekodu, string siparisno, string adsoyad, string gorevi, string masrafyerino, string masrafyeri, string tc, string hes, string email, string kisakod, string otelsehir, string otelad, double gunlukucret, double toplamucret, DateTime giristarihi, DateTime cikistarihi, string konaklamasuresi,string dosyayolu, int satNo, string donem, string gerekce)
        {
            this.Talepturu = talepturu;
            this.Butcekodu = butcekodu;
            this.Siparisno = siparisno;
            this.Adsoyad = adsoyad;
            this.Gorevi = gorevi;
            this.Masrafyerino = masrafyerino;
            this.Masrafyeri = masrafyeri;
            this.Tc = tc;
            this.Hes = hes;
            this.Email = email;
            this.Kisakod = kisakod;
            this.Otelsehir = otelsehir;
            this.Otelad = otelad;
            this.Giristarihi = giristarihi;
            this.Cikistarihi = cikistarihi;
            this.Konaklamasuresi = konaklamasuresi;
            this.Formno = formno;
            this.gunukucret = gunlukucret;
            this.toplamucret = toplamucret;
            this.dosyayolu = dosyayolu;
            this.isakisno = isakisno;
            this.satNo = satNo;
            this.donem = donem;
            this.gerekce = gerekce;
        }


    }
}
