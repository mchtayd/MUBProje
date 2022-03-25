﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class AbfMalzeme
    {
        int id, benzersizId; string sokulenStokNo, sokulenTanim, sokulenSeriNo; int sokulenMiktar; string sokulenBirim; double sokulenCalismaSaati; string sokulenRevizyon, calismaDurumu, fizikselDurum, yapilacakIslem, takilanStokNo, takilanTanim, takilanSeriNo; int takilanMiktar; string takilanBirim; double takilanCalismaSaati; string takilanRevizyon;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string SokulenStokNo { get => sokulenStokNo; set => sokulenStokNo = value; }
        public string SokulenTanim { get => sokulenTanim; set => sokulenTanim = value; }
        public string SokulenSeriNo { get => sokulenSeriNo; set => sokulenSeriNo = value; }
        public int SokulenMiktar { get => sokulenMiktar; set => sokulenMiktar = value; }
        public string SokulenBirim { get => sokulenBirim; set => sokulenBirim = value; }
        public double SokulenCalismaSaati { get => sokulenCalismaSaati; set => sokulenCalismaSaati = value; }
        public string SokulenRevizyon { get => sokulenRevizyon; set => sokulenRevizyon = value; }
        public string CalismaDurumu { get => calismaDurumu; set => calismaDurumu = value; }
        public string FizikselDurum { get => fizikselDurum; set => fizikselDurum = value; }
        public string YapilacakIslem { get => yapilacakIslem; set => yapilacakIslem = value; }
        public string TakilanStokNo { get => takilanStokNo; set => takilanStokNo = value; }
        public string TakilanTanim { get => takilanTanim; set => takilanTanim = value; }
        public string TakilanSeriNo { get => takilanSeriNo; set => takilanSeriNo = value; }
        public int TakilanMiktar { get => takilanMiktar; set => takilanMiktar = value; }
        public string TakilanBirim { get => takilanBirim; set => takilanBirim = value; }
        public double TakilanCalismaSaati { get => takilanCalismaSaati; set => takilanCalismaSaati = value; }
        public string TakilanRevizyon { get => takilanRevizyon; set => takilanRevizyon = value; }

        public AbfMalzeme(int id, int benzersizId, string sokulenStokNo, string sokulenTanim, string sokulenSeriNo, int sokulenMiktar, string sokulenBirim, double sokulenCalismaSaati, string sokulenRevizyon, string calismaDurumu, string fizikselDurum, string yapilacakIslem, string takilanStokNo, string takilanTanim, string takilanSeriNo, int takilanMiktar, string takilanBirim, double takilanCalismaSaati, string takilanRevizyon)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.sokulenStokNo = sokulenStokNo;
            this.sokulenTanim = sokulenTanim;
            this.sokulenSeriNo = sokulenSeriNo;
            this.sokulenMiktar = sokulenMiktar;
            this.sokulenBirim = sokulenBirim;
            this.sokulenCalismaSaati = sokulenCalismaSaati;
            this.sokulenRevizyon = sokulenRevizyon;
            this.calismaDurumu = calismaDurumu;
            this.fizikselDurum = fizikselDurum;
            this.yapilacakIslem = yapilacakIslem;
            this.takilanStokNo = takilanStokNo;
            this.takilanTanim = takilanTanim;
            this.takilanSeriNo = takilanSeriNo;
            this.takilanMiktar = takilanMiktar;
            this.takilanBirim = takilanBirim;
            this.takilanCalismaSaati = takilanCalismaSaati;
            this.takilanRevizyon = takilanRevizyon;
        }

        public AbfMalzeme(int benzersizId, string sokulenStokNo, string sokulenTanim, string sokulenSeriNo, int sokulenMiktar, string sokulenBirim, double sokulenCalismaSaati, string sokulenRevizyon, string calismaDurumu, string fizikselDurum, string yapilacakIslem)
        {
            this.benzersizId = benzersizId;
            this.sokulenStokNo = sokulenStokNo;
            this.sokulenTanim = sokulenTanim;
            this.sokulenSeriNo = sokulenSeriNo;
            this.sokulenMiktar = sokulenMiktar;
            this.sokulenBirim = sokulenBirim;
            this.sokulenCalismaSaati = sokulenCalismaSaati;
            this.sokulenRevizyon = sokulenRevizyon;
            this.calismaDurumu = calismaDurumu;
            this.fizikselDurum = fizikselDurum;
            this.yapilacakIslem = yapilacakIslem;
        }

        public AbfMalzeme(string takilanStokNo, string takilanTanim, string takilanSeriNo, int takilanMiktar, string takilanBirim, double takilanCalismaSaati, string takilanRevizyon)
        {
            this.takilanStokNo = takilanStokNo;
            this.takilanTanim = takilanTanim;
            this.takilanSeriNo = takilanSeriNo;
            this.takilanMiktar = takilanMiktar;
            this.takilanBirim = takilanBirim;
            this.takilanCalismaSaati = takilanCalismaSaati;
            this.takilanRevizyon = takilanRevizyon;
        }

    }
}
