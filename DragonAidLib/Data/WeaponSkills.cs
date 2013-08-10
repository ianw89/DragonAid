using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data.Model;
using System.Reflection;

namespace DragonAid.Lib.Data
{
    public class WeaponSkills
    {
        private readonly List<WeaponSkill> _weapons;

        public WeaponSkills()
        {
            this._weapons = new List<WeaponSkill>();
            
            foreach (var field in typeof(WeaponSkills).GetRuntimeFields().Where(f => f.IsStatic && f.FieldType == typeof(WeaponSkill)))
            {
                var value = field.GetValue(typeof (WeaponSkills));
                this._weapons.Add((WeaponSkill)value);
            }
        }

        public List<WeaponSkill> WeaponList { get { return _weapons; } } 

        // Name, Weight, BaseChance, Use, MaxRank
        public static readonly WeaponSkill Dagger = new WeaponSkill("Dagger", 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 9, 7, 10);
        public static readonly WeaponSkill MainGauche = new WeaponSkill("Main-Gauche", 45, WeaponKind.Close & WeaponKind.Melee, 10, 8, 15);
        public static readonly WeaponSkill ShortSword = new WeaponSkill("Short Sword", 45, WeaponKind.Melee, 6, 10, 12);
        public static readonly WeaponSkill Falchion = new WeaponSkill("Falchion", 50, WeaponKind.Melee, 8, 12, 11);
        public static readonly WeaponSkill Scimitar = new WeaponSkill("Scimitar", 50, WeaponKind.Melee, 8, 11, 15);
        public static readonly WeaponSkill Tulwar = new WeaponSkill("Tulwar", 50, WeaponKind.Melee, 8, 13, 15);
        public static readonly WeaponSkill Rapier = new WeaponSkill("Rapier", 45, WeaponKind.Melee, 10, 11, 18);
        public static readonly WeaponSkill Sabre = new WeaponSkill("Sabre", 60, WeaponKind.Melee, 7, 14, 15);
        public static readonly WeaponSkill Broadsword = new WeaponSkill("Broadsword", 55, WeaponKind.Melee, 6, 15, 15);
        public static readonly WeaponSkill Estoc = new WeaponSkill("Estoc", 45, WeaponKind.Melee, 9, 15, 17);
        public static readonly WeaponSkill HandAndAHalf = new WeaponSkill("Hand & a Half", 60, WeaponKind.Melee, 7, 17, 16);
        public static readonly WeaponSkill Claymore = new WeaponSkill("Claymore", 50, WeaponKind.Melee, 7, 16, 13);
        public static readonly WeaponSkill TwoHandedSword = new WeaponSkill("Two-Handed Sword", 55, WeaponKind.Melee, 5, 22, 14);

        public static readonly WeaponSkill HandAxe = new WeaponSkill("Hand Axe", 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 4, 8, 11);
        public static readonly WeaponSkill BattleAxe = new WeaponSkill("Battle Axe", 60, WeaponKind.Close & WeaponKind.Melee, 7, 14, 14);
        public static readonly WeaponSkill GreatAxe =  new WeaponSkill("Great Axe", 65, WeaponKind.Melee, 7, 19, 17);
        public static readonly WeaponSkill GiantAxe = new WeaponSkill("Giant Axe", 65, WeaponKind.Ranged & WeaponKind.Melee, 7, 29, 12);
        public static readonly WeaponSkill CrudeClub = new WeaponSkill("Crude Club", 45, WeaponKind.Ranged & WeaponKind.Melee, 2, 16, 10);
        public static readonly WeaponSkill WarClub = new WeaponSkill("War Club", 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 14, 10);
        public static readonly WeaponSkill GiantClub = new WeaponSkill("Giant Club", 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 25, 9);
        // TODO: make max rank nullable
        // public static readonly WeaponSkill Torch = new WeaponSkill("Torch", 3, 40, WeaponKind.Melee, null, 8, 12);
        public static readonly WeaponSkill Mace = new WeaponSkill("Mace", 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 16, 9);
        public static readonly WeaponSkill GiantMace = new WeaponSkill("Giant Mace", 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 27, 10);
        public static readonly WeaponSkill WarHammer = new WeaponSkill("War Hammer", 45, WeaponKind.Ranged & WeaponKind.Melee, 5, 15, 13);
        public static readonly WeaponSkill WarPick = new WeaponSkill("War Pick", 45, WeaponKind.Melee, 5, 17, 13);
        public static readonly WeaponSkill Flail = new WeaponSkill("Flail", 50, WeaponKind.Melee, 5, 14, 15);
        public static readonly WeaponSkill Morningstar = new WeaponSkill("Morningstar", 60, WeaponKind.Melee, 5, 18, 15);
        public static readonly WeaponSkill Mattock = new WeaponSkill("Mattock", 55, WeaponKind.Melee, 5, 19, 14);
        public static readonly WeaponSkill Quarterstaff = new WeaponSkill("Quarterstaff", 55, WeaponKind.Melee, 9, 12, 16);
        public static readonly WeaponSkill Sap = new WeaponSkill("Sap", 40, WeaponKind.Close & WeaponKind.Melee, 3, 9, 11);

        public static readonly WeaponSkill ThrowingDart = new WeaponSkill("Throwing Dart", 40, WeaponKind.Ranged, 10, 9, 15);
        public static readonly WeaponSkill Boomerang = new WeaponSkill("Boomerang", 40, WeaponKind.Ranged, 7, 11, 15);
        public static readonly WeaponSkill Grenado = new WeaponSkill("Grenado", 40, WeaponKind.Ranged, 4, 9, 15);
        public static readonly WeaponSkill Shuriken = new WeaponSkill("Shuriken", 35, WeaponKind.Ranged, 10, 9, 17);

        public static readonly WeaponSkill Javelin = new WeaponSkill("Javelin", 45, WeaponKind.Ranged & WeaponKind.Melee, 10, 12, 15);
        public static readonly WeaponSkill Spear = new WeaponSkill("Spear", 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 15, 14);
        public static readonly WeaponSkill GiantSpear = new WeaponSkill("Giant Spear", 55, WeaponKind.Ranged & WeaponKind.Melee, 5, 22, 16);
        public static readonly WeaponSkill Pike = new WeaponSkill("Pike", 45, WeaponKind.Melee, 5, 18, 16);
        public static readonly WeaponSkill Lance = new WeaponSkill("Lance", 45, WeaponKind.Melee, 5, 16, 18);
        public static readonly WeaponSkill Halberd = new WeaponSkill("Halbeard", 55, WeaponKind.Melee, 5, 16, 16);
        public static readonly WeaponSkill Poleaxe = new WeaponSkill("Poleaxe", 55, WeaponKind.Melee, 5, 18, 15);
        public static readonly WeaponSkill Trident = new WeaponSkill("Trident", 45, WeaponKind.Melee, 5, 14, 16);
        public static readonly WeaponSkill Glaive = new WeaponSkill("Glaive", 55, WeaponKind.Melee, 9, 16, 18);
        public static readonly WeaponSkill GiantGlaive = new WeaponSkill("Giant Glaive", 65, WeaponKind.Melee, 9, 22, 18);

        public static readonly WeaponSkill Sling = new WeaponSkill("Sling", 40, WeaponKind.Ranged, 8, 7, 15);
        public static readonly WeaponSkill ShortBow = new WeaponSkill("Short Bow", 45, WeaponKind.Ranged, 8, 14, 15);
        public static readonly WeaponSkill LongBow = new WeaponSkill("Long Bow", 55, WeaponKind.Ranged, 8, 16, 15);
        public static readonly WeaponSkill CompositeBow = new WeaponSkill("Composite Bow", 55, WeaponKind.Ranged, 8, 17, 15);
        public static readonly WeaponSkill GiantBow = new WeaponSkill("Giant Bow", 55, WeaponKind.Ranged, 8, 25, 17);
        public static readonly WeaponSkill Crossbow = new WeaponSkill("Crossbow", 60, WeaponKind.Ranged, 5, 18, 14);
        public static readonly WeaponSkill HeavyCrossbow = new WeaponSkill("Heavy Crossbow", 60, WeaponKind.Ranged, 5, 20, 14);
        public static readonly WeaponSkill SpearThrower = new WeaponSkill("Spear Thrower", 50, WeaponKind.Ranged, 10, 11, 14);
        public static readonly WeaponSkill Blowgun = new WeaponSkill("Blowgun", 30, WeaponKind.Ranged, 10, 7, 16);

        public static readonly WeaponSkill Net = new WeaponSkill("Net", 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 4, 11, 16);
        public static readonly WeaponSkill Bola = new WeaponSkill("Bola", 35, WeaponKind.Ranged & WeaponKind.Close, 6, 11, 15);
        public static readonly WeaponSkill Whip = new WeaponSkill("Whip", 40, WeaponKind.Melee & WeaponKind.Close, 10, 10, 16);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly WeaponSkill Rock = new WeaponSkill("Rock", null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6, 5, 10);
        public static readonly WeaponSkill Cestus = new WeaponSkill("Cestus", 35, WeaponKind.Melee & WeaponKind.Close, 9, 12, 14);
        public static readonly WeaponSkill Garrote = new WeaponSkill("Garrote", 30, WeaponKind.Close, 3, 12, 15);
        // public static readonly WeaponSkill Shield = new WeaponSkill("Shield", null, 40, WeaponKind.Melee, 4, 10, 12);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly WeaponSkill Cane = new WeaponSkill("Cane (Sap)", 40, WeaponKind.Close & WeaponKind.Melee, 3, 10, 12);
    }
}