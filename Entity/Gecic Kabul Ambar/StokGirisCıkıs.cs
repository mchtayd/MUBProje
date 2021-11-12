using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class StokGirisCıkıs
    {
        int id; string islemturu, stokno, tanim; int miktar; string birim; DateTime istenentarih; string depono, depoadresi, malzemeyeri, aciklama,serino,lotno,revizyon;

        public int Id { get => id; set => id = value; }
        public string Islemturu { get => islemturu; set => islemturu = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public DateTime Istenentarih { get => istenentarih; set => istenentarih = value; }
        public string Depono { get => depono; set => depono = value; }
        public string Depoadresi { get => depoadresi; set => depoadresi = value; }
        public string Malzemeyeri { get => malzemeyeri; set => malzemeyeri = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Serino { get => serino; set => serino = value; }
        public string Lotno { get => lotno; set => lotno = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }

        public StokGirisCıkıs(int id, string islemturu, string stokno, string tanim, int miktar, string birim, DateTime istenentarih, string depono, string depoadresi, string malzemeyeri, string aciklama)
        {
            this.id = id;
            this.islemturu = islemturu;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.istenentarih = istenentarih;
            this.depono = depono;
            this.depoadresi = depoadresi;
            this.malzemeyeri = malzemeyeri;
            this.aciklama = aciklama;
        }

        public StokGirisCıkıs(string islemturu, string stokno, string tanim, int miktar, string birim, DateTime istenentarih, string depono, string depoadresi, string malzemeyeri, string aciklama)
        {
            this.islemturu = islemturu;
            this.stokno = stokno;
            this.tanim = tanim;
            this.miktar = miktar;
            this.birim = birim;
            this.istenentarih = istenentarih;
            this.depono = depono;
            this.depoadresi = depoadresi;
            this.malzemeyeri = malzemeyeri;
            this.aciklama = aciklama;
        }

        public StokGirisCıkıs(string islemturu, string stokno, string tanim, int miktar, string birim, DateTime istenentarih, string depono, string depoadresi, string malzemeyeri, string aciklama, string serino, string lotno, string revizyon) : this(islemturu, stokno, tanim, miktar, birim, istenentarih, depono, depoadresi, malzemeyeri, aciklama)
        {
            this.serino = serino;
            this.lotno = lotno;
            this.revizyon = revizyon;
        }
    }
}
