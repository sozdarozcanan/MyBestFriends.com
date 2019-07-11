using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBestFriends.Entities
{
    [Table("HayvanCinsler")]
    public class HayvanCins
    {
        [Key]
        public int CinsID { get; set; }
        public int HayvanID { get; set; }
        [Required]
        [MaxLength(30)]
        public string CinsAdi { get; set; }
        
        public virtual Hayvan Hayvan { get; set; }
        public virtual List<Ilan> Ilanlar { get; set; }
    }
}

