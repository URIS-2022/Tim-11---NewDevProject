﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class KulturaUpdateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti id kulture")]
        public Guid KulturaID { get; set; }

        [Required(ErrorMessage = "Obavezno je uneti naziv kulture")]
        public String KulturaNaziv { get; set; }
    }
}
