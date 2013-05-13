using DragonAid.Lib.Data.Model;

namespace DragonAid.Lib.Data
{
    /// <summary>
    /// Object that encapsulates the result of a particular roll.
    /// </summary>
    internal class RollResult
    {
        public bool Success
        {
            get { return this.Roll < this.RequiredRoll; }
        }

        public int Roll { get; set; }

        public int RequiredRoll { get; set; }

        public Character Person { get; set; }

        public override string ToString()
        {
            return this.Person + " rolled a " + this.Roll + " and need a " + this.RequiredRoll + " to succeed.";
        }
    }
}