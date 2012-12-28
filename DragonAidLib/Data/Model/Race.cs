using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Windows.Data.Json;

namespace DragonAidLib.Data.Model
{
    /// <summary>
    /// Instances of this class are NOT persisted to a data source - the only currently valid options
    /// are the public static values (Race.Human, Race.Orc, etc).
    /// </summary>
    public class Race
    {
        public static readonly Race Human = new Race("Human", 0);
        public static readonly Race Elf = new Race("Elf", 1);
        public static readonly Race Dwarf = new Race("Dwarf", -1);
        public static readonly Race Orc = new Race("Orc", -1);
        public static readonly Race ShapeChangerBear = new Race("ShapeChangerBear", 0);
        public static readonly Race ShapeChangerTiger = new Race("ShapeChangerTiger", 0);
        public static readonly Race ShapeChangerWolf = new Race("ShapeChangerWolf", 0);


        public string Name { get; private set; }
        public int TacticalMovementRateModifier { get; private set; }

        private Race(string name, int tmr)
        {
            Name = name;
            TacticalMovementRateModifier = tmr;
        }
    }

    /// <summary>
    /// Converts between the known races and static index values.
    /// </summary>
    public class RaceJsonConverter : IDataMemberJsonConverter
    {
        private static readonly List<Race> Races = new List<Race>
            {
                Race.Human,
                Race.Dwarf,
                Race.Elf,
                Race.Orc
                // Make sure that future updates only append to the end of the list, as opposed to
                // adding new options in the middle of it.
            };

        public object ConvertFromJson(IJsonValue value)
        {
            var numericValue = value.GetNumber();
            var index = Convert.ToInt32(numericValue);
            return Races[index];
        }

        public IJsonValue ConvertToJson(object instance)
        {
            var race = instance as Race;
            var index = Races.IndexOf(race);
            return JsonValue.CreateNumberValue(index);
        }
    }
}
