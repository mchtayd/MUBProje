using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Gecic_Kabul_Ambar
{
    public class Malzeme
    {
        int id; string stokNo, tanim, birim, tedarikciFirma, onarimDurumu, onarimYeri, tedarikTuru, parcaSinifi, alternatifParca, aciklama, dosyaYolu, sistemStokNo, sistemTanimi, sistemSorumlusu, islemYapan, takipDurumu, ustStok, ustTanim; int benzersizId;

        public int Id { get => id; set => id = value; }
        public string StokNo { get => stokNo; set => stokNo = value; }
        public string Tanim { get => tanim; set => tanim = value; }
        public string Birim { get => birim; set => birim = value; }
        public string TedarikciFirma { get => tedarikciFirma; set => tedarikciFirma = value; }
        public string OnarimDurumu { get => onarimDurumu; set => onarimDurumu = value; }
        public string OnarimYeri { get => onarimYeri; set => onarimYeri = value; }
        public string TedarikTuru { get => tedarikTuru; set => tedarikTuru = value; }
        public string ParcaSinifi { get => parcaSinifi; set => parcaSinifi = value; }
        public string AlternatifParca { get => alternatifParca; set => alternatifParca = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }
        public string DosyaYolu { get => dosyaYolu; set => dosyaYolu = value; }
        public string SistemStokNo { get => sistemStokNo; set => sistemStokNo = value; }
        public string SistemTanimi { get => sistemTanimi; set => sistemTanimi = value; }
        public string SistemSorumlusu { get => sistemSorumlusu; set => sistemSorumlusu = value; }
        public string IslemYapan { get => islemYapan; set => islemYapan = value; }
        public string TakipDurumu { get => takipDurumu; set => takipDurumu = value; }
        public string UstStok { get => ustStok; set => ustStok = value; }
        public string UstTanim { get => ustTanim; set => ustTanim = value; }
        public int BenzersizId { get => benzersizId; set => benzersizId = value; }

        public Malzeme(int id, string stokNo, string tanim, string birim, string tedarikciFirma, string onarimDurumu, string onarimYeri, string tedarikTuru, string parcaSinifi, string alternatifParca, string aciklama, string dosyaYolu, string sistemStokNo, string sistemTanimi, string sistemSorumlusu, string islemYapan,
            string takipDurumu)
        {
            this.id = id;
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
            this.tedarikciFirma = tedarikciFirma;
            this.onarimDurumu = onarimDurumu;
            this.onarimYeri = onarimYeri;
            this.tedarikTuru = tedarikTuru;
            this.parcaSinifi = parcaSinifi;
            this.alternatifParca = alternatifParca;
            this.aciklama = aciklama;
            this.dosyaYolu = dosyaYolu;
            this.sistemStokNo = sistemStokNo;
            this.sistemTanimi = sistemTanimi;
            this.sistemSorumlusu = sistemSorumlusu;
            this.islemYapan = islemYapan;
            this.takipDurumu = takipDurumu;
        }

        public Malzeme(string stokNo, string tanim, string birim, string tedarikciFirma, string onarimDurumu, string onarimYeri, string tedarikTuru, string parcaSinifi, string alternatifParca, string aciklama, string dosyaYolu, string sistemStokNo, string sistemTanimi, string sistemSorumlusu, string islemYapan, string takipDurumu)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
            this.tedarikciFirma = tedarikciFirma;
            this.onarimDurumu = onarimDurumu;
            this.onarimYeri = onarimYeri;
            this.tedarikTuru = tedarikTuru;
            this.parcaSinifi = parcaSinifi;
            this.alternatifParca = alternatifParca;
            this.aciklama = aciklama;
            this.dosyaYolu = dosyaYolu;
            this.sistemStokNo = sistemStokNo;
            this.sistemTanimi = sistemTanimi;
            this.sistemSorumlusu = sistemSorumlusu;
            this.islemYapan = islemYapan;
            this.takipDurumu = takipDurumu;
        }

        public Malzeme(string stokNo, string tanim, string birim, string tedarikciFirma, string onarimDurumu, string onarimYeri, string tedarikTuru, string parcaSinifi, string alternatifParca, string aciklama, string sistemStokNo, string sistemTanimi, string sistemSorumlusu, string islemYapan, string takipDurumu)
        {
            this.stokNo = stokNo;
            this.tanim = tanim;
            this.birim = birim;
            this.tedarikciFirma = tedarikciFirma;
            this.onarimDurumu = onarimDurumu;
            this.onarimYeri = onarimYeri;
            this.tedarikTuru = tedarikTuru;
            this.parcaSinifi = parcaSinifi;
            this.alternatifParca = alternatifParca;
            this.aciklama = aciklama;
            this.sistemStokNo = sistemStokNo;
            this.sistemTanimi = sistemTanimi;
            this.sistemSorumlusu = sistemSorumlusu;
            this.islemYapan = islemYapan;
            this.takipDurumu = takipDurumu;
        }

        public Malzeme(string ustStok, string ustTanim, int benzersizId)
        {
            this.ustStok = ustStok;
            this.ustTanim = ustTanim;
            this.benzersizId = benzersizId;
        }
    }
}
