namespace DragonAid.Lib.Data
{
    public class SpellcastResultRange
    {
        public int DoubleEffect;
        public int TripleEffect;
        public int Backfire;

        public SpellcastResult GetResult(int spellCastRoll)
        {
            if (spellCastRoll >= this.Backfire)
            {
                return SpellcastResult.Backfire;
            }

            if (spellCastRoll <= this.TripleEffect)
            {
                return SpellcastResult.TripleEffect;
            }

            if (spellCastRoll <= this.DoubleEffect)
            {
                return SpellcastResult.DoubleEffect;
            }

            return SpellcastResult.Normal;
        }
    }

    public enum SpellcastResult
    {
        Normal = 0,
        DoubleEffect = 1,
        TripleEffect = 2,
        Backfire = 3,
    }
}