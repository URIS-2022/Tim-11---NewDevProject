using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class ObradivostEntity
    {
        [Key]
        public Guid ObradivostID { get; set; }

        public String ObradivostNaziv { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}
