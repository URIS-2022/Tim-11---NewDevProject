﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcela.Models
{
    public class OdvodnjavanjeCreateDto
    {
        [Required(ErrorMessage = "Obavezno je uneti naziv odvodanjavanja")]
        public String OdvodnjavanjeNaziv { get; set; }
    }
}
