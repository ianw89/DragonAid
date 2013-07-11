using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.GamemasterUtilities
{
    /// <summary>
    /// This class can generate a Character from a NonPlayerCharacterTemplate.
    /// It delegates the various responsibilities to other generators.
    /// </summary>
    public class NonPlayerCharacterGenerator
    {
        private readonly RandomCharacteristicGenerator _characteristicGenerator;

        public NonPlayerCharacterGenerator()
        {
            this._characteristicGenerator = new RandomCharacteristicGenerator();
        }

        public Character GenerateFromTemplate(NonPlayerCharacterTemplate template)
        {
            var character = new Character();
            
            character.PhysicalStrength = this._characteristicGenerator.Generate(template.PhysicalStrengthRange);
            character.ManualDexterity = this._characteristicGenerator.Generate(template.ManualDexterityRange);
            character.Agility = this._characteristicGenerator.Generate(template.AgilityRange);
            character.MagicalAptitude = this._characteristicGenerator.Generate(template.MagicalAptitudeRange);
            character.Willpower = this._characteristicGenerator.Generate(template.WillpowerRange);
            character.Endurance = this._characteristicGenerator.Generate(template.EnduranceRange);
            character.Fatigue = this._characteristicGenerator.Generate(template.FatigueRange);
            character.Perception = this._characteristicGenerator.Generate(template.PerceptionRange);
            character.PhysicalBeauty = this._characteristicGenerator.Generate(template.PhysicalBeautyRange);

            // TODO Other stuff

            return character;
        }
    }
}
