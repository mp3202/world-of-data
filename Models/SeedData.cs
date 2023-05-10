using Microsoft.EntityFrameworkCore;

namespace world_of_data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WoWClassDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<WoWClassDbContext>>()))
            {
                // Look for any classes.
                if (context.WoWClasses.Any())
                {
                    return; // DB has been seeded
                }
                
                context.WoWClasses.AddRange(
                    // warriors
                    new WoWClass{className = "Warrior", classSpec = "Fury", classArmor = "Plate", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Sherzian", Realm = "Ragnaros" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2727},
                            new Character {charName = "Magnusz", Realm = "Zul’jin" , iLVL = 401, Arena2v2 = 2434, Arena3v3 = 2934, MythicScore = 0},
                        } // end Characters list
                    }, // end new WoWClass,
                    new WoWClass{className = "Warrior", classSpec = "Arms", classArmor = "Plate", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Larrythelob", Realm = "Kel’Thuzad" , iLVL = 388, Arena2v2 = 2213, Arena3v3 = 2890, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Warrior", classSpec = "Protection", classArmor = "Plate", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Zupai", Realm = "Bonechewer" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2697}
                            } // end Characters list
                    }, // end new WoWClass

                    // paladins
                    new WoWClass{className = "Paladin", classSpec = "Holy", classArmor = "Plate", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Mercyg", Realm = "Stormrage" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2623}
                        } // end Characters list
                    }, // end new WoWClass,
                    new WoWClass{className = "Paladin", classSpec = "Retribution", classArmor = "Plate", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Vicodinzz", Realm = "Mal’Ganis" , iLVL = 419, Arena2v2 = 1540, Arena3v3 = 1512, MythicScore = 3064}, 
                            new Character {charName = "Smashyofoch", Realm = "Daggerspine" , iLVL = 416, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2656}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Paladin", classSpec = "Protection", classArmor = "Plate", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Miilopally", Realm = "Area 52" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 3232},
                            new Character {charName = "Minilatte", Realm = "Stormrage" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2625}
                        } // end Characters list
                    }, // end new WoWClass

                    // hunters
                    new WoWClass{className = "Hunter", classSpec = "Survival", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Pxry", Realm = "Drenden" , iLVL = 403, Arena2v2 = 2404, Arena3v3 = 2919, MythicScore = 2017}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Hunter", classSpec = "Marksman", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Gvjellybeans", Realm = "Tichondrius" , iLVL = 402, Arena2v2 = 2216, Arena3v3 = 2922, MythicScore = 905}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Hunter", classSpec = "Beastmaster", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Gotgirth", Realm = "Bonechewer" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2801}
                        } // end Characters list
                    }, // end new WoWClass

                    // rogues
                    new WoWClass{className = "Rogue", classSpec = "Assassination", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Yodiegang", Realm = "Tichondrius" , iLVL = 392, Arena2v2 = 1754, Arena3v3 = 2571, MythicScore = 815},
                            new Character {charName = "Spotty", Realm = "Kirin Tor" , iLVL = 404, Arena2v2 = 1870, Arena3v3 = 2046, MythicScore = 2000}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Rogue", classSpec = "Outlaw", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Gagadaga", Realm = "Anub’arak" , iLVL = 394, Arena2v2 = 1876, Arena3v3 = 1855, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Rogue", classSpec = "Subtlety", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Tmpikaboo", Realm = "Tichondrius" , iLVL = 393, Arena2v2 = 1758, Arena3v3 = 2938, MythicScore = 515},
                            new Character {charName = "Whaazz", Realm = "Ravencrest" , iLVL = 401, Arena2v2 = 2143, Arena3v3 = 3120, MythicScore = 0}, 
                            new Character {charName = "Linkrogue", Realm = "Bloodhoof" , iLVL = 412, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2430}
                        }
                    }, // end new WoWClass

                    // priests
                    new WoWClass{className = "Priest", classSpec = "Discipline", classArmor = "Cloth", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Drainsurgeon", Realm = "Bonechewer" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 3052},
                            new Character {charName = "Leebow", Realm = "Tichondrius" , iLVL = 386, Arena2v2 = 2404, Arena3v3 = 2438, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass,
                    new WoWClass{className = "Priest", classSpec = "Holy", classArmor = "Cloth", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Wolfpriest", Realm = "Thunderlord" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2961}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Priest", classSpec = "Shadow", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Celestite", Realm = "Area 52" , iLVL = 420, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2953}
                        } // end Characters list
                    }, // end new WoWClass,

                    // shamans
                    new WoWClass{className = "Shaman", classSpec = "Elemental", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Smellyogre", Realm = "Area 52" , iLVL = 408, Arena2v2 = 1685, Arena3v3 = 2698, MythicScore = 1984}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Shaman", classSpec = "Enhancement", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Dumdumdamdum", Realm = "Area 52" , iLVL = 421, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2821},
                            new Character {charName = "Belandrious", Realm = "Bleeding Hollow" , iLVL = 419, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2791},
                            new Character {charName = "Electrix", Realm = "Moonrunner" , iLVL = 403, Arena2v2 = 2110, Arena3v3 = 2509, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Shaman", classSpec = "Restoration", classArmor = "Mail", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Ozen", Realm = "Stormrage" , iLVL = 419, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2823},
                            new Character {charName = "Wurzang", Realm = "Suramar" , iLVL = 400, Arena2v2 = 2114, Arena3v3 = 2620, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass

                    // mages
                    new WoWClass{className = "Mage", classSpec = "Frost", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Castnow", Realm = "Trollbane" , iLVL = 413, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2264}
                        } // end Characters list
                    }, // end new WoWClass,
                    new WoWClass{className = "Mage", classSpec = "Arcane", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Numbing", Realm = "Sargeras" , iLVL = 404, Arena2v2 = 2269, Arena3v3 = 2469, MythicScore = 217}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Mage", classSpec = "Fire", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Emilia", Realm = "Malygos" , iLVL = 405, Arena2v2 = 2208, Arena3v3 = 2919, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass

                    // warlocks
                    new WoWClass{className = "Warlock", classSpec = "Destruction", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Rot", Realm = "Proudmoore" , iLVL = 420, Arena2v2 = 1236, Arena3v3 = 1809, MythicScore = 3307},
                            new Character {charName = "Harambe", Realm = "Sargeras" , iLVL = 418, Arena2v2 = 2370, Arena3v3 = 2716, MythicScore = 2877}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Warlock", classSpec = "Demonology", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Covack", Realm = "Bonechewer" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2685}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Warlock", classSpec = "Affliction", classArmor = "Cloth", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Xadge", Realm = "Tichondrius" , iLVL = 401, Arena2v2 = 1798, Arena3v3 = 2257, MythicScore = 0}
                        } // end Characters list
                    }, // end new WoWClass

                    // monks
                    new WoWClass{className = "Monk", classSpec = "Brewmaster", classArmor = "Leather", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Llaamallama", Realm = "Kil’jaeden" , iLVL = 415, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2585}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Monk", classSpec = "Mistweaver", classArmor = "Leather", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Peachpies", Realm = "Tichondrius" , iLVL = 421, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2832}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Monk", classSpec = "Windwalker", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Wengweng", Realm = "Moon Guard" , iLVL = 418, Arena2v2 = 989, Arena3v3 = 0, MythicScore = 3013}
                        } // end Characters list
                    }, // end new WoWClass

                    // druids
                    new WoWClass{className = "Druid", classSpec = "Guardian", classArmor = "Leather", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Auraania", Realm = "Area 52" , iLVL = 419, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 3143}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Druid", classSpec = "Restoration", classArmor = "Leather", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Dno", Realm = "Demon Soul" , iLVL = 406, Arena2v2 = 2479, Arena3v3 = 2916, MythicScore = 152}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Druid", classSpec = "Feral", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Sepulchre", Realm = "Hakkar" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2889}
                        } // end Characters list
                    }, // end new WoWClass,
                    new WoWClass{className = "Druid", classSpec = "Balance", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Boombox", Realm = "Daggerspine" , iLVL = 419, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2727}
                        } // end Characters list
                    }, // end new WoWClass

                    // demon hunters
                    new WoWClass{className = "Demon Hunter", classSpec = "Vengeance", classArmor = "Leather", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Illidaria", Realm = "Blood Furnace" , iLVL = 418, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2489}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Demon Hunter", classSpec = "Havoc", classArmor = "Leather", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Luciffer", Realm = "Barthilas" , iLVL = 420, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 3140}
                        } // end Characters list
                    }, // end new WoWClass

                    // death knights
                    new WoWClass{className = "Death Knight", classSpec = "Blood", classArmor = "Plate", classRole = "Tank",
                        Characters = new List<Character> { 
                            new Character {charName = "Volg", Realm = "Area 52" , iLVL = 421, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 3002}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Death Knight", classSpec = "Frost", classArmor = "Plate", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Azrasha", Realm = "Wyrmrest Accord" , iLVL = 408, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 1881}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Death Knight", classSpec = "Unholy", classArmor = "Plate", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Oql", Realm = "Tichondrius" , iLVL = 398, Arena2v2 = 2416, Arena3v3 = 1958, MythicScore = 0},
                            new Character {charName = "Petkick", Realm = "Tichondrius" , iLVL = 398, Arena2v2 = 2544, Arena3v3 = 2918, MythicScore = 155}
                        } // end Characters list
                    }, // end new WoWClass

                    // evokers
                    new WoWClass{className = "Evoker", classSpec = "Preservation", classArmor = "Mail", classRole = "Healer",
                        Characters = new List<Character> { 
                            new Character {charName = "Sleepiihead", Realm = "Stormrage" , iLVL = 389, Arena2v2 = 2281, Arena3v3 = 3074, MythicScore = 3057}
                        } // end Characters list
                    }, // end new WoWClass
                    new WoWClass{className = "Evoker", classSpec = "Devastation", classArmor = "Mail", classRole = "DPS",
                        Characters = new List<Character> { 
                            new Character {charName = "Solera", Realm = "Stormrage" , iLVL = 417, Arena2v2 = 0, Arena3v3 = 0, MythicScore = 2883}
                        } // end Characters list
                    } // end new WoWClass,

                ); // end addrange
                
                context.SaveChanges();
            }
        }
    }
}