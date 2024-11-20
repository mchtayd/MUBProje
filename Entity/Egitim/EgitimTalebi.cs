using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Egitim
{
    public class EgitimTalebi
    {
        int id; string talepEden, usBolgesi, il, ilce; DateTime kayitTarihi, talepTarihi; string egitimTuru, kisiSayisi, planlamaYapan, planlamaTarihi, durumu, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public string TalepEden { get => talepEden; set => talepEden = value; }
        public string UsBolgesi { get => usBolgesi; set => usBolgesi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilce { get => ilce; set => ilce = value; }
        public DateTime KayitTarihi { get => kayitTarihi; set => kayitTarihi = value; }
        public DateTime TalepTarihi { get => talepTarihi; set => talepTarihi = value; }
        public string EgitimTuru { get => egitimTuru; set => egitimTuru = value; }
        public string KisiSayisi { get => kisiSayisi; set => kisiSayisi = value; }
        public string PlanlamaYapan { get => planlamaYapan; set => planlamaYapan = value; }
        public string PlanlamaTarihi { get => planlamaTarihi; set => planlamaTarihi = value; }
        public string Durumu { get => durumu; set => durumu = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }

        public EgitimTalebi(int id, string talepEden, string usBolgesi, string il, string ilce, DateTime kayitTarihi, DateTime talepTarihi, string egitimTuru, string kisiSayisi, string planlamaYapan, string planlamaTarihi, string durumu, string dosyaYolu)
        {
            this.id = id;
            this.talepEden = talepEden;
            this.usBolgesi = usBolgesi;
            this.il = il;
            this.ilce = ilce;
            this.kayitTarihi = kayitTarihi;
            this.talepTarihi = talepTarihi;
            this.egitimTuru = egitimTuru;
            this.kisiSayisi = kisiSayisi;
            this.planlamaYapan = planlamaYapan;
            this.planlamaTarihi = planlamaTarihi;
            this.durumu = durumu;
            this.dosyaYolu = dosyaYolu;
        }

        public EgitimTalebi(string talepEden, string usBolgesi, string il, string ilce, DateTime kayitTarihi, DateTime talepTarihi, string egitimTuru, string kisiSayisi, string planlamaYapan, string planlamaTarihi, string durumu, string dosyaYolu)
        {
            this.talepEden = talepEden;
            this.usBolgesi = usBolgesi;
            this.il = il;
            this.ilce = ilce;
            this.kayitTarihi = kayitTarihi;
            this.talepTarihi = talepTarihi;
            this.egitimTuru = egitimTuru;
            this.kisiSayisi = kisiSayisi;
            this.planlamaYapan = planlamaYapan;
            this.planlamaTarihi = planlamaTarihi;
            this.durumu = durumu;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
