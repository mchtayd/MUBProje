using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class IscilikPerformans
    {
        int id, isAkisNo; string iscilikTuru, personel, mevcutDuragi, cikisDuragi, istikametDuragi; DateTime cikisTarihiSaati; string cikisSebebi, varisDurag; DateTime varisTarihiSaat; string sonuc, hata;

        public int Id { get => id; set => id = value; }
        public string IscilikTuru { get => iscilikTuru; set => iscilikTuru = value; }
        public string Personel { get => personel; set => personel = value; }
        public string MevcutDuragi { get => mevcutDuragi; set => mevcutDuragi = value; }
        public string CikisDuragi { get => cikisDuragi; set => cikisDuragi = value; }
        public string IstikametDuragi { get => istikametDuragi; set => istikametDuragi = value; }
        public DateTime CikisTarihiSaati { get => cikisTarihiSaati; set => cikisTarihiSaati = value; }
        public string CikisSebebi { get => cikisSebebi; set => cikisSebebi = value; }
        public string VarisDurag { get => varisDurag; set => varisDurag = value; }
        public DateTime VarisTarihiSaat { get => varisTarihiSaat; set => varisTarihiSaat = value; }
        public string Sonuc { get => sonuc; set => sonuc = value; }
        public string Hata { get => hata; set => hata = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }

        public IscilikPerformans(int id, int isAkisNo, string iscilikTuru, string personel, string mevcutDuragi, string cikisDuragi, string istikametDuragi, DateTime cikisTarihiSaati, string cikisSebebi, string varisDurag, DateTime varisTarihiSaat, string sonuc,string hata)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.iscilikTuru = iscilikTuru;
            this.personel = personel;
            this.mevcutDuragi = mevcutDuragi;
            this.cikisDuragi = cikisDuragi;
            this.istikametDuragi = istikametDuragi;
            this.cikisTarihiSaati = cikisTarihiSaati;
            this.cikisSebebi = cikisSebebi;
            this.varisDurag = varisDurag;
            this.varisTarihiSaat = varisTarihiSaat;
            this.sonuc = sonuc;
            this.hata = hata;
        }

        public IscilikPerformans(int isAkisNo, string iscilikTuru, string personel, string mevcutDuragi, string cikisDuragi, string istikametDuragi, DateTime cikisTarihiSaati, string cikisSebebi, string varisDurag, DateTime varisTarihiSaat, string sonuc)
        {
            this.isAkisNo = isAkisNo;
            this.iscilikTuru = iscilikTuru;
            this.personel = personel;
            this.mevcutDuragi = mevcutDuragi;
            this.cikisDuragi = cikisDuragi;
            this.istikametDuragi = istikametDuragi;
            this.cikisTarihiSaati = cikisTarihiSaati;
            this.cikisSebebi = cikisSebebi;
            this.varisDurag = varisDurag;
            this.varisTarihiSaat = varisTarihiSaat;
            this.sonuc = sonuc;
        }
    }
}
