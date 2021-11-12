using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class Siparisler
    {
        int id; string proje, siparisno; int personelyonetici, personel, personeldepo, personeltoplam, yoneticiarac, araziarac, toplamarac, personelsayisi,mevcutPersonel;
        string sat, donemyil, satkategori,benzersiz;

        public int Id { get => id; set => id = value; }
        public string Proje { get => proje; set => proje = value; }
        public string Siparisno { get => siparisno; set => siparisno = value; }
        public int Personelyonetici { get => personelyonetici; set => personelyonetici = value; }
        public int Personelsayisi { get => personelsayisi; set => personelsayisi = value; }
        public int Yoneticiarac { get => yoneticiarac; set => yoneticiarac = value; }
        public int Araziarac { get => araziarac; set => araziarac = value; }
        public int Personel { get => personel; set => personel = value; }
        public int Personeldepo { get => personeldepo; set => personeldepo = value; }
        
        public string Sat { get => sat; set => sat = value; }
        public string Donemyil { get => donemyil; set => donemyil = value; }
        public string Satkategori { get => satkategori; set => satkategori = value; }
        
        public int Personeltoplam { get => personeltoplam; set => personeltoplam = value; }
        public int Toplamarac { get => toplamarac; set => toplamarac = value; }
        public string Benzersiz { get => benzersiz; set => benzersiz = value; }
        public int MevcutPersonel { get => mevcutPersonel; set => mevcutPersonel = value; }

        public Siparisler(int id, string proje, string siparisno, int personelyonetici, int personel, int personeldepo, int personeltoplam , int yoneticiarac, int araziarac, int topalmarac,
            string sat, string donemyil, string satkategori,string benzerisz,int mevcutPersonel)
        {
            this.id = id;
            this.yoneticiarac = yoneticiarac;
            this.araziarac = araziarac;
            this.personelyonetici = personelyonetici;
            this.personel = personel;
            this.personeldepo = personeldepo;
            this.proje = proje;
            this.sat = sat;
            this.donemyil = donemyil;
            this.satkategori = satkategori;
            this.siparisno = siparisno;
            this.personeltoplam = personeltoplam;
            this.toplamarac = topalmarac;
            this.benzersiz = benzerisz;
            this.mevcutPersonel = mevcutPersonel;
        }

        public Siparisler(string proje, string siparisno, int personelyonetici, int personel, int personeldepo, int personeltoplam, int yoneticiarac, int araziarac, int topalmarac, int personelsayisi,
             string sat, string donemyil, string satkategori, string benzerisz)
        {
            this.personelsayisi = personelsayisi;
            this.yoneticiarac = yoneticiarac;
            this.araziarac = araziarac;
            this.personelyonetici = personelyonetici;
            this.personel = personel;
            this.personeldepo = personeldepo;
            this.personeltoplam = personeltoplam;
            this.toplamarac = topalmarac;
            this.proje = proje;
            this.sat = sat;
            this.donemyil = donemyil;
            this.satkategori = satkategori;
            this.siparisno = siparisno;
            this.benzersiz = benzerisz;
        }
    }
}
