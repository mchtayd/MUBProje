using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class BolgeNot
    {
        int id, benzerisizId; DateTime tarih; string kayitYapan, not;

        public int Id { get => id; set => id = value; }
        public int BenzerisizId { get => benzerisizId; set => benzerisizId = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string KayitYapan { get => kayitYapan; set => kayitYapan = value; }
        public string Not { get => not; set => not = value; }

        public BolgeNot(int id, int benzerisizId, DateTime tarih, string kayitYapan, string not)
        {
            this.id = id;
            this.benzerisizId = benzerisizId;
            this.tarih = tarih;
            this.kayitYapan = kayitYapan;
            this.not = not;
        }

        public BolgeNot(int benzerisizId, DateTime tarih, string kayitYapan, string not)
        {
            this.benzerisizId = benzerisizId;
            this.tarih = tarih;
            this.kayitYapan = kayitYapan;
            this.not = not;
        }
    }
}
