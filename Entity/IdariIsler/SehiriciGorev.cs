using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class SehiriciGorev
    {
        int id, isakisno; string proje, gidilecekyer, gorevinkonusu; DateTime baslamatarihi, bitistarihi; string toplamsure, siparisno, adsoyad, unvani, masrafyerno, masrafyeri, islemadimi, gecensure, sayfa; int personelid; 

        public int Id { get => id; set => id = value; }
        public int Isakisno { get => isakisno; set => isakisno = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Gidilecekyer { get => gidilecekyer; set => gidilecekyer = value; }
        public string Gorevinkonusu { get => gorevinkonusu; set => gorevinkonusu = value; }
        public DateTime Baslamatarihi { get => baslamatarihi; set => baslamatarihi = value; }
        public DateTime Bitistarihi { get => bitistarihi; set => bitistarihi = value; }
        public string Toplamsure { get => toplamsure; set => toplamsure = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public string Adsoyad { get => adsoyad; set => adsoyad = value; }
        public string Masrafyerno { get => masrafyerno; set => masrafyerno = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Islemadimi { get => islemadimi; set => islemadimi = value; }
        public int Personelid { get => personelid; set => personelid = value; }
        public string Unvani { get => unvani; set => unvani = value; }
        public string Gecensure { get => gecensure; set => gecensure = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }

        public SehiriciGorev(int isakisno, string proje, string gidilecekyer, string gorevinkonusu, DateTime baslamatarihi, string siparisno, string adsoyad, string unvani, string masrafyerno, string masrafyeri, string islemadimi, int personelid)
        {
            this.Id = id;
            this.Isakisno = isakisno;
            this.Gidilecekyer = gidilecekyer;
            this.Gorevinkonusu = gorevinkonusu;
            this.Baslamatarihi = baslamatarihi;
            this.Siparisno = siparisno;
            this.Adsoyad = adsoyad;
            this.Masrafyerno = masrafyerno;
            this.Masrafyeri = masrafyeri;
            this.Proje = proje;
            this.islemadimi = islemadimi;
            this.personelid = personelid;
            this.unvani = unvani;
        }

        public SehiriciGorev(int id, int isakisno, string proje, string gidilecekyer, string gorevinkonusu, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string siparisno, string adsoyad, string unvani, string masrafyerno, string masrafyeri,
            string islemadimi, int personelid,string sayfa)
        {
            this.id = id;
            this.isakisno = isakisno;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.gorevinkonusu = gorevinkonusu;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerno = masrafyerno;
            this.masrafyeri = masrafyeri;
            this.islemadimi = islemadimi;
            this.personelid = personelid;
            this.unvani = unvani;
            this.sayfa = sayfa;
        }

        public SehiriciGorev(int isakisno, string proje, string gidilecekyer, string gorevinkonusu, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string siparisno, string adsoyad, string unvani, string masrafyerno, string masrafyeri)
        {
            this.isakisno = isakisno;
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.gorevinkonusu = gorevinkonusu;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.masrafyerno = masrafyerno;
            this.unvani = unvani;
            this.masrafyeri = masrafyeri;
        }

        public SehiriciGorev(int isakisno, DateTime bitistarihi, string toplamsure)
        {
            this.isakisno = isakisno;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
        }

        public SehiriciGorev(string proje, string gidilecekyer, string gorevinkonusu, DateTime baslamatarihi, DateTime bitistarihi, string toplamsure, string siparisno, string adsoyad, string unvani, string masrafyerno, string masrafyeri,string islemadimi)
        {
            this.proje = proje;
            this.gidilecekyer = gidilecekyer;
            this.gorevinkonusu = gorevinkonusu;
            this.baslamatarihi = baslamatarihi;
            this.bitistarihi = bitistarihi;
            this.toplamsure = toplamsure;
            this.siparisno = siparisno;
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.masrafyerno = masrafyerno;
            this.masrafyeri = masrafyeri;
            this.islemadimi = islemadimi;
        }

        public SehiriciGorev(string gorevinkonusu, DateTime baslamatarihi, string adsoyad, string unvani, string gecensure)
        {
            this.gorevinkonusu = gorevinkonusu;
            this.baslamatarihi = baslamatarihi;
            this.adsoyad = adsoyad;
            this.unvani = unvani;
            this.gecensure = gecensure;
        }
    }
}
