using System.Linq;
using OpenRpg.Combat.Effects;
using OpenRpg.Core.Effects;
using OpenRpg.Entities.Effects;
using OpenRpg.Genres.Fantasy.Effects;
using OpenRpg.Genres.Fantasy.Types;

namespace OpenRpg.Genres.Fantasy.Extensions
{
    public static class EffectExtensions
    {
        public static int GetDamageTypeFrom(int effectType)
        {
            if (effectType == FantasyEffectTypes.PiercingBonusAmount) { return FantasyDamageTypes.PiercingDamage; }
            if (effectType == FantasyEffectTypes.SlashingBonusAmount) { return FantasyDamageTypes.SlashingDamage; }
            if (effectType == FantasyEffectTypes.BluntBonusAmount) { return FantasyDamageTypes.BluntDamage; }
            if (effectType == FantasyEffectTypes.UnarmedBonusAmount) { return FantasyDamageTypes.UnarmedDamage; }
            if (effectType == FantasyEffectTypes.FireBonusAmount) { return FantasyDamageTypes.FireDamage; }
            if (effectType == FantasyEffectTypes.IceBonusAmount) { return FantasyDamageTypes.IceDamage; }
            if (effectType == FantasyEffectTypes.WindBonusAmount) { return FantasyDamageTypes.WindDamage; }
            if (effectType == FantasyEffectTypes.EarthBonusAmount) { return FantasyDamageTypes.EarthDamage; }
            if (effectType == FantasyEffectTypes.LightBonusAmount) { return FantasyDamageTypes.LightDamage; }
            if (effectType == FantasyEffectTypes.DarkBonusAmount) { return FantasyDamageTypes.DarkDamage; }
            if (effectType == FantasyEffectTypes.DamageBonusAmount) { return FantasyDamageTypes.Damage; }
            return FantasyDamageTypes.UnknownDamage;
        }
        
        public static int GetApplicableDamageType(this StaticEffect staticEffect)
        { return GetDamageTypeFrom(staticEffect.EffectType); }
        
        public static int GetBonusDamageEffectTypeFrom(int damageType)
        {
            if (damageType == FantasyDamageTypes.PiercingDamage) { return FantasyEffectTypes.PiercingDamageAmount; }
            if (damageType == FantasyDamageTypes.SlashingDamage) { return FantasyEffectTypes.SlashingDamageAmount; }
            if (damageType == FantasyDamageTypes.BluntDamage) { return FantasyEffectTypes.BluntDamageAmount; }
            if (damageType == FantasyDamageTypes.UnarmedDamage) { return FantasyEffectTypes.UnarmedDamageAmount; }
            if (damageType == FantasyDamageTypes.FireDamage) { return FantasyEffectTypes.FireDamageAmount; }
            if (damageType == FantasyDamageTypes.IceDamage) { return FantasyEffectTypes.IceDamageAmount; }
            if (damageType == FantasyDamageTypes.WindDamage) { return FantasyEffectTypes.WindDamageAmount; }
            if (damageType == FantasyDamageTypes.EarthDamage) { return FantasyEffectTypes.EarthDamageAmount; }
            if (damageType == FantasyDamageTypes.LightDamage) { return FantasyEffectTypes.LightDamageAmount; }
            if (damageType == FantasyDamageTypes.DarkDamage) { return FantasyEffectTypes.DarkDamageAmount; }
            if (damageType == FantasyDamageTypes.Damage) { return FantasyEffectTypes.DamageBonusAmount; }
            return FantasyDamageTypes.UnknownDamage;
        }
        
        public static int GetBonusDefenseEffectTypeFrom(int damageType)
        {
            if (damageType == FantasyDamageTypes.PiercingDamage) { return FantasyEffectTypes.PiercingDefenseAmount; }
            if (damageType == FantasyDamageTypes.SlashingDamage) { return FantasyEffectTypes.SlashingDefenseAmount; }
            if (damageType == FantasyDamageTypes.BluntDamage) { return FantasyEffectTypes.BluntDefenseAmount; }
            if (damageType == FantasyDamageTypes.UnarmedDamage) { return FantasyEffectTypes.UnarmedDefenseAmount; }
            if (damageType == FantasyDamageTypes.FireDamage) { return FantasyEffectTypes.FireDefenseAmount; }
            if (damageType == FantasyDamageTypes.IceDamage) { return FantasyEffectTypes.IceDefenseAmount; }
            if (damageType == FantasyDamageTypes.WindDamage) { return FantasyEffectTypes.WindDefenseAmount; }
            if (damageType == FantasyDamageTypes.EarthDamage) { return FantasyEffectTypes.EarthDefenseAmount; }
            if (damageType == FantasyDamageTypes.LightDamage) { return FantasyEffectTypes.LightDefenseAmount; }
            if (damageType == FantasyDamageTypes.DarkDamage) { return FantasyEffectTypes.DarkDefenseAmount; }
            if (damageType == FantasyDamageTypes.Damage) { return FantasyEffectTypes.DefenseBonusAmount; }
            return FantasyDamageTypes.UnknownDamage;
        }

        public static bool IsDamagingEffect(this StaticEffect staticEffect)
        {  return EffectTypeGroups.DamageEffectTypes.Contains(staticEffect.EffectType); }
        
        public static bool IsDefensiveEffect(this StaticEffect staticEffect)
        {  return EffectTypeGroups.DefenseEffectTypes.Contains(staticEffect.EffectType); }

        public static bool IsBeneficialEffect(this ActiveEffect effect)
        { return IsBeneficialEffect(effect.StaticEffect); }
        
        public static bool IsBeneficialEffect(this StaticEffect staticEffect)
        {
            if(staticEffect.EffectType != FantasyEffectTypes.LightBonusAmount)
            {
                if (staticEffect.IsDamagingEffect())
                { return false; }
            }

            return staticEffect.Potency >= 0;
        }
    }
}