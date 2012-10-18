using System;
using System.Collections.Generic;

namespace DragonAidWindowsClient.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class Character : SampleDataCommon
    {
        public Character(String uniqueId, String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private int _physicalStrength;
        public int PhysicalStrength
        {
            get { return this._physicalStrength; }
            set { this.SetProperty(ref this._physicalStrength, value); }
        }

        private int _manualDexterity;
        public int ManualDexterity
        {
            get { return this._manualDexterity; }
            set { this.SetProperty(ref this._manualDexterity, value); }
        }

        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int MagicalAptitude { get; set; }
        public int Willpower { get; set; }
        public int Perception { get; set; }
        public int PhysicalBeauty { get; set; }
        public int Fatigue { get; set; }
        public int TacticalMovementRate { get { return CharacterEquations.ComputeBasicTacticalMovementRate(this.Agility); } }

        private SampleDataGroup _group;
        public SampleDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }
    }
}