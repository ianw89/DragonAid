using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    public static class Spells
    {
        private static readonly SpellColleges _colleges;

        static Spells()
        {
            var stream = typeof(Spells).GetTypeInfo().Assembly.GetManifestResourceStream("DragonAid.Lib.SpellData.xml");
            var serializer = new DataContractSerializer(typeof(SpellColleges));
            _colleges = (SpellColleges)serializer.ReadObject(stream);

            Shadow = new ShadowSpells(_colleges.FindCollege("Shadow"));
            Mind = new MindSpells(_colleges.FindCollege("Mind"));
        }

        public static readonly ShadowSpells Shadow;
        public static MindSpells Mind;

        public class ShadowSpells : SpellCollege
        {
            public readonly Talent SpeakToShadowCreatures;
            public readonly Talent NightVision;
            public readonly Talent DetectAura;

            // General Knowledge Spells
            public readonly Spell Blending;
            public readonly Spell Light;
            public readonly Spell Darkness;
            public readonly Spell ShadowForm;
            public readonly Spell WallOfStarlight;
            public readonly Spell WallOfDarkness;
            public readonly Spell Witchsight;
            public readonly Spell WalkingUnseen;
            public readonly Spell GeneralCounterspell;
            public readonly Spell SpecialCounterspell;

            // Special Knowledge Spells
            public readonly Spell Healing;
            public readonly Spell Starfire;
            public readonly Spell ShadowWings;
            public readonly Spell ShadowSlipping;

            public ShadowSpells(SpellCollege collegeToCopy)
                : base(collegeToCopy)
            {
                this.SpeakToShadowCreatures = this.FindTalent("Speak to Shadow Creatures");
                this.NightVision = this.FindTalent("Night Vision");
                this.DetectAura = this.FindTalent("Detect Aura");

                this.Blending = this.FindSpell("Blending");
                this.Light = this.FindSpell("Light");
                this.Darkness = this.FindSpell("Darkness");
                this.ShadowForm = this.FindSpell("Shadow Form");
                this.WallOfStarlight = this.FindSpell("Wall of Starlight");
                this.WallOfDarkness = this.FindSpell("Wall of Darkness");
                this.Witchsight = this.FindSpell("Witchsight");
                this.WalkingUnseen = this.FindSpell("Walking Unseen");
                this.GeneralCounterspell = this.FindSpell("General Counterspell");

                this.SpecialCounterspell = this.FindSpell("Special Counterspell");
                this.Healing = this.FindSpell("Healing");
                this.Starfire = this.FindSpell("Starfire");
                this.ShadowWings = this.FindSpell("Shadow Wings");
                this.ShadowSlipping = this.FindSpell("Shadow Slipping");
            }

            // TODO Rituals
        }

        public class MindSpells : SpellCollege
        {
            // General Knowledge Spells
            public readonly Spell ESP;
            public readonly Spell LimitedPrecognition;
            public readonly Spell MindCloak;
            public readonly Spell Empathy;
            public readonly Spell Hypnotism;
            public readonly Spell ControlAnimal;
            public readonly Spell ControlPerson;

            // Special Knowledge Spells
            public readonly Spell MentalAttack;
            public readonly Spell Telepathy;
            public readonly Spell Phantasm;
            public readonly Spell MolecularDisruption;
            public readonly Spell MolecularRearrangement;
            public readonly Spell ForceShield;
            public readonly Spell MentalHealing;
            public readonly Spell Invisibility;
            public readonly Spell Telekinesis;
            public readonly Spell TelekineticRage;

            // TODO Rituals
            public MindSpells(SpellCollege collegeToCopy) 
                : base(collegeToCopy)
            {
                this.ESP = this.FindSpell("Extrasensory Perception");
                this.LimitedPrecognition = this.FindSpell("Limited Precognition");
                this.MindCloak = this.FindSpell("Mind Cloak");
                this.Empathy = this.FindSpell("Empathy");
                this.Hypnotism = this.FindSpell("Hypnotism");
                this.ControlAnimal = this.FindSpell("Control Animal");
                this.ControlPerson = this.FindSpell("Control Person");

                this.MentalAttack = this.FindSpell("Mental Attack");
                this.Telepathy = this.FindSpell("Telepathy");
                this.Phantasm = this.FindSpell("Phantasm");
                this.MolecularDisruption = this.FindSpell("Molecular Disruption");
                this.MolecularRearrangement = this.FindSpell("Molecular Rearrangement");
                this.ForceShield = this.FindSpell("Force Shield");
                this.MentalHealing = this.FindSpell("Healing");
                this.Invisibility = this.FindSpell("Invisibility");
                this.Telekinesis = this.FindSpell("Telekinesis");
                this.TelekineticRage = this.FindSpell("Telekinetic Rage");
            }
        }
    }

    [DataContract]
    [KnownType(typeof(SpellCollege))]
    [KnownType(typeof(Spell))]
    [KnownType(typeof(Talent))]
    public class SpellColleges
    {
        private IList<SpellCollege> _colleges;

        [DataMember]
        public IList<SpellCollege> Colleges
        {
            get { return this._colleges ?? (this._colleges = new List<SpellCollege>()); }
        }

        public SpellCollege FindCollege(string name)
        {
            return this._colleges.Single(s => s.Name == name);
        }
    }

    [DataContract]
    public class SpellCollege
    {
        private List<Spell> _spells;
        private List<Talent> _talents;

        protected SpellCollege(SpellCollege collegeToCopy)
        {
            this._talents = new List<Talent>(collegeToCopy.Talents);
            this._spells = new List<Spell>(collegeToCopy.Spells);
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public IList<Spell> Spells
        {
            get { return this._spells ?? (this._spells = new List<Spell>()); }
        }

        [DataMember]
        public IList<Talent> Talents
        {
            get { return this._talents ?? (this._talents = new List<Talent>()); }
        }

        public Spell FindSpell(string fullName)
        {
            return this._spells.Single(s => s.FullName == fullName);
        }

        public Talent FindTalent(string fullName)
        {
            return this._talents.Single(s => s.FullName == fullName);
        }
    }
}