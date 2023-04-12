using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptBYU.Models
{
    public class MummyEntity
    {
        #nullable enable
        [Key]
        public long id { get; set; }
        public string? burialnumber { get; set; }
        public string? squarenorthsouth { get; set; }
        public string? northsouth { get; set; }
        public string? squareeastwest { get; set; }
        public string? eastwest { get; set; }
        public string? area { get; set; }
        public string? sex { get; set; }
        public string? depth { get; set; }
        public string? length { get; set; }
        public string? ageatdeath { get; set; }
        public string? headdirection { get; set; }
        public string? haircolor { get; set; }
        public string? facebundles { get; set; }

    }

    public class Color
    {
        public string? textile_color_value { get; set; }
    }

    public class Structure
    {
        public string? textile_structure_value { get; set; }
    }

    public class Function
    {
        public string? textilefunction_value { get; set; }
    }
}
