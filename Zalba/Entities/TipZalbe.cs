using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zalba.Entities
{
    public class TipZalbe
    {
        [Key]
        public Guid TipZalbeId { get; set; }


        public string? Opis { get; set; }

    }
}
