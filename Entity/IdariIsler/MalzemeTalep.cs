using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class MalzemeTalep
    {
        int id; string malzemeKategorisi, talepEdenPersonel, tanim, stokNo; int miktar; string birim, talebiOlusturan, bolum; int satBilgisi; string masrafYeri;

        public int Id { get => id; set => id = value; }
        public string MalzemeKategorisi { get => malzemeKategorisi; set => malzemeKategorisi = value; }
        public string TalepEdenPersonel { get => talepEdenPersonel; set => talepEdenPersonel = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string TalebiOlusturan { get => talebiOlusturan; set => talebiOlusturan = value; }
        public string Bolum { get => bolum; set => bolum = value; }
        public int SatBilgisi { get => satBilgisi; set => satBilgisi = value; }
        public string MasrafYeri { get => masrafYeri; set => masrafYeri = value; }

        public MalzemeTalep(int id, string malzemeKategorisi, string talepEdenPersonel, string tanim, string stokNo, int miktar, string birim, string talebiOlusturan, string bolum, int satBilgisi, string masrafYeri)
        {
            this.id = id;
            this.malzemeKategorisi = malzemeKategorisi;
            this.talepEdenPersonel = talepEdenPersonel;
            this.tanim = tanim;
            this.stokNo = stokNo;
            this.miktar = miktar;
            this.birim = birim;
            this.talebiOlusturan = talebiOlusturan;
            this.bolum = bolum;
            this.satBilgisi = satBilgisi;
            this.masrafYeri = masrafYeri;
        }

        public MalzemeTalep(string malzemeKategorisi, string talepEdenPersonel, string tanim, string stokNo, int miktar, string birim, string talebiOlusturan, string bolum,string masrafYeri)
        {
            this.malzemeKategorisi = malzemeKategorisi;
            this.talepEdenPersonel = talepEdenPersonel;
            this.tanim = tanim;
            this.stokNo = stokNo;
            this.miktar = miktar;
            this.birim = birim;
            this.talebiOlusturan = talebiOlusturan;
            this.bolum = bolum;
            this.masrafYeri = masrafYeri;
        }
    }
}
