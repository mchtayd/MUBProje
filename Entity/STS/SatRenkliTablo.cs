using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class SatRenkliTablo
    {
        int id; string firmaadi; DateTime tarih; string  siparisid, durum, dosyayolu;

        public int Id { get => id; set => id = value; }
        public string Firmaadi { get => firmaadi; set => firmaadi = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Siparisid { get => siparisid; set => siparisid = value; }
        public string Durum { get => durum; set => durum = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }

        public SatRenkliTablo(int id, string firmaadi, DateTime tarih, string siparisid, string durum, string dosyayolu)
        {
            this.id = id;
            this.firmaadi = firmaadi;
            this.tarih = tarih;
            this.siparisid = siparisid;
            this.durum = durum;
            this.dosyayolu = dosyayolu;
        }

        public SatRenkliTablo(string firmaadi, DateTime tarih, string siparisid, string durum, string dosyayolu)
        {
            this.firmaadi = firmaadi;
            this.tarih = tarih;
            this.siparisid = siparisid;
            this.durum = durum;
            this.dosyayolu = dosyayolu;
        }
    }
}
