using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class Duyuru
    {
        int id; string konu, duyuruMesaj; DateTime baslangicTarih, bitisTarih; string durum, duyuruYapan;

        public int Id { get => id; set => id = value; }
        public string Konu { get => konu; set => konu = value; }
        public string DuyuruMesaj { get => duyuruMesaj; set => duyuruMesaj = value; }
        public DateTime BaslangicTarih { get => baslangicTarih; set => baslangicTarih = value; }
        public DateTime BitisTarih { get => bitisTarih; set => bitisTarih = value; }
        public string Durum { get => durum; set => durum = value; }
        public string DuyuruYapan { get => duyuruYapan; set => duyuruYapan = value; }

        public Duyuru(int id, string konu, string duyuruMesaj, DateTime baslangicTarih, DateTime bitisTarih, string durum, string duyuruYapan)
        {
            this.id = id;
            this.konu = konu;
            this.duyuruMesaj = duyuruMesaj;
            this.baslangicTarih = baslangicTarih;
            this.bitisTarih = bitisTarih;
            this.durum = durum;
            this.duyuruYapan = duyuruYapan;
        }

        public Duyuru(string konu, string duyuruMesaj, DateTime baslangicTarih, DateTime bitisTarih, string durum, string duyuruYapan)
        {
            this.konu = konu;
            this.duyuruMesaj = duyuruMesaj;
            this.baslangicTarih = baslangicTarih;
            this.bitisTarih = bitisTarih;
            this.durum = durum;
            this.duyuruYapan = duyuruYapan;
        }
    }
}
