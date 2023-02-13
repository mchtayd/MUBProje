using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BakimOnarim
{
    public class DtfMaliyet
    {
        int id, benzersizId; string isTanimi; int miktar; string birim, pBirimi; double birimTutar, toplamTutar; string sayfa;

        public int Id { get => id; set => id = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }
        public string IsTanimi { get => isTanimi; set => isTanimi = value; }
        public int Miktar { get => miktar; set => miktar = value; }
        public string Birim { get => birim; set => birim = value; }
        public string PBirimi { get => pBirimi; set => pBirimi = value; }
        public double BirimTutar { get => birimTutar; set => birimTutar = value; }
        public double ToplamTutar { get => toplamTutar; set => toplamTutar = value; }
        public string Sayfa { get => sayfa; set => sayfa = value; }

        public DtfMaliyet(int id, int benzersizId, string isTanimi, int miktar, string birim, string pBirimi, double birimTutar, double toplamTutar, string sayfa)
        {
            this.id = id;
            this.benzersizId = benzersizId;
            this.isTanimi = isTanimi;
            this.miktar = miktar;
            this.birim = birim;
            this.pBirimi = pBirimi;
            this.birimTutar = birimTutar;
            this.toplamTutar = toplamTutar;
            this.sayfa = sayfa;
        }

        public DtfMaliyet(int benzersizId, string isTanimi, int miktar, string birim, string pBirimi, double birimTutar, double toplamTutar, string sayfa)
        {
            this.benzersizId = benzersizId;
            this.isTanimi = isTanimi;
            this.miktar = miktar;
            this.birim = birim;
            this.pBirimi = pBirimi;
            this.birimTutar = birimTutar;
            this.toplamTutar = toplamTutar;
            this.sayfa = sayfa;
        }
    }
}
