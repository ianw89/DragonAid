namespace DragonAid.Lib.Data.Model
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
}
