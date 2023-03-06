using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class BildirimYetki
    {
        int id; string personel; int personelId; string sorumluId;

        public int Id { get => id; set => id = value; }
        public string Personel { get => personel; set => personel = value; }
        public int PersonelId { get => personelId; set => personelId = value; }
        public string SorumluId { get => sorumluId; set => sorumluId = value; }

        public BildirimYetki(int id, string personel, int personelId, string sorumluId)
        {
            this.id = id;
            this.personel = personel;
            this.personelId = personelId;
            this.sorumluId = sorumluId;
        }

        public BildirimYetki(string personel, int personelId, string sorumluId)
        {
            this.personel = personel;
            this.personelId = personelId;
            this.sorumluId = sorumluId;
        }
    }
}
