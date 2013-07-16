using System.Collections.Generic;
using System.Linq;
using DragonAid.Lib.Data.Model;
using System.Reflection;

namespace DragonAid.Lib.Data
{
    public class Weapons
    {
        private readonly List<Weapon> _weapons;

        public Weapons()
        {
            this._weapons = new List<Weapon>();
            
            foreach (var field in typeof(Weapons).GetRuntimeFields().Where(f => f.IsStatic && f.FieldType == typeof(Weapon)))
            {
                var value = field.GetValue(typeof (Weapons));
                this._weapons.Add((Weapon)value);
            }
        }

        public List<Weapon> WeaponList { get { return _weapons; } } 

        // Name, Weight, BaseChance, Use, MaxRank
        public static readonly Weapon Dagger = new Weapon("Dagger", 10m / 16m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 9, 7, 10);
        public static readonly Weapon MainGauche = new Weapon("Main-Gauche", 1m, 45, WeaponKind.Close & WeaponKind.Melee, 10, 8, 15);
        public static readonly Weapon ShortSword = new Weapon("Short Sword", 2m, 45, WeaponKind.Melee, 6, 10, 12);
        public static readonly Weapon Falchion = new Weapon("Falchion", 4m, 50, WeaponKind.Melee, 8, 12, 11);
        public static readonly Weapon Scimitar = new Weapon("Scimitar", 4m, 50, WeaponKind.Melee, 8, 11, 15);
        public static readonly Weapon Tulwar = new Weapon("Tulwar", 4m, 50, WeaponKind.Melee, 8, 13, 15);
        public static readonly Weapon Rapier = new Weapon("Rapier", 2m, 45, WeaponKind.Melee, 10, 11, 18);
        public static readonly Weapon Sabre = new Weapon("Sabre", 3m, 60, WeaponKind.Melee, 7, 14, 15);
        public static readonly Weapon Broadsword = new Weapon("Broadsword", 3m, 55, WeaponKind.Melee, 6, 15, 15);
        public static readonly Weapon Estoc = new Weapon("Estoc", 2m, 45, WeaponKind.Melee, 9, 15, 17);
        public static readonly Weapon HandAndAHalf = new Weapon("Hand & a Half", 6m, 60, WeaponKind.Melee, 7, 17, 16);
        public static readonly Weapon Claymore = new Weapon("Claymore", 5m, 50, WeaponKind.Melee, 7, 16, 13);
        public static readonly Weapon TwoHandedSword = new Weapon("Two-Handed Sword", 9m, 55, WeaponKind.Melee, 5, 22, 14);

        public static readonly Weapon HandAxe = new Weapon("Hand Axe", 2m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 4, 8, 11);
        public static readonly Weapon BattleAxe = new Weapon("Battle Axe", 5m, 60, WeaponKind.Close & WeaponKind.Melee, 7, 14, 14);
        public static readonly Weapon GreatAxe =  new Weapon("Great Axe", 6, 65, WeaponKind.Melee, 7, 19, 17);
        public static readonly Weapon GiantAxe = new Weapon("Giant Axe", 25, 65, WeaponKind.Ranged & WeaponKind.Melee, 7, 29, 12);
        public static readonly Weapon CrudeClub = new Weapon("Crude Club", 4, 45, WeaponKind.Ranged & WeaponKind.Melee, 2, 16, 10);
        public static readonly Weapon WarClub = new Weapon("War Club", 3, 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 14, 10);
        public static readonly Weapon GiantClub = new Weapon("Giant Club", 20, 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 25, 9);
        // TODO: make max rank nullable
        // public static readonly Weapon Torch = new Weapon("Torch", 3, 40, WeaponKind.Melee, null, 8, 12);
        public static readonly Weapon Mace = new Weapon("Mace", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 16, 9);
        public static readonly Weapon GiantMace = new Weapon("Giant Mace", 25, 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 27, 10);
        public static readonly Weapon WarHammer = new Weapon("War Hammer", 4m, 45, WeaponKind.Ranged & WeaponKind.Melee, 5, 15, 13);
        public static readonly Weapon WarPick = new Weapon("War Pick", 5, 45, WeaponKind.Melee, 5, 17, 13);
        public static readonly Weapon Flail = new Weapon("Flail", 4, 50, WeaponKind.Melee, 5, 14, 15);
        public static readonly Weapon Morningstar = new Weapon("Morningstar", 5m, 60, WeaponKind.Melee, 5, 18, 15);
        public static readonly Weapon Mattock = new Weapon("Mattock", 6m, 55, WeaponKind.Melee, 5, 19, 14);
        public static readonly Weapon Quarterstaff = new Weapon("Quarterstaff", 3, 55, WeaponKind.Melee, 9, 12, 16);
        public static readonly Weapon Sap = new Weapon("Sap", 1m, 40, WeaponKind.Close & WeaponKind.Melee, 3, 9, 11);

        public static readonly Weapon ThrowingDart = new Weapon("Throwing Dart", 3m / 16m, 40, WeaponKind.Ranged, 10, 9, 15);
        public static readonly Weapon Boomerang = new Weapon("Boomerang", 1, 40, WeaponKind.Ranged, 7, 11, 15);
        public static readonly Weapon Grenado = new Weapon("Grenado", 2, 40, WeaponKind.Ranged, 4, 9, 15);
        public static readonly Weapon Shuriken = new Weapon("Shuriken", 4m / 16m, 35, WeaponKind.Ranged, 10, 9, 17);

        public static readonly Weapon Javelin = new Weapon("Javelin", 3, 45, WeaponKind.Ranged & WeaponKind.Melee, 10, 12, 15);
        public static readonly Weapon Spear = new Weapon("Spear", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5, 15, 14);
        public static readonly Weapon GiantSpear = new Weapon("Giant Spear", 15, 55, WeaponKind.Ranged & WeaponKind.Melee, 5, 22, 16);
        public static readonly Weapon Pike = new Weapon("Pike", 8, 45, WeaponKind.Melee, 5, 18, 16);
        public static readonly Weapon Lance = new Weapon("Lance", 7, 45, WeaponKind.Melee, 5, 16, 18);
        public static readonly Weapon Halberd = new Weapon("Halbeard", 6, 55, WeaponKind.Melee, 5, 16, 16);
        public static readonly Weapon Poleaxe = new Weapon("Poleaxe", 6, 55, WeaponKind.Melee, 5, 18, 15);
        public static readonly Weapon Trident = new Weapon("Trident", 5, 45, WeaponKind.Melee, 5, 14, 16);
        public static readonly Weapon Glaive = new Weapon("Glaive", 7, 55, WeaponKind.Melee, 9, 16, 18);
        public static readonly Weapon GiantGlaive = new Weapon("Giant Glaive", 14, 65, WeaponKind.Melee, 9, 22, 18);

        public static readonly Weapon Sling = new Weapon("Sling", 1, 40, WeaponKind.Ranged, 8, 7, 15);
        public static readonly Weapon ShortBow = new Weapon("Short Bow", 4, 45, WeaponKind.Ranged, 8, 14, 15);
        public static readonly Weapon LongBow = new Weapon("Long Bow", 6, 55, WeaponKind.Ranged, 8, 16, 15);
        public static readonly Weapon CompositeBow = new Weapon("Composite Bow", 8, 55, WeaponKind.Ranged, 8, 17, 15);
        public static readonly Weapon GiantBow = new Weapon("Giant Bow", 14, 55, WeaponKind.Ranged, 8, 25, 17);
        public static readonly Weapon Crossbow = new Weapon("Crossbow", 7m, 60, WeaponKind.Ranged, 5, 18, 14);
        public static readonly Weapon HeavyCrossbow = new Weapon("Heavy Crossbow", 10, 60, WeaponKind.Ranged, 5, 20, 14);
        public static readonly Weapon SpearThrower = new Weapon("Spear Thrower", 4, 50, WeaponKind.Ranged, 10, 11, 14);
        public static readonly Weapon Blowgun = new Weapon("Blowgun", 1, 30, WeaponKind.Ranged, 10, 7, 16);

        public static readonly Weapon Net = new Weapon("Net", 2, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 4, 11, 16);
        public static readonly Weapon Bola = new Weapon("Bola", 2, 35, WeaponKind.Ranged & WeaponKind.Close, 6, 11, 15);
        public static readonly Weapon Whip = new Weapon("Whip", 3, 40, WeaponKind.Melee & WeaponKind.Close, 10, 10, 16);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly Weapon Rock = new Weapon("Rock", null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6, 5, 10);
        public static readonly Weapon Cestus = new Weapon("Cestus", 3, 35, WeaponKind.Melee & WeaponKind.Close, 9, 12, 14);
        public static readonly Weapon Garrote = new Weapon("Garrote", 1, 30, WeaponKind.Close, 3, 12, 15);
        // public static readonly Weapon Shield = new Weapon("Shield", null, 40, WeaponKind.Melee, 4, 10, 12);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly Weapon Cane = new Weapon("Cane (Sap)", 5, 40, WeaponKind.Close & WeaponKind.Melee, 3, 10, 12);
    }
}