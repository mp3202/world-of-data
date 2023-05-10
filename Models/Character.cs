using System.ComponentModel.DataAnnotations;    // Required for Data Validation

namespace world_of_data.Models
{
    public class Character
    {
        public int CharacterID {get; set;}	// Primary Key
        public string charName {get; set;} = string.Empty;
        public string Realm {get; set;} = string.Empty;
        public int iLVL {get; set;} // armor level
        public int Arena2v2 {get; set;} 
        public int Arena3v3 {get; set;} 
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