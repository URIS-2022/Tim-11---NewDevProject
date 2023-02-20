using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class KulturaEntity
    {
        [Key]
        public Guid KulturaID { get; set; }

        public String KulturaNaziv { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}
