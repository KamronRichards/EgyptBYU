using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptBYU.Models
{
    public class MummyEntity
    {
        [Key]
        public int BurialId { get; set; }
        public int? BurialNumber { get; set; }
        public string? SquareNorthSouth { get; set; }
        public string? NorthSouth { get; set; }
        public string? SquareEastWest { get; set; }
        public string? EastWest { get; set; }
        public string? Area { get; set; }
        public string? Textile_Color_Value { get; set; }
        public string? Textile_Structure_Value { get; set; }
        public string? TextileFunction_Value { get; set; }
        public string? Sex { get; set; }
        public int? Depth { get; set; }
        public int? Length { get; set; }
        public int? AgeAtDeath { get; set; }
        public string? HeadDirection { get; set; }
        public string? HairColor { get; set; }
        public string? FaceBundles { get; set; }

    }
}
