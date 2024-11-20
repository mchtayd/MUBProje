using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DestekDepo
    {
        int id; string malzemeTuru, stokNo, tanim, birim, dosyaYolu, malzemeTakipTuru, kayitYapan; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string MalzemeTuru { get => malzemeTuru; set => malzemeTuru = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string MalzemeTakipTuru { get => malzemeTakipTuru; set => malzemeTakipTuru = value; }
        public string KayitYapan { get => kayitYapan; set => kayitYapan = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public DestekDepo(int id, string malzemeTuru, string stokNo, string tanim, string birim, string dosyaYolu, string malzemeTakipTuru, string kayitYapan, DateTime tarih)
        {
            this.id = id;
            this.malzemeTuru = malzemeTuru;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
            this.dosyaYolu = dosyaYolu;
            this.malzemeTakipTuru = malzemeTakipTuru;
            this.kayitYapan = kayitYapan;
            this.tarih = tarih;
        }

        public DestekDepo(string malzemeTuru, string stokNo, string tanim, string birim, string dosyaYolu, string malzemeTakipTuru, string kayitYapan, DateTime tarih)
        {
            this.malzemeTuru = malzemeTuru;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
            this.dosyaYolu = dosyaYolu;
            this.malzemeTakipTuru = malzemeTakipTuru;
            this.kayitYapan = kayitYapan;
            this.tarih = tarih;
        }
    }
}
