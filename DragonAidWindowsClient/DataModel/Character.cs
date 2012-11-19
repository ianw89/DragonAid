using System;
using System.Collections.Generic;
using DragonAidWindowsClient.DataModel;

namespace DragonAidWindowsClient.Data
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class Character : SampleDataCommon
    {
        public Character(String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(Guid.NewGuid().ToString(), title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
            this.Race = Race.Human;
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
        public Race Race { get; set; }
        public int TacticalMovementRate { get { return CharacterEquations.ComputeBasicTacticalMovementRate(this.Agility, this.Race); } }

        private SampleDataGroup _group;
        public SampleDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }

    }
}