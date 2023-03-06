using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class SiparisPersonel
    {
        int id; string siparis, personel, bolum, masrafyerino, projekodu, masrafyeri, tc, hes, mail, kisakod, gorevi, sicil,masrafYeriSorumlusu;

        public int Id { get => id; set => id = value; }
        public string Siparis { get => siparis; set => siparis = value; }
        public string Personel { get => personel; set => personel = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public string Masrafyerino { get => masrafyerino; set => masrafyerino = value; }
        public string Projekodu { get => projekodu; set => projekodu = value; }
        public string Masrafyeri { get => masrafyeri; set => masrafyeri = value; }
        public string Tc { get => tc; set => tc = value; }
        public string Hes { get => hes; set => hes = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Kisakod { get => kisakod; set => kisakod = value; }
        public string Gorevi { get => gorevi; set => gorevi = value; }
        public string Sicil { get => sicil; set => sicil = value; }
        public string MasrafYeriSorumlusu { get => masrafYeriSorumlusu; set => masrafYeriSorumlusu = value; }

        public SiparisPersonel(int id, string siparis, string personel, string bolum, string masrafyerino, string projekodu, string masrafyeri, string tc, string hes, string mail, string kisakod, string gorevi,string sicil,string masrafYeriSorumlusu)
        {
            this.id = id;
            this.siparis = siparis;
            this.personel = personel;
            this.bolum = bolum;
            this.masrafyerino = masrafyerino;
            this.projekodu = projekodu;
            this.masrafyeri = masrafyeri;
            this.tc = tc;
            this.hes = hes;
            this.mail = mail;
            this.kisakod = kisakod;
            this.gorevi = gorevi;
            this.sicil = sicil;
            this.masrafYeriSorumlusu = masrafYeriSorumlusu;
        }

        public SiparisPersonel(string siparis, string personel)
        {
            this.siparis = siparis;
            this.personel = personel;
        }

    }
}
