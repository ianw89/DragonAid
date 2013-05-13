namespace DragonAid.Commander
{
    /// <summary>
    /// Base class for all states that the DragonAid Commander Console app could be in.
    /// </summary>
    internal abstract class State
    {
        /// <summary>
        /// Called once when this state is entered.
        /// </summary>
        public abstract void Enter();

        /// <summary>
        /// Called when input is received from the user. 
        /// </summary>
        public abstract void ProcessInput(string input);
    }
}