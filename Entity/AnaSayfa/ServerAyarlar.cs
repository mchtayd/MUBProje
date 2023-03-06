using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreate.AnaSayfa
{
    public class ServerAyarlar
    {
        int id; string personelAdi, onlineYenileme, bildirimAlma;

        public int Id { get => id; set => id = value; }
        public string PersonelAdi { get => personelAdi; set => personelAdi = value; }
        public string OnlineYenileme { get => onlineYenileme; set => onlineYenileme = value; }
        public string BildirimAlma { get => bildirimAlma; set => bildirimAlma = value; }

        public ServerAyarlar(int id, string personelAdi, string onlineYenileme, string bildirimAlma)
        {
            this.id = id;
            this.personelAdi = personelAdi;
            this.onlineYenileme = onlineYenileme;
            this.bildirimAlma = bildirimAlma;
        }

        public ServerAyarlar(string personelAdi, string onlineYenileme, string bildirimAlma)
        {
            this.personelAdi = personelAdi;
            this.onlineYenileme = onlineYenileme;
            this.bildirimAlma = bildirimAlma;
        }
    }
}
