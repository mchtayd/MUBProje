using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AnaSayfa
{
    public class SistemUyari
    {
        int id; string personel, uyariMesaji, mesajDurum; DateTime tarih;

        public int Id { get => id; set => id = value; }
        public string Personel { get => personel; set => personel = value; }
        public string UyariMesaji { get => uyariMesaji; set => uyariMesaji = value; }
        public string MesajDurum { get => mesajDurum; set => mesajDurum = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }

        public SistemUyari(int id, string personel, string uyariMesaji, string mesajDurum, DateTime tarih)
        {
            this.id = id;
            this.personel = personel;
            this.uyariMesaji = uyariMesaji;
            this.mesajDurum = mesajDurum;
            this.tarih = tarih;
        }

        public SistemUyari(string personel, string uyariMesaji)
        {
            this.personel = personel;
            this.uyariMesaji = uyariMesaji;
        }
    }
}
