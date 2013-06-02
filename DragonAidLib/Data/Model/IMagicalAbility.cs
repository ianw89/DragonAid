namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Inteface for an ability a character has. 
    /// TODO We will want just IAbility some day.
    /// </summary>
    public interface IMagicalAbility
    {
        /// <summary>
        /// Gets the name of the ability.
        /// </summary>
        string FullName { get; }
    }
}