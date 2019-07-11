using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBestFriends.Entities
{
    [Table("Hayvanlar")]
    public class Hayvan
    {
        [Key]
        public int HayvanID { get; set; }      
        [Required]
        [MaxLength(30)]
        public string HayvanTuru { get; set; }
        
        public virtual List<HayvanCins> HayvanCinsleri { get; set; }
    
    }
}

