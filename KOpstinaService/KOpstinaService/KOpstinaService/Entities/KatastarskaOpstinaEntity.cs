using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KatastarskaOpstinaAgregat.Entities
{
    public class KatastarskaOpstinaEntity
    {
        [Key]
        public Guid KatastarskaOpstinaID { get; set; }

        [Required]
        [StringLength(50)]
        public String NazivKatastarskeOpstine { get; set; }
    }
}
