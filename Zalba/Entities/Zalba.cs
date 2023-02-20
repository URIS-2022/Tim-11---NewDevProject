using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Zalba.Entities
{
    public class Zalba
    {
        [Key]
        public Guid ZalbaId { get; set; }

        public DateTime DatumPodnosenja { get; set; }

        public DateTime DatumResenja { get; set; }

        public string? Obrazlozenje { get; set; }
        public string? Status { get; set; }
    }
}
