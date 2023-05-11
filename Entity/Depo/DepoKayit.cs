using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Depo
{
    public class DepoKayit
    {
        int id; string depo, aciklama, depoAdi, il, ilce;

        public int Id { get => id; set => id = value; }
        public string Depo { get => depo; set => depo = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string DepoAdi { get => depoAdi; set => depoAdi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }

        public DepoKayit(int id, string depo, string aciklama, string depoAdi, string il, string ilce)
        {
            this.id = id;
            this.depo = depo;
            this.aciklama = aciklama;
            this.depoAdi= depoAdi;
            this.il = il;
            this.ilce = ilce;
        }

        public DepoKayit(string depo, string aciklama, string depoAdi, string il, string ilce)
        {
            this.depo = depo;
            this.aciklama = aciklama;
            this.depoAdi=depoAdi;
            this.il = il;
            this.ilce=ilce;
        }
    }
}
