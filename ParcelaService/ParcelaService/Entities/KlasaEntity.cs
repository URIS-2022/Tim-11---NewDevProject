using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class KlasaEntity
    {
        [Key]
        public Guid KlasaID { get; set; }

        public String KlasaOznaka { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}
