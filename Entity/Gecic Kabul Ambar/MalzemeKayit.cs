using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class MalzemeKayit
    {
        int id; string stokno, tanim, birim, tedarikcifirma, malzemeonarimdurumu, malzemeonarımyeri, malzemeturu, malzemetakipdurumu, malzemerevizyon, malzemekul, aciklama, dosyayolu, alternatifMalzeme;

        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Tedarikcifirma { get => tedarikcifirma; set => tedarikcifirma = value; }
        public string Malzemeonarimdurumu { get => malzemeonarimdurumu; set => malzemeonarimdurumu = value; }
        public string Malzemeonarımyeri { get => malzemeonarımyeri; set => malzemeonarımyeri = value; }
        public string Malzemeturu { get => malzemeturu; set => malzemeturu = value; }
        public string Malzemetakipdurumu { get => malzemetakipdurumu; set => malzemetakipdurumu = value; }
        public string Malzemerevizyon { get => malzemerevizyon; set => malzemerevizyon = value; }
        public string Malzemekul { get => malzemekul; set => malzemekul = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string AlternatifMalzeme { get => alternatifMalzeme; set => alternatifMalzeme = value; }

        public MalzemeKayit(int id, string stokno, string tanim, string birim, string tedarikcifirma, string malzemeonarimdurumu, string malzemeonarımyeri, string malzemeturu, string malzemetakipdurumu, string malzemerevizyon, string malzemekul, string aciklama, string dosyayolu,string alternatifMalzeme)
        {
            this.Id = id;
            this.stokno = stokno;
            this.Tanim = tanim;
            this.Birim = birim;
            this.Tedarikcifirma = tedarikcifirma;
            this.Malzemeonarimdurumu = malzemeonarimdurumu;
            this.Malzemeonarımyeri = malzemeonarımyeri;
            this.Malzemeturu = malzemeturu;
            this.Malzemetakipdurumu = malzemetakipdurumu;
            this.Malzemerevizyon = malzemerevizyon;
            this.Malzemekul = malzemekul;
            this.Aciklama = aciklama;
            this.Dosyayolu = dosyayolu;
            this.alternatifMalzeme = alternatifMalzeme;
        }

        public MalzemeKayit(string stokno, string tanim, string birim, string tedarikcifirma, string malzemeonarimdurumu, string malzemeonarımyeri, string malzemeturu, string malzemetakipdurumu, string malzemerevizyon, string malzemekul, string aciklama, string dosyayolu, string alternatifMalzeme)
        {
            this.stokno = stokno;
            this.Tanim = tanim;
            this.Birim = birim;
            this.Tedarikcifirma = tedarikcifirma;
            this.Malzemeonarimdurumu = malzemeonarimdurumu;
            this.Malzemeonarımyeri = malzemeonarımyeri;
            this.Malzemeturu = malzemeturu;
            this.Malzemetakipdurumu = malzemetakipdurumu;
            this.Malzemerevizyon = malzemerevizyon;
            this.Malzemekul = malzemekul;
            this.Aciklama = aciklama;
            this.Dosyayolu = dosyayolu;
            this.alternatifMalzeme = alternatifMalzeme;
        }
    }
}
