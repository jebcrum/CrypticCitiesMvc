using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrypticCities.Models
{
    public class CrypticCity : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Clue { get; set; }

        [Required]
        public string Hint { get; set; }

        [Required]
        public string Answer { get; set; }

        [ScaffoldColumn(false)]
        public string HintSequence { get; set; }
    }
}