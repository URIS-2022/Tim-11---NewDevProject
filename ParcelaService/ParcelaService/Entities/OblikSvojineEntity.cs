using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Entities
{
    public class OblikSvojineEntity
    {
        [Key]
        public Guid OblikSvojineID { get; set; }

        public String OblikSvojineNaziv { get; set; }

        public List<ParcelaEntity> Parcele { get; set; }
    }
}