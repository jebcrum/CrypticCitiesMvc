using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrypticCities.Models
{
    public class BaseEntity
    {
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }
    }
}