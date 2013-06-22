namespace DragonAid.Lib.Data
{
    /// <summary>
    /// Object that encapsulates the result of a team making a roll.
    /// </summary>
    public class TeamRollResult
    {
        private readonly RollResult _result;

        public TeamRollResult(RollResult result)
        {
            this._result = result;
        }

        public override string ToString()
        {
            if (this._result != null && this._result.Success)
            {
                return "Success! " +
                       this._result.Character.Name +
                       " rolled a " +
                       this._result.Roll +
                       ".";
            }

            return "The team failed the roll.";
        }
    }
}