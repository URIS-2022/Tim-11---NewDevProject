using Parcela.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class ParcelaDto
    {
        public int Povrsina { get; set; }

        public String BrojParcele { get; set; }

        public String BrojListaNepokretnosti { get; set; }

        public String KulturaStvarnoStanje { get; set; }

        public String KlasaStvarnoStanje { get; set; }

        public String ObradivostStvarnoStanje { get; set; }

        public String ZasticenaZonaStvarnoStanje { get; set; }

        public String OdvodnjavanjeStvarnoStanje { get; set; }

        public Guid ZasticenaZonaID { get; set; }

        public ZasticenaZonaDto ZasticenaZona { get; set; }

        public Guid OdvodnjavanjeID { get; set; }

        public OdvodnjavanjeDto Odvodnjavanje { get; set; }

        public Guid ObradivostID { get; set; }

        public ObradivostDto Obradivost { get; set; }

        public Guid OblikSvojineID { get; set; }

        public OblikSvojineDto OblikSvojine { get; set; }

        public Guid KulturaID { get; set; }

        public KulturaDto Kultura { get; set; }

        public Guid KlasaID { get; set; }

        public KlasaDto Klasa { get; set; }

        public Guid KatastarskaOpstinaID { get; set; }

        public OpstinaParceleDto Opstina { get; set; }

        public Guid KupacID { get; set; }

        public KupacParceleDto Kupac { get; set; }
    }
}
