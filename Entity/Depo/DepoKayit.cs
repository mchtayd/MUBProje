using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DepoKayit
    {
        int id; string depo, aciklama;

        public int Id { get => id; set => id = value; }
        public string Depo { get => depo; set => depo = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }

        public DepoKayit(int id, string depo, string aciklama)
        {
            this.id = id;
            this.depo = depo;
            this.aciklama = aciklama;
        }

        public DepoKayit(string depo, string aciklama)
        {
            this.depo = depo;
            this.aciklama = aciklama;
        }
    }
}
