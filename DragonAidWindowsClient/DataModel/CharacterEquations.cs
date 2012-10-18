namespace DragonAidWindowsClient.Data
{
    public static class CharacterEquations
    {
        public static int ComputeBasicTacticalMovementRate(int agility)
        {
            if (agility > 25)
                return 8;
            if (agility > 21)
                return 7;
            if (agility > 17)
                return 6;
            if (agility > 12)
                return 5;
            if (agility > 8)
                return 4;
            if (agility > 4)
                return 3;
            return 2;
        }
    }
}