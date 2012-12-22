namespace DragonAidLib.Data.Model
{
    public class Race
    {
        private readonly string _name;
        private readonly int _tmr;

        private Race(string name, int tmr)
        {
            _name = name;
            _tmr = tmr;
        }

        public string Name
        {
            get { return _name; }
        }

        public int TacticalMovementRateModifier
        {
            get { return _tmr; }
        }

        public static Race Human = new Race("Human", 0);
        public static Race Elf = new Race("Elf", 1);
        public static Race Dwarf = new Race("Dwarf", -1);
        public static Race Orc = new Race("Orc", -1);
        public static Race ShapeChangerBear = new Race("ShapeChangerBear", 0);
        public static Race ShapeChangerTiger = new Race("ShapeChangerTiger", 0);
        public static Race ShapeChangerWolf = new Race("ShapeChangerWolf", 0);
    }
}
