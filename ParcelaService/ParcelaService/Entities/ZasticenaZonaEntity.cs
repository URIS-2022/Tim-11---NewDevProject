using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class ZasticenaZonaEntity
    {
        [Key]
        public Guid ZasticenaZonaID { get; set; }

        public int ZasticenaZonaOznaka { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}

