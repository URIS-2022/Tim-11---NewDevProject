using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokument.DtoModels
{
    public class DokumentDto
    {

        /// <summary>
        /// ID dokumenta
        /// </summary>
        public Guid DokumentId { get; set; }


        /// <summary>
        /// Datum izdavanja - datum izdavanja dokumenta
        /// </summary>
        public DateTime? DatumIzdavanja { get; set; }




    }
}
