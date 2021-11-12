using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class DuranVarlikSonuc
    {
        int dvNo; string dvEtiketNo, tanim, marka, model, seriNo, durumu, miktar;

        public int DvNo { get => dvNo; set => dvNo = value; }
        public string DvEtiketNo { get => dvEtiketNo; set => dvEtiketNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Durumu { get => durumu; set => durumu = value; }
        public string Miktar { get => miktar; set => miktar = value; }

        public DuranVarlikSonuc(int dvNo, string dvEtiketNo, string tanim, string marka, string model, string seriNo, string durumu, string miktar)
        {
            this.dvNo = dvNo;
            this.dvEtiketNo = dvEtiketNo;
            this.tanim = tanim;
            this.marka = marka;
            this.model = model;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
        }
    }
}
