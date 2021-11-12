using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.STS
{
    public class AltYuklenici
    {
        int id; string firmaadi, firmaadresi, il, ilçe, telefon, faliyatalani, personeladi, personeltelefon, mail;

        public int Id { get => id; set => id = value; }
        public string Firmaadi { get => firmaadi; set => firmaadi = value; }
        public string Firmaadresi { get => firmaadresi; set => firmaadresi = value; }
        public string Il { get => il; set => il = value; }
        public string Ilçe { get => ilçe; set => ilçe = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Faliyatalani { get => faliyatalani; set => faliyatalani = value; }
        public string Personeladi { get => personeladi; set => personeladi = value; }
        public string Personeltelefon { get => personeltelefon; set => personeltelefon = value; }
        public string Mail { get => mail; set => mail = value; }

        public AltYuklenici(int id, string firmaadi, string firmaadresi, string il, string ilçe, string telefon, string faliyatalani, string personeladi, string personeltelefon, string mail)
        {
            this.id = id;
            this.firmaadi = firmaadi;
            this.firmaadresi = firmaadresi;
            this.il = il;
            this.ilçe = ilçe;
            this.telefon = telefon;
            this.faliyatalani = faliyatalani;
            this.personeladi = personeladi;
            this.personeltelefon = personeltelefon;
            this.mail = mail;
        }

        public AltYuklenici(string firmaadi, string firmaadresi, string il, string ilçe, string telefon, string faliyatalani, string personeladi, string personeltelefon, 
            string mail)
        {
            this.firmaadi = firmaadi;
            this.firmaadresi = firmaadresi;
            this.il = il;
            this.ilçe = ilçe;
            this.telefon = telefon;
            this.faliyatalani = faliyatalani;
            this.personeladi = personeladi;
            this.personeltelefon = personeltelefon;
            this.mail = mail;
        }
    }
}
