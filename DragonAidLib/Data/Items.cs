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
        public static readonly Weapon Dagger = new Weapon(WeaponSkills.Dagger, 10m / 16m);
        public static readonly Weapon MainGauche = new Weapon(WeaponSkills.MainGauche, 1m);
        public static readonly Weapon ShortSword = new Weapon(WeaponSkills.ShortSword, 2m);
        public static readonly Weapon Falchion = new Weapon(WeaponSkills.Falchion, 4m);
        public static readonly Weapon Scimitar = new Weapon(WeaponSkills.Scimitar, 4m);
        public static readonly Weapon Tulwar = new Weapon(WeaponSkills.Tulwar, 4m);
        public static readonly Weapon Rapier = new Weapon(WeaponSkills.Rapier, 2m);
        public static readonly Weapon Sabre = new Weapon(WeaponSkills.Sabre, 3m);
        public static readonly Weapon Broadsword = new Weapon(WeaponSkills.Broadsword, 3m);
        public static readonly Weapon Estoc = new Weapon(WeaponSkills.Estoc, 2m);
        public static readonly Weapon HandAndAHalf = new Weapon(WeaponSkills.HandAndAHalf, 6m);
        public static readonly Weapon Claymore = new Weapon(WeaponSkills.Claymore, 5m);
        public static readonly Weapon TwoHandedSword = new Weapon(WeaponSkills.TwoHandedSword, 9m);

        public static readonly Weapon HandAxe = new Weapon(WeaponSkills.HandAxe, 2m);
        public static readonly Weapon BattleAxe = new Weapon(WeaponSkills.BattleAxe, 5m);
        public static readonly Weapon GreatAxe = new Weapon(WeaponSkills.GreatAxe, 6);
        public static readonly Weapon GiantAxe = new Weapon(WeaponSkills.GiantAxe, 25);
        public static readonly Weapon CrudeClub = new Weapon(WeaponSkills.CrudeClub, 4);
        public static readonly Weapon WarClub = new Weapon(WeaponSkills.WarClub, 3);
        public static readonly Weapon GiantClub = new Weapon(WeaponSkills.GiantClub, 20);
        // TODO: make max rank nullable
        // public static readonly Weapon Torch = new Weapon(Weapons.Torch, 3, 40, WeaponKind.Melee, null, 8, 12);
        public static readonly Weapon Mace = new Weapon(WeaponSkills.Mace, 5);
        public static readonly Weapon GiantMace = new Weapon(WeaponSkills.GiantMace, 25);
        public static readonly Weapon WarHammer = new Weapon(WeaponSkills.WarHammer, 4m);
        public static readonly Weapon WarPick = new Weapon(WeaponSkills.WarPick, 5);
        public static readonly Weapon Flail = new Weapon(WeaponSkills.Flail, 4);
        public static readonly Weapon Morningstar = new Weapon(WeaponSkills.Morningstar, 5m);
        public static readonly Weapon Mattock = new Weapon(WeaponSkills.Mattock, 6m);
        public static readonly Weapon Quarterstaff = new Weapon(WeaponSkills.Quarterstaff, 3);
        public static readonly Weapon Sap = new Weapon(WeaponSkills.Sap, 1m);

        public static readonly Weapon ThrowingDart = new Weapon(WeaponSkills.ThrowingDart, 3m / 16m);
        public static readonly Weapon Boomerang = new Weapon(WeaponSkills.Boomerang, 1);
        public static readonly Weapon Grenado = new Weapon(WeaponSkills.Grenado, 2);
        public static readonly Weapon Shuriken = new Weapon(WeaponSkills.Shuriken, 4m / 16m);

        public static readonly Weapon Javelin = new Weapon(WeaponSkills.Javelin, 3);
        public static readonly Weapon Spear = new Weapon(WeaponSkills.Spear, 5);
        public static readonly Weapon GiantSpear = new Weapon(WeaponSkills.GiantSpear, 15);
        public static readonly Weapon Pike = new Weapon(WeaponSkills.Pike, 8);
        public static readonly Weapon Lance = new Weapon(WeaponSkills.Lance, 7);
        public static readonly Weapon Halberd = new Weapon(WeaponSkills.Halberd, 6);
        public static readonly Weapon Poleaxe = new Weapon(WeaponSkills.Poleaxe, 6);
        public static readonly Weapon Trident = new Weapon(WeaponSkills.Trident, 5);
        public static readonly Weapon Glaive = new Weapon(WeaponSkills.Glaive, 7);
        public static readonly Weapon GiantGlaive = new Weapon(WeaponSkills.GiantGlaive, 14);

        public static readonly Weapon Sling = new Weapon(WeaponSkills.Sling, 1);
        public static readonly Weapon ShortBow = new Weapon(WeaponSkills.ShortBow, 4);
        public static readonly Weapon LongBow = new Weapon(WeaponSkills.LongBow, 6);
        public static readonly Weapon CompositeBow = new Weapon(WeaponSkills.CompositeBow, 8);
        public static readonly Weapon GiantBow = new Weapon(WeaponSkills.GiantBow, 14);
        public static readonly Weapon Crossbow = new Weapon(WeaponSkills.Crossbow, 7m);
        public static readonly Weapon HeavyCrossbow = new Weapon(WeaponSkills.HeavyCrossbow, 10);
        public static readonly Weapon SpearThrower = new Weapon(WeaponSkills.SpearThrower, 4);
        public static readonly Weapon Blowgun = new Weapon(WeaponSkills.Blowgun, 1);

        public static readonly Weapon Net = new Weapon(WeaponSkills.Net, 2);
        public static readonly Weapon Bola = new Weapon(WeaponSkills.Bola, 2);
        public static readonly Weapon Whip = new Weapon(WeaponSkills.Whip, 3);

        // TODO: Make weight nullable (to signify variable weight)
        // public static readonly Weapon Rock = new Weapon(Weapons.Rock, null, 30, WeaponKind.Ranged & WeaponKind.Melee & WeaponKind.Close, 6, 5, 10);
        public static readonly Weapon Cestus = new Weapon(WeaponSkills.Cestus, 3);
        public static readonly Weapon Garrote = new Weapon(WeaponSkills.Garrote, 1);
        // public static readonly Weapon Shield = new Weapon(Weapons.Shield, null, 40, WeaponKind.Melee, 4, 10, 12);

        // Custom weapons (TODO: can we have a more general way of building on top of the standard weapons?)
        public static readonly Weapon Cane = new Weapon(WeaponSkills.Cane, 5);

        public static readonly Item Darts = new Item("Darts (20)", 2);
    }
}