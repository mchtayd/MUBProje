using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class GorevAtama
    {
        int id, isAkisNo; string gorevinTanimi, gorevileten; DateTime tarihSaat; string bulunduguİslemAdimi, islemAdimiSorumlusu;

        public int Id { get => id; set => id = value; }
        public int IsAkisNo { get => isAkisNo; set => isAkisNo = value; }
        public string GorevinTanimi { get => gorevinTanimi; set => gorevinTanimi = value; }
        public string Gorevileten { get => gorevileten; set => gorevileten = value; }
        public DateTime TarihSaat { get => tarihSaat; set => tarihSaat = value; }
        public string BulunduguİslemAdimi { get => bulunduguİslemAdimi; set => bulunduguİslemAdimi = value; }
        public string IslemAdimiSorumlusu { get => islemAdimiSorumlusu; set => islemAdimiSorumlusu = value; }

        public GorevAtama(int id, int isAkisNo, string gorevinTanimi, string gorevileten, DateTime tarihSaat, string bulunduguİslemAdimi, string islemAdimiSorumlusu)
        {
            this.id = id;
            this.isAkisNo = isAkisNo;
            this.gorevinTanimi = gorevinTanimi;
            this.gorevileten = gorevileten;
            this.tarihSaat = tarihSaat;
            this.bulunduguİslemAdimi = bulunduguİslemAdimi;
            this.islemAdimiSorumlusu = islemAdimiSorumlusu;
        }

        public GorevAtama(int isAkisNo, string gorevinTanimi, string gorevileten, DateTime tarihSaat, string bulunduguİslemAdimi, string islemAdimiSorumlusu)
        {
            this.isAkisNo = isAkisNo;
            this.gorevinTanimi = gorevinTanimi;
            this.gorevileten = gorevileten;
            this.tarihSaat = tarihSaat;
            this.bulunduguİslemAdimi = bulunduguİslemAdimi;
            this.islemAdimiSorumlusu = islemAdimiSorumlusu;
        }
    }
}
