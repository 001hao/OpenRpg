using System.Collections.Generic;
using System.Linq;
using OpenRpg.Combat.Attacks;
using OpenRpg.Combat.Processors.Attacks;
using OpenRpg.Genres.Scifi.Extensions;
using OpenRpg.Genres.Scifi.Variables;

namespace OpenRpg.Genres.Scifi.Combat
{
    public class ShipAttackProcessor : IAttackProcessor<ShipStatsVariables>
    {
        public ProcessedAttack ProcessAttack(Attack attack, ShipStatsVariables stats)
        {
            var applicableDefenses = stats.GetDefenseReferences().Where(x => x.StatValue != 0);
            var damageLookups = attack.Damages.ToDictionary(x => x.Type, x => x.Value);
            var resultingDefenses = new List<Damage>();
            
            foreach (var applicableDefense in applicableDefenses)
            {
                if (!damageLookups.ContainsKey(applicableDefense.StatType))
                { continue; }

                float defendedAmount;
                
                if(damageLookups[applicableDefense.StatType] > applicableDefense.StatValue)
                { defendedAmount = applicableDefense.StatValue; }
                else
                { defendedAmount = applicableDefense.StatValue - damageLookups[applicableDefense.StatType]; }
                
                damageLookups[applicableDefense.StatType] -= defendedAmount;
                resultingDefenses.Add(new Damage(applicableDefense.StatType, defendedAmount));
            }

            var resultingDamage = damageLookups.Select(x => new Damage(x.Key, x.Value));
            return new ProcessedAttack(resultingDamage.ToList(), resultingDefenses);
        }
    }
}