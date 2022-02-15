using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class SFYedekPaca
    {
        int id; string parcaKodu, kullanilanMalzeme, adet, siparisNo;

        public int Id { get => id; set => id = value; }
        public string ParcaKodu { get => parcaKodu; set => parcaKodu = value; }
        public string KullanilanMalzeme { get => kullanilanMalzeme; set => kullanilanMalzeme = value; }
        public string Adet { get => adet; set => adet = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public SFYedekPaca(int id, string parcaKodu, string kullanilanMalzeme, string adet, string siparisNo)
        {
            this.id = id;
            this.parcaKodu = parcaKodu;
            this.kullanilanMalzeme = kullanilanMalzeme;
            this.adet = adet;
            this.siparisNo = siparisNo;
        }

        public SFYedekPaca(string parcaKodu, string kullanilanMalzeme, string adet, string siparisNo)
        {
            this.parcaKodu = parcaKodu;
            this.kullanilanMalzeme = kullanilanMalzeme;
            this.adet = adet;
            this.siparisNo = siparisNo;
        }

        public SFYedekPaca(int id, string parcaKodu, string kullanilanMalzeme, string adet)
        {
            this.id = id;
            this.parcaKodu = parcaKodu;
            this.kullanilanMalzeme = kullanilanMalzeme;
            this.adet = adet;
        }
    }
}
