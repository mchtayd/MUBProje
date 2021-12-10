using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ArsivTutanak
    {
        int id, isAkisNo; string dosyaTuru, bolgeAdi, sistemCihaz; DateTime dosyaTarihi; string dosyaIcerigi, dosyaYolu, bulunduguLok, klasorNo;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string DosyaTuru { get => dosyaTuru; set => dosyaTuru = value; }
        public string BolgeAdi { get => bolgeAdi; set => bolgeAdi = value; }
        public string SistemCihaz { get => sistemCihaz; set => sistemCihaz = value; }
        public DateTime DosyaTarihi { get => dosyaTarihi; set => dosyaTarihi = value; }
        public string DosyaIcerigi { get => dosyaIcerigi; set => dosyaIcerigi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string BulunduguLok { get => bulunduguLok; set => bulunduguLok = value; }
        public string KlasorNo { get => klasorNo; set => klasorNo = value; }

        public ArsivTutanak(int id, int isAkisNo, string dosyaTuru, string bolgeAdi, string sistemCihaz, DateTime dosyaTarihi, string dosyaIcerigi, string dosyaYolu, string bulunduguLok, string klasorNo)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.dosyaTuru = dosyaTuru;
            this.bolgeAdi = bolgeAdi;
            this.sistemCihaz = sistemCihaz;
            this.dosyaTarihi = dosyaTarihi;
            this.dosyaIcerigi = dosyaIcerigi;
            this.dosyaYolu = dosyaYolu;
            this.bulunduguLok = bulunduguLok;
            this.klasorNo = klasorNo;
        }

        public ArsivTutanak(int isAkisNo, string dosyaTuru, string bolgeAdi, string sistemCihaz, DateTime dosyaTarihi, string dosyaIcerigi, string dosyaYolu, string bulunduguLok, string klasorNo)
        {
            this.isAkisNo = isAkisNo;
            this.dosyaTuru = dosyaTuru;
            this.bolgeAdi = bolgeAdi;
            this.sistemCihaz = sistemCihaz;
            this.dosyaTarihi = dosyaTarihi;
            this.dosyaIcerigi = dosyaIcerigi;
            this.dosyaYolu = dosyaYolu;
            this.bulunduguLok = bulunduguLok;
            this.klasorNo = klasorNo;
        }
    }
}
