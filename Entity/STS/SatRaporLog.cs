using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatRaporLog
    {
        int id; string firmaBilgisi, donem, yil, islemYapan, dosyaYolu; DateTime tarih; double toplamTutar;

        public int Id { get => id; set => id = value; }
        public string FirmaBilgisi { get => firmaBilgisi; set => firmaBilgisi = value; }
        public string Donem { get => donem; set => donem = value; }
        public string Yil { get => yil; set => yil = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public double ToplamTutar { get => toplamTutar; set => toplamTutar = value; }

        public SatRaporLog(int id, string firmaBilgisi, string donem, string yil, string islemYapan, string dosyaYolu, DateTime tarih,        double toplamTutar)
        {
            this.id = id;
            this.firmaBilgisi = firmaBilgisi;
            this.donem = donem;
            this.yil = yil;
            this.islemYapan = islemYapan;
            this.dosyaYolu = dosyaYolu;
            this.tarih = tarih;
            this.toplamTutar = toplamTutar;
        }

        public SatRaporLog(string firmaBilgisi, string donem, string yil, string islemYapan, string dosyaYolu, DateTime tarih, double toplamTutar)
        {
            this.firmaBilgisi = firmaBilgisi;
            this.donem = donem;
            this.yil = yil;
            this.islemYapan = islemYapan;
            this.dosyaYolu = dosyaYolu;
            this.tarih = tarih;
            this.toplamTutar = toplamTutar;
        }
    }
}
