using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class PersonelUyari
    {
        int id, abfNo; DateTime uyarmaTarihi; string uyaranPersonel, uyarilanPersonel; int mesajId; string gorulmeDurumu; DateTime gorulmeTarihi; int uyariMiktar;

        public int Id { get => id; set => id = value; }
        public int AbfNo { get => abfNo; set => abfNo = value; }
        public DateTime UyarmaTarihi { get => uyarmaTarihi; set => uyarmaTarihi = value; }
        public string UyaranPersonel { get => uyaranPersonel; set => uyaranPersonel = value; }
        public string UyarilanPersonel { get => uyarilanPersonel; set => uyarilanPersonel = value; }
        public int MesajId { get => mesajId; set => mesajId = value; }
        public string GorulmeDurumu { get => gorulmeDurumu; set => gorulmeDurumu = value; }
        public DateTime GorulmeTarihi { get => gorulmeTarihi; set => gorulmeTarihi = value; }
        public int UyariMiktar { get => uyariMiktar; set => uyariMiktar = value; }

        public PersonelUyari(int id, int abfNo, DateTime uyarmaTarihi, string uyaranPersonel, string uyarilanPersonel, int mesajId, string gorulmeDurumu, DateTime gorulmeTarihi, int uyariMiktar)
        {
            this.id = id;
            this.abfNo = abfNo;
            this.uyarmaTarihi = uyarmaTarihi;
            this.uyaranPersonel = uyaranPersonel;
            this.uyarilanPersonel = uyarilanPersonel;
            this.mesajId = mesajId;
            this.gorulmeDurumu = gorulmeDurumu;
            this.gorulmeTarihi = gorulmeTarihi;
            this.uyariMiktar = uyariMiktar;
        }

        public PersonelUyari(int abfNo, DateTime uyarmaTarihi, string uyaranPersonel, string uyarilanPersonel, int mesajId)
        {
            this.abfNo = abfNo;
            this.uyarmaTarihi = uyarmaTarihi;
            this.uyaranPersonel = uyaranPersonel;
            this.uyarilanPersonel = uyarilanPersonel;
            this.mesajId = mesajId;
        }

    }
}
