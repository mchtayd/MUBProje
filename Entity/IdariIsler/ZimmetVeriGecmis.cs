using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IdariIsler
{
    public class ZimmetVeriGecmis
    {
        int id, dvno; string dvEtiketNo, dvTanim, dvMarka, dvModel, seriNo, durumu, miktar, islemTuru, islemYapan,verenPersonel, verenSicil, verenMasYeriNo, veremMasYeri, verenMasSorumlusu, verenBolum; DateTime tarih; string alanPersonel, alanSicil, alanMasYeriNo, alanMasYeri, alanMasSorumlusu, alanBolum, aktarimGerekcesi, depoAdresi, lokasyon, lokasyonBilgi, dosyaYolu;

        public int Id { get => id; set => id = value; }
        public int Dvno { get => dvno; set => dvno = value; }
        public string DvEtiketNo { get => dvEtiketNo; set => dvEtiketNo = value; }
        public string DvTanim { get => dvTanim; set => dvTanim = value; }
        public string DvMarka { get => dvMarka; set => dvMarka = value; }
        public string DvModel { get => dvModel; set => dvModel = value; }
        public string SeriNo { get => seriNo; set => seriNo = value; }
        public string Durumu { get => durumu; set => durumu = value; }
        public string Miktar { get => miktar; set => miktar = value; }
        public string IslemTuru { get => islemTuru; set => islemTuru = value; }
        public string VerenPersonel { get => verenPersonel; set => verenPersonel = value; }
        public string VerenSicil { get => verenSicil; set => verenSicil = value; }
        public string VerenMasYeriNo { get => verenMasYeriNo; set => verenMasYeriNo = value; }
        public string VeremMasYeri { get => veremMasYeri; set => veremMasYeri = value; }
        public string VerenMasSorumlusu { get => verenMasSorumlusu; set => verenMasSorumlusu = value; }
        public string VerenBolum { get => verenBolum; set => verenBolum = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string AlanPersonel { get => alanPersonel; set => alanPersonel = value; }
        public string AlanSicil { get => alanSicil; set => alanSicil = value; }
        public string AlanMasYeriNo { get => alanMasYeriNo; set => alanMasYeriNo = value; }
        public string AlanMasYeri { get => alanMasYeri; set => alanMasYeri = value; }
        public string AlanMasSorumlusu { get => alanMasSorumlusu; set => alanMasSorumlusu = value; }
        public string AlanBolum { get => alanBolum; set => alanBolum = value; }
        public string AktarimGerekcesi { get => aktarimGerekcesi; set => aktarimGerekcesi = value; }
        public string DepoAdresi { get => depoAdresi; set => depoAdresi = value; }
        public string Lokasyon { get => lokasyon; set => lokasyon = value; }
        public string LokasyonBilgi { get => lokasyonBilgi; set => lokasyonBilgi = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }

        public ZimmetVeriGecmis(int id, int dvno, string dvEtiketNo, string dvTanim, string dvMarka, string dvModel, string seriNo, string durumu, string miktar, string islemTuru, string islemYapan,string verenPersonel, string verenSicil, string verenMasYeriNo, string veremMasYeri, string verenMasSorumlusu, string verenBolum, DateTime tarih, string alanPersonel, string alanSicil, string alanMasYeriNo, string alanMasYeri, string alanMasSorumlusu, string alanBolum, string aktarimGerekcesi, string depoAdresi, string lokasyon, string lokasyonBilgi, string dosyaYolu)
        {
            this.id = id;
            this.dvno = dvno;
            this.dvEtiketNo = dvEtiketNo;
            this.dvTanim = dvTanim;
            this.dvMarka = dvMarka;
            this.dvModel = dvModel;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
            this.islemTuru = islemTuru;
            this.islemYapan = islemYapan;
            this.verenPersonel = verenPersonel;
            this.verenSicil = verenSicil;
            this.verenMasYeriNo = verenMasYeriNo;
            this.veremMasYeri = veremMasYeri;
            this.verenMasSorumlusu = verenMasSorumlusu;
            this.verenBolum = verenBolum;
            this.tarih = tarih;
            this.alanPersonel = alanPersonel;
            this.alanSicil = alanSicil;
            this.alanMasYeriNo = alanMasYeriNo;
            this.alanMasYeri = alanMasYeri;
            this.alanMasSorumlusu = alanMasSorumlusu;
            this.alanBolum = alanBolum;
            this.aktarimGerekcesi = aktarimGerekcesi;
            this.depoAdresi = depoAdresi;
            this.lokasyon = lokasyon;
            this.lokasyonBilgi = lokasyonBilgi;
            this.dosyaYolu = dosyaYolu;
        }

        public ZimmetVeriGecmis(int dvno, string dvEtiketNo, string dvTanim, string dvMarka, string dvModel, string seriNo, string durumu, string miktar, string islemTuru, string islemYapan, string verenPersonel, string verenSicil, string verenMasYeriNo, string veremMasYeri, string verenMasSorumlusu, string verenBolum, DateTime tarih, string alanPersonel, string alanSicil, string alanMasYeriNo, string alanMasYeri, string alanMasSorumlusu, string alanBolum, string aktarimGerekcesi, string depoAdresi, string lokasyon, string lokasyonBilgi, string dosyaYolu)
        {
            this.dvno = dvno;
            this.dvEtiketNo = dvEtiketNo;
            this.dvTanim = dvTanim;
            this.dvMarka = dvMarka;
            this.dvModel = dvModel;
            this.seriNo = seriNo;
            this.durumu = durumu;
            this.miktar = miktar;
            this.islemTuru = islemTuru;
            this.islemYapan = islemYapan;
            this.verenPersonel = verenPersonel;
            this.verenSicil = verenSicil;
            this.verenMasYeriNo = verenMasYeriNo;
            this.veremMasYeri = veremMasYeri;
            this.verenMasSorumlusu = verenMasSorumlusu;
            this.verenBolum = verenBolum;
            this.tarih = tarih;
            this.alanPersonel = alanPersonel;
            this.alanSicil = alanSicil;
            this.alanMasYeriNo = alanMasYeriNo;
            this.alanMasYeri = alanMasYeri;
            this.alanMasSorumlusu = alanMasSorumlusu;
            this.alanBolum = alanBolum;
            this.aktarimGerekcesi = aktarimGerekcesi;
            this.depoAdresi = depoAdresi;
            this.lokasyon = lokasyon;
            this.lokasyonBilgi = lokasyonBilgi;
            this.dosyaYolu = dosyaYolu;
        }
    }
}
