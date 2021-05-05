using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommercewebsite.Helpers
{
    public class JWT
    {
        /*After  i will go to the startup for making the map
between the data in the appsettings and this class*/
        public String Key { get; set; }
        public String Issuer { get; set; }
        public String Audience { get; set; }
        public Double DurationInDays { get; set; }
    }
}
