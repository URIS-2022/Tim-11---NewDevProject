using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class ParcelaEntity
    {
        [Key]
        public Guid ParcelaID { get; set; }

        public int Povrsina { get; set; }

        public String BrojParcele { get; set; }

        public String BrojListaNepokretnosti { get; set; }

        public String KulturaStvarnoStanje { get; set; }

        public String KlasaStvarnoStanje { get; set; }

        public String ObradivostStvarnoStanje { get; set; }

        public String ZasticenaZonaStvarnoStanje { get; set; }

        public String OdvodnjavanjeStvarnoStanje { get; set; }

        [ForeignKey("ZasticenaZona")]
        public Guid ZasticenaZonaID { get; set; }

        public ZasticenaZonaEntity ZasticenaZona { get; set; }

        [ForeignKey("Odvodnjavanje")]
        public Guid OdvodnjavanjeID { get; set; }

        public OdvodnjavanjeEntity Odvodnjavanje { get; set; }

        [ForeignKey("Obradivost")]
        public Guid ObradivostID { get; set; }

        public ObradivostEntity Obradivost { get; set; }

        [ForeignKey("OblikSvojine")]
        public Guid OblikSvojineID { get; set; }

        public OblikSvojineEntity OblikSvojine { get; set; }


        [ForeignKey("Kultura")]
        public Guid KulturaID { get; set; }

        public KulturaEntity Kultura { get; set; }

        [ForeignKey("Klasa")]
        public Guid KlasaID { get; set; }

        public KlasaEntity Klasa { get; set; }

        public List<DeoParceleEntity> DeloviParcele { get; set; }

        public Guid KatastarskaOpstinaID { get; set; }

        public Guid KupacID { get; set; }
    }
}
