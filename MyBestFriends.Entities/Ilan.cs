using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.Entities
{
    [Table("Ilanlar")]
    public class Ilan
    {
         [Key]
        public int IlanID { get; set; }
        [Required]
        public int KullaniciID { get; set; }
        [Required]
        public int SehirID { get; set; }
        [Required]
        public int CinsID { get; set; }
        [StringLength(500,ErrorMessage ="500 karakterden fazla giremezsiniz.")]
        public string Aciklama { get; set; }
        [Required]
        public DateTime IlanTarihi { get; set; }
        [Required]
        public Boolean Cinsiyet { get; set; }
        [Required]
        public Boolean IlanTuru { get; set; }
        public string Fotograf { get; set; }
    
        public virtual Kullanici Kullanici { get; set; }
        public virtual Sehir Sehir { get; set; }
        public virtual HayvanCins Cins { get; set; }
    }
}
