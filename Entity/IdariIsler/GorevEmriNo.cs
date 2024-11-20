using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class GorevEmriNo
    {
        int id, baslangicNo, bitisNo; DateTime tarih; string devamDurumu; int mevcutNo;

        public int Id { get => id; set => id = value; }
        public int BaslangicNo { get => baslangicNo; set => baslangicNo = value; }
        public int BitisNo { get => bitisNo; set => bitisNo = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string DevamDurumu { get => devamDurumu; set => devamDurumu = value; }
        public int MevcutNo { get => mevcutNo; set => mevcutNo = value; }

        public GorevEmriNo(int id, int baslangicNo, int bitisNo, DateTime tarih, string devamDurumu, int mevcutNo)
        {
            this.id = id;
            this.baslangicNo = baslangicNo;
            this.bitisNo = bitisNo;
            this.tarih = tarih;
            this.devamDurumu = devamDurumu;
            this.mevcutNo = mevcutNo;
        }

        public GorevEmriNo(int baslangicNo, int bitisNo)
        {
            this.baslangicNo = baslangicNo;
            this.bitisNo = bitisNo;
        }
    }
}
