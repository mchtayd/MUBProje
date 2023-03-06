using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Butce
{
    public class ButceKayit
    {
        int id; string yil, donem, butceTanim, siparisNo; int kisiSayisi; string butceTutari, butceTutariAylik, butceTutariYillik;

        public int Id { get => id; set => id = value; }
        public string Yil { get => yil; set => yil = value; }
        public string Donem { get => donem; set => donem = value; }
        public string ButceTanim { get => butceTanim; set => butceTanim = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }
        public int KisiSayisi { get => kisiSayisi; set => kisiSayisi = value; }
        public string ButceTutari { get => butceTutari; set => butceTutari = value; }
        public string ButceTutariAylik { get => butceTutariAylik; set => butceTutariAylik = value; }
        public string ButceTutariYillik { get => butceTutariYillik; set => butceTutariYillik = value; }

        public ButceKayit(int id, string yil, string donem, string butceTanim, string siparisNo, int kisiSayisi, string butceTutari, string butceTutariAylik, string butceTutariYillik)
        {
            this.id = id;
            this.yil = yil;
            this.donem = donem;
            this.butceTanim = butceTanim;
            this.siparisNo = siparisNo;
            this.kisiSayisi = kisiSayisi;
            this.butceTutari = butceTutari;
            this.butceTutariAylik = butceTutariAylik;
            this.butceTutariYillik = butceTutariYillik;
        }

        public ButceKayit(string yil, string donem, string butceTanim, string siparisNo, int kisiSayisi, string butceTutari, string butceTutariAylik, string butceTutariYillik)
        {
            this.yil = yil;
            this.donem = donem;
            this.butceTanim = butceTanim;
            this.siparisNo = siparisNo;
            this.kisiSayisi = kisiSayisi;
            this.butceTutari = butceTutari;
            this.butceTutariAylik = butceTutariAylik;
            this.butceTutariYillik = butceTutariYillik;
        }
    }
}
