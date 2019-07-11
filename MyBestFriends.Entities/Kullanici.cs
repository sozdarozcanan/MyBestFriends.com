using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.Entities
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        
        [Key]
        public int KullaniciID { get; set; }
        [ 
         Required,
         StringLength(25,ErrorMessage = "Kullanıcı adı soyadı 30 karakterden fazla olamaz.")]
        public string KullaniciAdiSoyadi { get; set; }
        [Required,
         StringLength(70, ErrorMessage = "E-posta formatı 40 karakterden fazla olamaz."),
         EmailAddress(ErrorMessage ="E-posta formatında giriniz.")]
        public string Mail { get; set; }
        [Required,
         StringLength(25)]
         
        public string Sifre { get; set; }
        [Required,
         MinLength(11,ErrorMessage ="Minimum 11 karakter olabilir."),
         MaxLength(11,ErrorMessage ="Minimum 11 karakter olabilir.")]
        public string Telefon { get; set; }
        [StringLength(30)]
        public string ProfilFotoDosyaAdi { get; set; }

        public virtual List<Ilan> Ilanlar { get; set; }

        
    }
}

