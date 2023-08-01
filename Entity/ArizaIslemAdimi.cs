using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ArizaIslemAdimi
    {
        int sirnak, cukurca, yukseova, semdinli, derecik, dBolgesi, merkez, toplam;

        public int Sirnak { get => sirnak; set => sirnak = value; }
        public int Cukurca { get => cukurca; set => cukurca = value; }
        public int Yukseova { get => yukseova; set => yukseova = value; }
        public int Semdinli { get => semdinli; set => semdinli = value; }
        public int Derecik { get => derecik; set => derecik = value; }
        public int Toplam { get => toplam; set => toplam = value; }
        public int DBolgesi { get => dBolgesi; set => dBolgesi = value; }
        public int Merkez { get => merkez; set => merkez = value; }

        public ArizaIslemAdimi(int sirnak, int cukurca, int yukseova, int semdinli, int derecik, int dBolgesi, int merkez,int toplam)
        {
            this.sirnak = sirnak;
            this.cukurca = cukurca;
            this.yukseova = yukseova;
            this.semdinli = semdinli;
            this.derecik = derecik;
            this.toplam = toplam;
            this.dBolgesi= dBolgesi;
            this.Merkez = merkez;
        }

    }
}
