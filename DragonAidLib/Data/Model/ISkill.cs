using System.Collections.Generic;

namespace DragonAid.Lib.Data.Model
{
    /// <summary>
    /// Interface for a skill. Skills can optionally have subskills, so they are arbitrarily hierarchical.
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// Gets the name of the ability.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// List of subabilities this ability has.
        /// </summary>
        IList<ISkill> Subskills { get; }

        /// <summary>
        /// Description of the ability.
        /// </summary>
        string Description { get; }
    }
}