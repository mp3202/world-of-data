using System.ComponentModel.DataAnnotations;    // Required for Data Validation

namespace world_of_data.Models
{
    public class Character
    {
        public int CharacterID {get; set;}	// Primary Key

        [Display(Name = "Player")]
        public string charName {get; set;} = string.Empty;
        public string Realm {get; set;} = string.Empty;
        public int iLVL {get; set;} // armor level

        [Display(Name = "Arena 2v2 Score")]
        public int Arena2v2 {get; set;} 

        [Display(Name = "Arena 3v3 Score")]
        public int Arena3v3 {get; set;} 

        [Display(Name = "Mythics Score")]
        public int MythicScore {get; set;} 

        // Add navigation property to MANY side
        // Each character belongs to ONE class        
        public WoWClass WoWClass {get; set;} = null!; // Navigation property
        public int WoWClassID {get; set;} // Foreign Key

        // public override string ToString()
        // {
        //     return $"{charName}";
        // }
    }
}