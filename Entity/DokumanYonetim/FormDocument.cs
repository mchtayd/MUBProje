using Entity.DokumanYonetim;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DokumanYonetim
{

     public class FormDocument
    {
        int id; string tur, numarasi, tanimi, revizyon; DateTime onaytarihi, yayintarihi; string dosyayolu, benzersiz;

        public int Id { get => id; set => id = value; }
        public string Tur { get => tur; set => tur = value; }
        public string Numarasi { get => numarasi; set => numarasi = value; }
        public string Tanimi { get => tanimi; set => tanimi = value; }
        public string Revizyon { get => revizyon; set => revizyon = value; }
        public DateTime Onaytarihi { get => onaytarihi; set => onaytarihi = value; }
        public DateTime Yayintarihi { get => yayintarihi; set => yayintarihi = value; }
        public string Dosyayolu { get => dosyayolu; set => dosyayolu = value; }
        public string Benzersiz { get => benzersiz; set => benzersiz = value; }

        public FormDocument(int id, string tur, string numarasi, string tanimi, string revizyon, DateTime onaytarihi, DateTime yayintarihi, string dosyayolu, string benzersiz)
        {
            this.id = id;
            this.tur = tur;
            this.numarasi = numarasi;
            this.tanimi = tanimi;
            this.revizyon = revizyon;
            this.onaytarihi = onaytarihi;
            this.yayintarihi = yayintarihi;
            this.dosyayolu = dosyayolu;
            this.benzersiz = benzersiz;
        }

        public FormDocument(string tur, string numarasi, string tanimi, string revizyon, DateTime onaytarihi, DateTime yayintarihi, string dosyayolu, string benzersiz)
        {
            this.tur = tur;
            this.numarasi = numarasi;
            this.tanimi = tanimi;
            this.revizyon = revizyon;
            this.onaytarihi = onaytarihi;
            this.yayintarihi = yayintarihi;
            this.dosyayolu = dosyayolu;
            this.benzersiz = benzersiz;
        }
    }

}
