using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.Entities
{
    public class Dokument
    {
        [Key]
        public Guid DokumentId { get; set; }

        public DateTime DatumIzdavanja { get; set; }
    }
}
