using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GorevAtamaPersonel
    {
        int id, benzersizId; string departman, gorevAtanacakPersonel, islemAdimi; DateTime tarih; string sure, yapilanIslem, abfNo;

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

        public GorevAtamaPersonel(int id, int benzersizId, string departman, string gorevAtanacakPersonel, string islemAdimi, DateTime tarih, string sure, string yapilanIslem, DateTime calismaSuresi, string abfNo)
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

    }
}
