using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GorevAtamaPersonel
    {
        int id, benzersizId; string departman, gorevAtanacakPersonel, islemAdimi; DateTime tarih; string sure;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string Departman { get => departman; set => departman = value; }
        public string GorevAtanacakPersonel { get => gorevAtanacakPersonel; set => gorevAtanacakPersonel = value; }
        public string IslemAdimi { get => islemAdimi; set => islemAdimi = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Sure { get => sure; set => sure = value; }

        public GorevAtamaPersonel(int id, int benzersizId, string departman, string gorevAtanacakPersonel, string islemAdimi, DateTime tarih, string sure)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.tarih = tarih;
            this.sure = sure;
        }

        public GorevAtamaPersonel(int benzersizId, string departman, string gorevAtanacakPersonel, string islemAdimi, DateTime tarih)
        {
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.gorevAtanacakPersonel = gorevAtanacakPersonel;
            this.islemAdimi = islemAdimi;
            this.tarih = tarih;
        }

        public GorevAtamaPersonel(int benzersizId, string departman, string sure)
        {
            this.benzersizId = benzersizId;
            this.departman = departman;
            this.sure = sure;
        }
    }
}
