using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DepoKayitLokasyon
    {
        int id,depoId; string lokasyon, aciklama;

        public int Id { get => id; set => id = value; }
        public int DepoId { get => depoId; set => depoId = value; }
        public string Lokasyon { get => lokasyon; set => lokasyon = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }

        public DepoKayitLokasyon(int id, int depoId, string lokasyon, string aciklama)
        {
            this.id = id;
            this.depoId = depoId;
            this.lokasyon = lokasyon;
            this.aciklama = aciklama;
        }

        public DepoKayitLokasyon(int depoId, string lokasyon, string aciklama)
        {
            this.depoId = depoId;
            this.lokasyon = lokasyon;
            this.aciklama = aciklama;
        }
    }
}
