using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.Entities
{
    [Table("Sehirler")]
    public class Sehir
    {
        [Key]       
        public int SehirID { get; set; }
        [Required]
        [MaxLength(15)]
        public string SehirAdi { get; set; }
        
        public virtual List<Ilan> Ilanlar { get; set; }
    }
}
    
