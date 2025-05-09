using System.Collections.Generic;
using OpenRpg.Core.Variables;
using OpenRpg.Entities.Effects.Processors;

namespace OpenRpg.Entities.State.Populators.Variables
{
    /// <summary>
    /// A variable populators job is to take into account all related variables and effects then process that data
    /// into variables which provide high level data.
    /// </summary>
    /// <typeparam name="T">Type of variables to populate</typeparam>
    /// <remarks>
    /// Not all variables will need populators, only the ones which need to have their values derived from external data
    /// </remarks>
    public interface IVariablePopulator<in T> where T : IVariables
    {
        void Populate(T varsToPopulate, ComputedEffects computedEffects, IReadOnlyCollection<IVariables> relatedVars);
    }
}