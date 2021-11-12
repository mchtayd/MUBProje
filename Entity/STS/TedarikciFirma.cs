using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class TedarikciFirma
    {
        int id; string firmaadi, firmaadresi, firmail, firmailce, telefon, faliyetalani, personelad, personeltelefon, mail, benzersiz;

        public int Id { get => id; set => id = value; }
        public string Firmaadi { get => firmaadi; set => firmaadi = value; }
        public string Firmaadresi { get => firmaadresi; set => firmaadresi = value; }
        public string FirmaIl { get => firmail; set => firmail = value; }
        public string Firmailce { get => firmailce; set => firmailce = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Faliyetalani { get => faliyetalani; set => faliyetalani = value; }
        public string Personelad { get => personelad; set => personelad = value; }
        public string Personeltelefon { get => personeltelefon; set => personeltelefon = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Benzersiz { get => benzersiz; set => benzersiz = value; }
      
        public TedarikciFirma(int id, string firmaadi, string firmaadresi, string firmail, string firmailce, string telefon, 
            string faliyetalani, string personelad, string personeltelefon, string mail, string benzersiz)
        {
            this.id = id;
            this.firmaadi = firmaadi;
            this.firmaadresi = firmaadresi;
            this.firmail = firmail;
            this.firmailce = firmailce;
            this.telefon = telefon;
            this.faliyetalani = faliyetalani;
            this.personelad = personelad;
            this.personeltelefon = personeltelefon;
            this.mail = mail;
            this.benzersiz = benzersiz;
        }

        public TedarikciFirma(string firmaadi, string firmaadresi, string firmail, string firmailce, string telefon, 
            string faliyetalani, string personelad, string personeltelefon, string mail, string benzersiz)
        {
            this.firmaadi = firmaadi;
            this.firmaadresi = firmaadresi;
            this.firmail = firmail;
            this.firmailce = firmailce;
            this.telefon = telefon;
            this.faliyetalani = faliyetalani;
            this.personelad = personelad;
            this.personeltelefon = personeltelefon;
            this.mail = mail;
            this.benzersiz = benzersiz;
        }

        public TedarikciFirma(string firmaadi, string mail)
        {
            this.firmaadi = firmaadi;
            this.mail = mail;
        }
    }
}
