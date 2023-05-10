using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace world_of_data.Models
{
    public class WoWClass
    {
        public int WoWClassID {get; set;} // Primary key

        [Display(Name = "Class")]
        public string className {get; set;} = string.Empty; // ex rogue, priest, warlock, etc

        [Display(Name = "Specialization")]
        public string classSpec {get; set;} = string.Empty; // ex for rogue, assassination, subtlety, outlaw

        [Display(Name = "Armor Type")]
        public string classArmor {get; set;} = string.Empty; // mail, cloth, leather, plate

        [Display(Name = "Role")]
        public string classRole {get; set;} = string.Empty; // DPS, healer, tank

        // One-to-many relationships
        // Setup navigation property on ONE side, List of MANY side
        public List<Character> Characters {get; set;} = new List<Character>();

        public override string ToString()
        {
            return $"{className}";
        }
    }
}