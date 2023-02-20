using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{

    public class DeoParceleEntity
    {
    
        [Key]
        public Guid DeoParceleID { get; set; }

        public int RedniBroj { get; set; }

        public int PovrsinaDelaParcele { get; set; }

        [ForeignKey("Parcela")]
        public Guid ParcelaID { get; set; }

        public ParcelaEntity Parcela { get; set; }
    }
}
