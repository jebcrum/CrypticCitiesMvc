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

        public virtual ICollection<Vote> Votes { get; set; }

        [ScaffoldColumn(false)]
        public string HintSequence { get; set; }

        public decimal ApprovalRating { get; set; }
    }

    public class Vote
    {
        public int Id { get; set; }
        public int CrypticCityId { get; set; }
        public virtual CrypticCity CrypticCity { get; set; }
        public bool IsApproved { get; set; }
        public string User { get; set; }
        public string IPAddress { get; set; }

    }
}