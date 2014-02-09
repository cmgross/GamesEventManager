using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamesEventManager.Models
{
    public class ZipCodeViewModel
    {
        [Required(ErrorMessage = "Zip code is required.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Zip code must be 5 digits.")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Zip code may only contain numbers.")]
        public string ZipCode { get; set; }
    }
}