using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.Entities
{
    public class DokumentConfirmation
    {
        public Guid DokumentId { get; set; }

        public DateTime DatumIzdavanja { get; set; }
    }
}
