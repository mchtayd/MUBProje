using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Login
    {
        int personelId; string sicilNo, sifre;

        public int PersonelId { get => personelId; set => personelId = value; }
        public string SicilNo { get => sicilNo; set => sicilNo = value; }
        public string Sifre { get => sifre; set => sifre = value; }

        public Login(int personelId, string sicilNo, string sifre)
        {
            this.personelId = personelId;
            this.sicilNo = sicilNo;
            this.sifre = sifre;
        }
    }
}
