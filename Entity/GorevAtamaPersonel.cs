using Entity.IdariIsler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GorevAtamaPersonel
    {
        int id, benzersizId; string departman, gorevAtanacakPersonel, islemAdimi; DateTime tarih; string sure, yapilanIslem, abfNo; int devamEdenGorev, tamamlananGorev; double beklemeSuresi, devamEdenSureOrtGun, tamamlananGorevOrtSure; int toplamGorevSayisi; string sirketBolum;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string Departman { get => departman; set => departman = value; }
        public string GorevAtanacakPersonel { get => gorevAtanacakPersonel; set => gorevAtanacakPersonel = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Sure { get => sure; set => sure = value; }
        public string YapilanIslem { get => yapilanIslem; set => yapilanIslem = value; }
        public DateTime CalismaSuresi { get; set; }
        public string AbfNo { get => abfNo; set => abfNo = value; }
        public int DevamEdenGorev { get => devamEdenGorev; set => devamEdenGorev = value; }
        public int TamamlananGorev { get => tamamlananGorev; set => tamamlananGorev = value; }
        public double BeklemeSuresi { get => beklemeSuresi; set => beklemeSuresi = value; }
        public string SirketBolum { get => sirketBolum; set => sirketBolum = value; }
        public int ToplamGorevSayisi { get => toplamGorevSayisi; set => toplamGorevSayisi = value; }
        public double DevamEdenSureOrtGun { get => devamEdenSureOrtGun; set => devamEdenSureOrtGun = value; }
        public double TamamlananGorevOrtSure { get => tamamlananGorevOrtSure; set => tamamlananGorevOrtSure = value; }

        public GorevAtamaPersonel(int id, int benzersizId, string departman, string gorevAtanacakPersonel, string islemAdimi, DateTime tarih, string sure, string yapilanIslem, DateTime calismaSuresi, string abfNo, double beklemeSuresi)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.tarih = tarih;
            this.sure = sure;
            this.yapilanIslem = yapilanIslem;
            this.CalismaSuresi = calismaSuresi;
            this.abfNo = abfNo;
            this.beklemeSuresi = beklemeSuresi;
        }


        public GorevAtamaPersonel(int benzersizId, string departman, string gorevAtanacakPersonel, string islemAdimi, DateTime tarih, string yapilanIslem, DateTime calismaSuresi)
        {
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.tarih = tarih;
            this.yapilanIslem = yapilanIslem;
            this.CalismaSuresi = calismaSuresi;
        }

        public GorevAtamaPersonel(int id, int benzersizId, string departman, string islemAdimi, string sure, DateTime calismaSuresi, string personel)
        {
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.islemAdimi = islemAdimi;
            this.sure = sure;
            this.CalismaSuresi = calismaSuresi;
            this.id = id;
            this.gorevAtanacakPersonel = personel;
        }

        public GorevAtamaPersonel(string gorevAtanacakPersonel, string sirketBolum)
        {
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.sirketBolum = sirketBolum;
        }

        public GorevAtamaPersonel(string gorevAtanacakPersonel, int devamEdenGorev, int tamamlananGorev, int toplamGorevSayisi, double devamEdenSureOrtGun, double tamamlananGorevOrtSure)
        {
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.devamEdenGorev = devamEdenGorev;
            this.tamamlananGorev = tamamlananGorev;
            ToplamGorevSayisi = toplamGorevSayisi;
            this.devamEdenSureOrtGun = devamEdenSureOrtGun;
            this.tamamlananGorevOrtSure = tamamlananGorevOrtSure;
        }

        public GorevAtamaPersonel(int benzersizId)
        {
            this.benzersizId = benzersizId;
        }
    }
}
