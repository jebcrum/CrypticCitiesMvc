using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrypticCities.Models
{
    public class CrypticCity : BaseEntity
    {
        public int Id { get; set; }
        public string Clue { get; set; }
        public string Hint { get; set; }
        public string Answer { get; set; }
    }
}