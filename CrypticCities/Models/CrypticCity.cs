using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrypticCities.Models
{
    public class CrypticCity
    {
        public int Id { get; set; }
        public string Clue { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; }

        public string UpdatedById { get; set; }
        public ApplicationUser UpdatedBy { get; set; }

    }
}