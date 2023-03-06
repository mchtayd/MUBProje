using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ButceKodu
    {
        int id; string butceKoduKalemi, aciklama, giderKarsilayacakFirma, comboId; bool secim = true; string baslik;

        public int Id { get => id; set => id = value; }
        public string ButceKoduKalemi { get => butceKoduKalemi; set => butceKoduKalemi = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string GiderKarsilayacakFirma { get => giderKarsilayacakFirma; set => giderKarsilayacakFirma = value; }
        public string ComboId { get => comboId; set => comboId = value; }
        public bool Secim { get => secim; set => secim = value; }
        public string Baslik { get => baslik; set => baslik = value; }

        public ButceKodu(int id, string butceKoduKalemi, string aciklama, string giderKarsilayacakFirma, string comboId, bool secim)
        {
            this.id = id;
            this.butceKoduKalemi = butceKoduKalemi;
            this.aciklama = aciklama;
            this.giderKarsilayacakFirma = giderKarsilayacakFirma;
            this.comboId = comboId;
            this.secim = secim;
        }

        public ButceKodu(int id, string butceKoduKalemi, string aciklama, string giderKarsilayacakFirma, string comboId)
        {
            this.id = id;
            this.butceKoduKalemi = butceKoduKalemi;
            this.aciklama = aciklama;
            this.giderKarsilayacakFirma = giderKarsilayacakFirma;
            this.comboId = comboId;
        }

        public ButceKodu(string butceKoduKalemi, string aciklama, string giderKarsilayacakFirma)
        {
            this.butceKoduKalemi = butceKoduKalemi;
            this.aciklama = aciklama;
            this.giderKarsilayacakFirma = giderKarsilayacakFirma;
        }

        public ButceKodu(int id, string baslik)
        {
            this.id = id;
            this.baslik = baslik;
        }
    }
}
