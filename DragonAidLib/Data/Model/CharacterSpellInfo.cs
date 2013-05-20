namespace DragonAid.Lib.Data.Model
{
    public class CharacterSpellInfo
    {
        public CharacterSpellInfo(Spell spell, int rank)
        {
            Spell = spell;
            Rank = rank;
        }

        public Spell Spell { get; set; }
        public int Rank { get; set; }
    }
}