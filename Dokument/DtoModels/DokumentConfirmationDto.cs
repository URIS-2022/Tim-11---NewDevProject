using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.DtoModels
{
    public class DokumentConfirmationDto
    {
        /// <summary>
        /// DokumentId - ID dokumenta
        /// </summary>
        public int DokumenId { get; set; }

        /// <summary>
        /// Datum izdavanja - datum izdavanja dokumenta
        /// </summary>
        public DateTime? DatumIzdavanja { get; set; }
    }
}
