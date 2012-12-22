using System;
using System.Collections.Generic;

namespace DragonAidLib.Data.Model
{
    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class Character : GroupableDataBase
    {
        public Character(String title, String subtitle, String imagePath, String description, String content, Party group)
            : base(Guid.NewGuid().ToString(), title, subtitle, imagePath, description)
        {
            _content = content;
            _group = group;
            Race = Race.Human;
            _combatActions = new List<CombatAction>();
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private int _physicalStrength;
        public int PhysicalStrength
        {
            get { return _physicalStrength; }
            set { SetProperty(ref _physicalStrength, value); }
        }

        private int _manualDexterity;
        public int ManualDexterity
        {
            get { return _manualDexterity; }
            set { SetProperty(ref _manualDexterity, value); }
        }

        public int Agility { get; set; }
        public int Endurance { get; set; }
        public int MagicalAptitude { get; set; }
        public int Willpower { get; set; }
        public int Perception { get; set; }
        public int PhysicalBeauty { get; set; }
        public int Fatigue { get; set; }
        public Race Race { get; set; }
        public int TacticalMovementRate { get { return CharacterEquations.ComputeBasicTacticalMovementRate(Agility, Race); } }

        private Party _group;
        public Party Group
        {
            get { return _group; }
            set { SetProperty(ref _group, value); }
        }

        private List<CombatAction> _combatActions;
        public List<CombatAction> CombatActions
        {
            get { return _combatActions; }
        }


    }
}