using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zalba.Entities
{
    public class ZalbaConfirmation
    {
        public Guid ZalbaId { get; set; }

        public DateOnly DatumPodnosenja { get; set; }

        public DateOnly DatumResenja { get; set; }

        public string Obrazlozenje { get; set; }
        public string Status { get; set; }
    }
}
