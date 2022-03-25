using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class MalzemeKayit
    {
        int id; string stokno, tanim, birim, tedarikcifirma, malzemeonarimdurumu, malzemeonarımyeri, malzemeturu, malzemetakipdurumu, malzemekul, aciklama, dosyayolu, alternatifMalzeme, sistemStokNo, sistemTanim, sistemPersonel; bool kayitDurumu; string seriNo, durum, revizyon; int miktar; string talepTarihi;

        public MalzemeKayit DataTypeValue { get; set; }
        public int Id { get => id; set => id = value; }
        public string Stokno { get => stokno; set => stokno = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public string Tedarikcifirma { get => tedarikcifirma; set => tedarikcifirma = value; }
        public string Malzemeonarimdurumu { get => malzemeonarimdurumu; set => malzemeonarimdurumu = value; }
        public string Malzemeonarımyeri { get => malzemeonarımyeri; set => malzemeonarımyeri = value; }
        public string Malzemeturu { get => malzemeturu; set => malzemeturu = value; }
        public string Malzemetakipdurumu { get => malzemetakipdurumu; set => malzemetakipdurumu = value; }
        public string Malzemekul { get => malzemekul; set => malzemekul = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string AlternatifMalzeme { get => alternatifMalzeme; set => alternatifMalzeme = value; }
        public string SistemStokNo { get => sistemStokNo; set => sistemStokNo = value; }
        public string SistemTanim { get => sistemTanim; set => sistemTanim = value; }
        public string SistemPersonel { get => sistemPersonel; set => sistemPersonel = value; }
        public bool KayitDurumu { get => kayitDurumu; set => kayitDurumu = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Durum { get => durum; set => durum = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string TalepTarihi { get => talepTarihi; set => talepTarihi = value; }

        public MalzemeKayit(int id, string stokno, string tanim, string birim, string tedarikcifirma, string malzemeonarimdurumu, string malzemeonarımyeri, string malzemeturu, string malzemetakipdurumu, string malzemekul, string aciklama, string dosyayolu,string alternatifMalzeme,string sistemStokNo,string sistemTanim,string sistemPersonel)
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
            this.Malzemekul = malzemekul;
            this.Aciklama = aciklama;
            this.Dosyayolu = dosyayolu;
            this.alternatifMalzeme = alternatifMalzeme;
            this.sistemStokNo = sistemStokNo;
            this.sistemTanim = sistemTanim;
            this.sistemPersonel = sistemPersonel;
        }

        public MalzemeKayit(string stokno, string tanim, string birim, string tedarikcifirma, string malzemeonarimdurumu, string malzemeonarımyeri, string malzemeturu, string malzemetakipdurumu, string malzemekul, string aciklama, string dosyayolu, string alternatifMalzeme, string sistemStokNo, string sistemTanim, string sistemPersonel)
        {
            this.stokno = stokno;
            this.Tanim = tanim;
            this.Birim = birim;
            this.Tedarikcifirma = tedarikcifirma;
            this.Malzemeonarimdurumu = malzemeonarimdurumu;
            this.Malzemeonarımyeri = malzemeonarımyeri;
            this.Malzemeturu = malzemeturu;
            this.Malzemetakipdurumu = malzemetakipdurumu;
            this.Malzemekul = malzemekul;
            this.Aciklama = aciklama;
            this.Dosyayolu = dosyayolu;
            this.alternatifMalzeme = alternatifMalzeme;
            this.sistemStokNo = sistemStokNo;
            this.sistemTanim = sistemTanim;
            this.sistemPersonel = sistemPersonel;
        }

        public MalzemeKayit(bool kayitDurumu, string stokno, string tanim, string seriNo, string durum, string revizyon, int miktar, string talepTarihi)
        {
            this.stokno = stokno;
            this.tanim = tanim;
            this.kayitDurumu = kayitDurumu;
            this.seriNo = seriNo;
            this.durum = durum;
            this.revizyon = revizyon;
            this.miktar = miktar;
            this.talepTarihi = talepTarihi;
        }
    }
}
