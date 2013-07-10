using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data.HardCoded
{
    public static class Weapons
    {
        // Name, Weight, BaseChance, Use, MaxRank
        public static readonly Weapon Dagger = new Weapon("Dagger", 10m / 16m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 9);
        public static readonly Weapon MainGauche = new Weapon("Main-Gauche", 1m, 45, WeaponKind.Close & WeaponKind.Melee, 10);
        public static readonly Weapon ShortSword = new Weapon("Short Sword", 2m, 45, WeaponKind.Melee, 6);
        public static readonly Weapon Falchion = new Weapon("Falchion", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Scimitar = new Weapon("Scimitar", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Tulwar = new Weapon("Tulwar", 4m, 50, WeaponKind.Melee, 8);
        public static readonly Weapon Rapier = new Weapon("Rapier", 2m, 45, WeaponKind.Melee, 10);
        public static readonly Weapon Sabre = new Weapon("Sabre", 3m, 60, WeaponKind.Melee, 7);
        public static readonly Weapon Broadsword = new Weapon("Broadsword", 3m, 55, WeaponKind.Melee, 6);
        public static readonly Weapon Estoc = new Weapon("Estoc", 2m, 45, WeaponKind.Melee, 9);
        public static readonly Weapon HandAndAHalf = new Weapon("Hand & a Half", 6m, 60, WeaponKind.Melee, 7);
        public static readonly Weapon Claymore = new Weapon("Claymore", 5m, 50, WeaponKind.Melee, 7);
        public static readonly Weapon TwoHandedSword = new Weapon("Two-Handed Sword", 9m, 55, WeaponKind.Melee, 5);

        public static readonly Weapon HandAxe = new Weapon("Hand Axe", 2m, 40, WeaponKind.Close & WeaponKind.Melee & WeaponKind.Ranged, 4);
        public static readonly Weapon BattleAxe = new Weapon("Battle Axe", 5m, 60, WeaponKind.Close & WeaponKind.Melee, 7);
        public static readonly Weapon GreatAxe =  new Weapon("Great Axe", 6, 65, WeaponKind.Melee, 7);
        public static readonly Weapon GiantAxe = new Weapon("Giant Axe", 25, 65, WeaponKind.Ranged & WeaponKind.Melee, 7);
        public static readonly Weapon CrudeClub = new Weapon("Crude Club", 4, 45, WeaponKind.Ranged & WeaponKind.Melee, 2);
        public static readonly Weapon WarClub = new Weapon("War Club", 3, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantClub = new Weapon("Giant Club", 20, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        // TODO: make max rank nullable
        // public static readonly Weapon Torch = new Weapon("Torch", 3, 40, WeaponKind.Melee, null);
        public static readonly Weapon Mace = new Weapon("Mace", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantMace = new Weapon("Giant Mace", 25, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon WarHammer = new Weapon("War Hammer", 4m, 45, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon WarPick = new Weapon("War Pick", 5, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Flail = new Weapon("Flail", 4, 50, WeaponKind.Melee, 5);
        public static readonly Weapon Morningstar = new Weapon("Morningstar", 5m, 60, WeaponKind.Melee, 5);
        public static readonly Weapon Mattock = new Weapon("Mattock", 6m, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Quarterstaff = new Weapon("Quarterstaff", 3, 55, WeaponKind.Melee, 9);
        public static readonly Weapon Sap = new Weapon("Sap", 1m, 40, WeaponKind.Close & WeaponKind.Melee, 3);

        public static readonly Weapon ThrowingDart = new Weapon("Throwing Dart", 3m / 16m, 40, WeaponKind.Ranged, 10);
        public static readonly Weapon Boomerang = new Weapon("Boomerang", 1, 40, WeaponKind.Ranged, 7);
        public static readonly Weapon Grenado = new Weapon("Grenado", 2, 40, WeaponKind.Ranged, 4);

        public static readonly Weapon Javelin = new Weapon("Javelin", 3, 45, WeaponKind.Ranged & WeaponKind.Melee, 10);
        public static readonly Weapon Spear = new Weapon("Spear", 5, 50, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon GiantSpear = new Weapon("Giant Spear", 15, 55, WeaponKind.Ranged & WeaponKind.Melee, 5);
        public static readonly Weapon Pike = new Weapon("Pike", 8, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Lance = new Weapon("Lance", 7, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Halberd = new Weapon("Halbeard", 6, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Poleaxe = new Weapon("Poleaxe", 6, 55, WeaponKind.Melee, 5);
        public static readonly Weapon Trident = new Weapon("Trident", 5, 45, WeaponKind.Melee, 5);
        public static readonly Weapon Glaive = new Weapon("Glaive", 7, 55, WeaponKind.Melee, 9);
        public static readonly Weapon GiantGlaive = new Weapon("Giant Glaive", 14, 65, WeaponKind.Melee, 9);

        public static readonly Weapon Sling = new Weapon("Sling", 1, 40, WeaponKind.Ranged, 8);
        public static readonly Weapon ShortBow = new Weapon("Short Bow", 4, 45, WeaponKind.Ranged, 8);
        public static readonly Weapon LongBow = new Weapon("Long Bow", 6, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon CompositeBow = new Weapon("Composite Bow", 8, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon GiantBow = new Weapon("Giant Bow", 14, 55, WeaponKind.Ranged, 8);
        public static readonly Weapon Crossbow = new Weapon("Crossbow", 7m, 60, WeaponKind.Ranged, 5);
        public static readonly Weapon HeavyCrossbow = new Weapon("Heavy Crossbow", 10, 60, WeaponKind.Ranged, 5);
        public static readonly Weapon SpearThrower = new Weapon("Spear Thrower", 4, 50, WeaponKind.Ranged, 10);
        public static readonly Weapon Blowgun = new Weapon("Blowgun", 1, 30, WeaponKind.Ranged, 10);

        public static readonly Weapon Net = new Weapon("Net", 2, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 4);
        public static readonly Weapon Bola = new Weapon("Bola", 2, 35, WeaponKind.Ranged & WeaponKind.Close, 6);
        public static readonly Weapon Whip = new Weapon("Whip", 3, 40, WeaponKind.Melee & WeaponKind.Close, 10);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly Weapon Rock = new Weapon("Rock", null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6);
        public static readonly Weapon Cestus = new Weapon("Cestus", 3, 35, WeaponKind.Melee & WeaponKind.Close, 9);
        public static readonly Weapon Garrote = new Weapon("Garrote", 1, 30, WeaponKind.Close, 3);
        // public static readonly Weapon Shield = new Weapon("Shield", null, 40, WeaponKind.Melee, 4);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly Weapon Cane = new Weapon("Cane (Sap)", 5, 40, WeaponKind.Close & WeaponKind.Melee, 3);
        // TODO: Is this different than throwing dart? It has a different weight (the way of the weapon accesory, not the weapon)
        public static readonly Weapon Darts = new Weapon("Darts (10)", 2, 40, WeaponKind.Ranged, 10);
    }
}