using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ButceKodu
    {
        int id; bool durum; string butceKoduKalemi, aciklama, giderKarsilayacakFirma, comboId;

        public int Id { get => id; set => id = value; }
        public bool Durum { get => durum; set => durum = value; }
        public string ButceKoduKalemi { get => butceKoduKalemi; set => butceKoduKalemi = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string GiderKarsilayacakFirma { get => giderKarsilayacakFirma; set => giderKarsilayacakFirma = value; }
        public string ComboId { get => comboId; set => comboId = value; }

        public ButceKodu(int id, bool durum, string butceKoduKalemi, string aciklama, string giderKarsilayacakFirma, string comboId)
        {
            this.id = id;
            this.durum = durum;
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
    }
}
