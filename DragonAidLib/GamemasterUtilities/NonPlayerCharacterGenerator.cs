using DragonAid.Lib.Data;
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
        private readonly IWeaponChooser _weaponChooser;

        public NonPlayerCharacterGenerator()
        {
            this._characteristicGenerator = new RandomCharacteristicGenerator();
            this._weaponChooser = new RandomWeaponChooser(new WeaponSkills().WeaponList);
        }

        public Character GenerateFromTemplate(NonPlayerCharacterTemplate template)
        {
            var character = new Character
                {
                    PhysicalStrength = this._characteristicGenerator.Generate(template.PhysicalStrengthRange),
                    ManualDexterity = this._characteristicGenerator.Generate(template.ManualDexterityRange),
                    Agility = this._characteristicGenerator.Generate(template.AgilityRange),
                    MagicalAptitude = this._characteristicGenerator.Generate(template.MagicalAptitudeRange),
                    Willpower = this._characteristicGenerator.Generate(template.WillpowerRange),
                    Endurance = this._characteristicGenerator.Generate(template.EnduranceRange),
                    Fatigue = this._characteristicGenerator.Generate(template.FatigueRange),
                    Perception = this._characteristicGenerator.Generate(template.PerceptionRange),
                    PhysicalBeauty = this._characteristicGenerator.Generate(template.PhysicalBeautyRange),
                    NaturalArmor = this._characteristicGenerator.Generate(template.NaturalArmorRange)
                };

            this._weaponChooser.ChooseWeapons(character);

            // TODO Other stuff

            return character;
        }
    }
}
