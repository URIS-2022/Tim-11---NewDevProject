using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class OdvodnjavanjeEntity
    {
        [Key]
        public Guid OdvodnjavanjeID { get; set; }

        public String OdvodnjavanjeNaziv { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}

