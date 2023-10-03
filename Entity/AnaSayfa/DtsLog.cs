using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class DtsLog
    {
        int id; string personelAdi; DateTime islemTarihi; string sayfa, islem;

        public int Id { get => id; set => id = value; }
        public string PersonelAdi { get => personelAdi; set => personelAdi = value; }
        public DateTime IslemTarihi { get => islemTarihi; set => islemTarihi = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }
        public string Islem { get => islem; set => islem = value; }

        public DtsLog(int id, string personelAdi, DateTime islemTarihi, string sayfa, string islem)
        {
            this.id = id;
            this.personelAdi = personelAdi;
            this.islemTarihi = islemTarihi;
            this.sayfa = sayfa;
            this.islem = islem;
        }

        public DtsLog(string personelAdi, DateTime islemTarihi, string sayfa, string islem)
        {
            this.personelAdi = personelAdi;
            this.islemTarihi = islemTarihi;
            this.sayfa = sayfa;
            this.islem = islem;
        }
    }
}
