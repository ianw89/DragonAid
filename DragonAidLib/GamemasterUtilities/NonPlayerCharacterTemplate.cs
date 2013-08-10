namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// Template for generating a pseduo random NPC.
    /// </summary>
    public class NonPlayerCharacterTemplate
    {
        public CharacteristicRangeTemplate PhysicalStrengthRange { get; set; }
        public CharacteristicRangeTemplate ManualDexterityRange { get; set; }
        public CharacteristicRangeTemplate AgilityRange { get; set; }
        public CharacteristicRangeTemplate WillpowerRange { get; set; }
        public CharacteristicRangeTemplate MagicalAptitudeRange { get; set; }
        public CharacteristicRangeTemplate EnduranceRange { get; set; }
        public CharacteristicRangeTemplate FatigueRange { get; set; }
        public CharacteristicRangeTemplate PerceptionRange { get; set; }
        public CharacteristicRangeTemplate PhysicalBeautyRange { get; set; }
        public CharacteristicRangeTemplate NaturalArmorRange { get; set; }

        // TODO Weapon, Spell, Armor, and other important things should have a similar mechanic
    }
}
