using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastNow.Model
{
    public class Area
    {
        public string? ID { get; set; }
        public string? LocalizedName { get; set; }
    }

    public class City
    {
        public int Version { get; set; }
        public int Key { get; set; }
        public int Type { get; set; }
        public int Rank { get; set; }
        public string? LocalizedName { get; set; }
        public Area? Country { get; set; }
        public Area? AdministrativeArea { get; set; }
    }

}
