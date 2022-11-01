using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class MasrafYeri
    {
        int id; string masrafYeriNo, masrafYeriBilgi;

        public int Id { get => id; set => id = value; }
        public string MasrafYeriNo { get => masrafYeriNo; set => masrafYeriNo = value; }
        public string MasrafYeriBilgi { get => masrafYeriBilgi; set => masrafYeriBilgi = value; }

        public MasrafYeri(int id, string masrafYeriNo, string masrafYeriBilgi)
        {
            this.id = id;
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeriBilgi = masrafYeriBilgi;
        }

        public MasrafYeri(string masrafYeriNo, string masrafYeriBilgi)
        {
            this.masrafYeriNo = masrafYeriNo;
            this.masrafYeriBilgi = masrafYeriBilgi;
        }
    }

}
