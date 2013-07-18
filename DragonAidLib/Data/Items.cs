using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    /// <summary>
    /// Physical Items. It's fine to just new up an Item, but common items are put here.
    /// 
    /// TODO Lots more to add; only common weapons are here.
    /// 
    /// TODO Weapons should probably be constructred from a factory instead. 
    ///      This way, creating variations (silvered, Extra BC, etc) is easy and uses a common pattern.
    /// </summary>
    public static class Items
    {
        public static readonly Weapon Dagger = new Weapon(Weapons.Dagger, 10m / 16m);
        public static readonly Weapon MainGauche = new Weapon(Weapons.MainGauche, 1m);
        public static readonly Weapon ShortSword = new Weapon(Weapons.ShortSword, 2m);
        public static readonly Weapon Falchion = new Weapon(Weapons.Falchion, 4m);
        public static readonly Weapon Scimitar = new Weapon(Weapons.Scimitar, 4m);
        public static readonly Weapon Tulwar = new Weapon(Weapons.Tulwar, 4m);
        public static readonly Weapon Rapier = new Weapon(Weapons.Rapier, 2m);
        public static readonly Weapon Sabre = new Weapon(Weapons.Sabre, 3m);
        public static readonly Weapon Broadsword = new Weapon(Weapons.Broadsword, 3m);
        public static readonly Weapon Estoc = new Weapon(Weapons.Estoc, 2m);
        public static readonly Weapon HandAndAHalf = new Weapon(Weapons.HandAndAHalf, 6m);
        public static readonly Weapon Claymore = new Weapon(Weapons.Claymore, 5m);
        public static readonly Weapon TwoHandedSword = new Weapon(Weapons.TwoHandedSword, 9m);

        public static readonly Weapon HandAxe = new Weapon(Weapons.HandAxe, 2m);
        public static readonly Weapon BattleAxe = new Weapon(Weapons.BattleAxe, 5m);
        public static readonly Weapon GreatAxe = new Weapon(Weapons.GreatAxe, 6);
        public static readonly Weapon GiantAxe = new Weapon(Weapons.GiantAxe, 25);
        public static readonly Weapon CrudeClub = new Weapon(Weapons.CrudeClub, 4);
        public static readonly Weapon WarClub = new Weapon(Weapons.WarClub, 3);
        public static readonly Weapon GiantClub = new Weapon(Weapons.GiantClub, 20);
        // TODO: make max rank nullable
        // public static readonly Weapon Torch = new Weapon(Weapons.Torch, 3, 40, WeaponKind.Melee, null, 8, 12);
        public static readonly Weapon Mace = new Weapon(Weapons.Mace, 5);
        public static readonly Weapon GiantMace = new Weapon(Weapons.GiantMace, 25);
        public static readonly Weapon WarHammer = new Weapon(Weapons.WarHammer, 4m);
        public static readonly Weapon WarPick = new Weapon(Weapons.WarPick, 5);
        public static readonly Weapon Flail = new Weapon(Weapons.Flail, 4);
        public static readonly Weapon Morningstar = new Weapon(Weapons.Morningstar, 5m);
        public static readonly Weapon Mattock = new Weapon(Weapons.Mattock, 6m);
        public static readonly Weapon Quarterstaff = new Weapon(Weapons.Quarterstaff, 3);
        public static readonly Weapon Sap = new Weapon(Weapons.Sap, 1m);

        public static readonly Weapon ThrowingDart = new Weapon(Weapons.ThrowingDart, 3m / 16m);
        public static readonly Weapon Boomerang = new Weapon(Weapons.Boomerang, 1);
        public static readonly Weapon Grenado = new Weapon(Weapons.Grenado, 2);
        public static readonly Weapon Shuriken = new Weapon(Weapons.Shuriken, 4m / 16m);

        public static readonly Weapon Javelin = new Weapon(Weapons.Javelin, 3);
        public static readonly Weapon Spear = new Weapon(Weapons.Spear, 5);
        public static readonly Weapon GiantSpear = new Weapon(Weapons.GiantSpear, 15);
        public static readonly Weapon Pike = new Weapon(Weapons.Pike, 8);
        public static readonly Weapon Lance = new Weapon(Weapons.Lance, 7);
        public static readonly Weapon Halberd = new Weapon(Weapons.Halberd, 6);
        public static readonly Weapon Poleaxe = new Weapon(Weapons.Poleaxe, 6);
        public static readonly Weapon Trident = new Weapon(Weapons.Trident, 5);
        public static readonly Weapon Glaive = new Weapon(Weapons.Glaive, 7);
        public static readonly Weapon GiantGlaive = new Weapon(Weapons.GiantGlaive, 14);

        public static readonly Weapon Sling = new Weapon(Weapons.Sling, 1);
        public static readonly Weapon ShortBow = new Weapon(Weapons.ShortBow, 4);
        public static readonly Weapon LongBow = new Weapon(Weapons.LongBow, 6);
        public static readonly Weapon CompositeBow = new Weapon(Weapons.CompositeBow, 8);
        public static readonly Weapon GiantBow = new Weapon(Weapons.GiantBow, 14);
        public static readonly Weapon Crossbow = new Weapon(Weapons.Crossbow, 7m);
        public static readonly Weapon HeavyCrossbow = new Weapon(Weapons.HeavyCrossbow, 10);
        public static readonly Weapon SpearThrower = new Weapon(Weapons.SpearThrower, 4);
        public static readonly Weapon Blowgun = new Weapon(Weapons.Blowgun, 1);

        public static readonly Weapon Net = new Weapon(Weapons.Net, 2);
        public static readonly Weapon Bola = new Weapon(Weapons.Bola, 2);
        public static readonly Weapon Whip = new Weapon(Weapons.Whip, 3);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly Weapon Rock = new Weapon(Weapons.Rock, null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6, 5, 10);
        public static readonly Weapon Cestus = new Weapon(Weapons.Cestus, 3);
        public static readonly Weapon Garrote = new Weapon(Weapons.Garrote, 1);
        // public static readonly Weapon Shield = new Weapon(Weapons.Shield, null, 40, WeaponKind.Melee, 4, 10, 12);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly Weapon Cane = new Weapon(Weapons.Cane, 5);

        public static readonly Item Darts = new Item("Darts (20)", 2);
    }
}