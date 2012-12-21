using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace DragonAidWindowsClient.DataModel
{
    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();

        private ObservableCollection<SampleDataGroup> _allGroups = new ObservableCollection<SampleDataGroup>();
        public ObservableCollection<SampleDataGroup> AllGroups
        {
            get { return _allGroups; }
        }

        public static IEnumerable<SampleDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
            
            return _sampleDataSource.AllGroups;
        }

        public static SampleDataGroup GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            return _sampleDataSource.AllGroups.First(group => group.UniqueId.Equals(uniqueId));
        }

        public static Character GetCharacter(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            return _sampleDataSource.AllGroups.SelectMany(group => group.Items).First(item => item.UniqueId.Equals(uniqueId));
        }

        public SampleDataSource()
        {
            String itemContent = String.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
                        "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

            var group1 = new SampleDataGroup("Player-Character-Group",
                    "Player Characters",
                    "View Characteristics and Information",
                    "Assets/DarkGray.png",
                    "Here you can view the characteristics and skills of all the player characters.");

            var muscles = new Character("Muscles Bufflyton", "Dan Bjorge", "Assets/muscles-bufflyton.jpg", "Shadow Weaver and Nazi Hunter from Celbina.", itemContent, group1)
                              {
                                  Agility = 16,
                                  Endurance = 20,
                                  Fatigue = 22,
                                  MagicalAptitude = 20,
                                  ManualDexterity = 12,
                                  Perception = 9,
                                  PhysicalBeauty = 15,
                                  PhysicalStrength = 9,
                                  Willpower = 15,
                                  Race = Race.Human
                              };

            muscles.CombatActions.Add(CombatAction.AttackWithSap);
            muscles.CombatActions.Add(CombatAction.CastWalkingUnseen);

            group1.Items.Add(muscles);

            var caldus = new Character("Caldus Stormcinder", "Matt Meehan", "Assets/eagleback.jpg", "Namer and Magekiller from Celbina.", itemContent, group1)
                             {
                                 Agility = 12,
                                 Endurance = 17,
                                 Fatigue = 23,
                                 MagicalAptitude = 10,
                                 ManualDexterity = 15,
                                 Perception = 9,
                                 PhysicalBeauty = 14,
                                 PhysicalStrength = 17,
                                 Willpower = 18,
                                 Race = Race.Elf
                             };

            group1.Items.Add(caldus);

            AllGroups.Add(group1);

            var group2 = new SampleDataGroup("Non-Player-Character-Group",
                    "Group Title: 2",
                    "Group Subtitle: 2",
                    "Assets/LightGray.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group2.Items.Add(new Character("Item Title: 1",
                    "Item Subtitle: 1",
                    "Assets/DarkGray.png",
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    itemContent,
                    group2));
            group2.Items.Add(new Character("Item Title: 2",
                    "Item Subtitle: 2",
                    "Assets/MediumGray.png",
                    "Item Description: Pellentesque porta, mauris quis interdum vehicula, urna sapien ultrices velit, nec venenatis dui odio in augue. Cras posuere, enim a cursus convallis, neque turpis malesuada erat, ut adipiscing neque tortor ac erat.",
                    itemContent,
                    group2));
            
            AllGroups.Add(group2);
        }
    }
}
