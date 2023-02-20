using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KatastarskaOpstinaAgregat.Models
{
    public class KatastarskaOpstinaDto
    {
        [Required(ErrorMessage = "Naziv katastarske opstine je obavezan")]
        [StringLength(50)]
        public String NazivKatastarskeOpstine { get; set; }
    }
}
