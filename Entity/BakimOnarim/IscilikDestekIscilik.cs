using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class IscilikDestekIscilik
    {
        int id; string iscilikTuru, destekTuru, destekNedeniPersonel; DateTime baslamaTarihiPersonel, bitisTarihiPersonel; string toplamSurePersonel, destekNedeniArac; DateTime baslamaTarihiArac, bitisTarihiArac; string toplamSureArac, siparisNo;

        public int Id { get => id; set => id = value; }
        public string IscilikTuru { get => iscilikTuru; set => iscilikTuru = value; }
        public string DestekTuru { get => destekTuru; set => destekTuru = value; }
        public string DestekNedeniPersonel { get => destekNedeniPersonel; set => destekNedeniPersonel = value; }
        public DateTime BaslamaTarihiPersonel { get => baslamaTarihiPersonel; set => baslamaTarihiPersonel = value; }
        public DateTime BitisTarihiPersonel { get => bitisTarihiPersonel; set => bitisTarihiPersonel = value; }
        public string ToplamSurePersonel { get => toplamSurePersonel; set => toplamSurePersonel = value; }
        public string DestekNedeniArac { get => destekNedeniArac; set => destekNedeniArac = value; }
        public DateTime BaslamaTarihiArac { get => baslamaTarihiArac; set => baslamaTarihiArac = value; }
        public DateTime BitisTarihiArac { get => bitisTarihiArac; set => bitisTarihiArac = value; }
        public string ToplamSureArac { get => toplamSureArac; set => toplamSureArac = value; }
        public string SiparisNo { get => siparisNo; set => siparisNo = value; }

        public IscilikDestekIscilik(int id, string iscilikTuru, string destekTuru, string destekNedeniPersonel, DateTime baslamaTarihiPersonel, DateTime bitisTarihiPersonel, string toplamSurePersonel, string destekNedeniArac, DateTime baslamaTarihiArac, DateTime bitisTarihiArac, string toplamSureArac, string siparisNo)
        {
            this.id = id;
            this.iscilikTuru = iscilikTuru;
            this.destekTuru = destekTuru;
            this.destekNedeniPersonel = destekNedeniPersonel;
            this.baslamaTarihiPersonel = baslamaTarihiPersonel;
            this.bitisTarihiPersonel = bitisTarihiPersonel;
            this.toplamSurePersonel = toplamSurePersonel;
            this.destekNedeniArac = destekNedeniArac;
            this.baslamaTarihiArac = baslamaTarihiArac;
            this.bitisTarihiArac = bitisTarihiArac;
            this.toplamSureArac = toplamSureArac;
            this.siparisNo = siparisNo;
        }

        public IscilikDestekIscilik(string iscilikTuru, string destekTuru, string destekNedeniPersonel, DateTime baslamaTarihiPersonel, DateTime bitisTarihiPersonel, string toplamSurePersonel, string destekNedeniArac, DateTime baslamaTarihiArac, DateTime bitisTarihiArac, string toplamSureArac, string siparisNo)
        {
            this.iscilikTuru = iscilikTuru;
            this.destekTuru = destekTuru;
            this.destekNedeniPersonel = destekNedeniPersonel;
            this.baslamaTarihiPersonel = baslamaTarihiPersonel;
            this.bitisTarihiPersonel = bitisTarihiPersonel;
            this.toplamSurePersonel = toplamSurePersonel;
            this.destekNedeniArac = destekNedeniArac;
            this.baslamaTarihiArac = baslamaTarihiArac;
            this.bitisTarihiArac = bitisTarihiArac;
            this.toplamSureArac = toplamSureArac;
            this.siparisNo = siparisNo;
        }
    }
}
