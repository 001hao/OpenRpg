using System;
using System.Collections.Generic;
using OpenRpg.Core.Requirements;
using OpenRpg.Core.Templates;
using OpenRpg.Entities.Requirements;
using OpenRpg.Items.TradeSkills.Variables;

namespace OpenRpg.Items.TradeSkills.Templates
{
    public class ItemCraftingTemplate : ITemplate<ItemCraftingTemplateVariables>, ITradeSkillData, IHasRequirements
    {
        /// <summary>
        /// The Id for this template
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name locale id for the crafting
        /// </summary>
        public string NameLocaleId { get; set; }
        
        /// <summary>
        /// The description locale id
        /// </summary>
        public string DescriptionLocaleId { get; set; }
        
        /// <summary>
        /// Gathering time in seconds, per unit gathered
        /// </summary>
        public float TimeToComplete { get; set; } = 1.0f;

        /// <summary>
        /// The category of skill type used for Gathering
        /// </summary>
        public int SkillType { get; set; }
    
        /// <summary>
        /// Indicates how difficult this is to get, effects if you can use the trade skill and skill up rates
        /// </summary>
        public int SkillDifficulty { get; set; }

        /// <summary>
        /// Requirements needed before this tradeskill is allowed
        /// </summary>
        public IReadOnlyCollection<Requirement> Requirements { get; set; } = Array.Empty<Requirement>();

        /// <summary>
        /// Variables for this template
        /// </summary>
        public ItemCraftingTemplateVariables Variables { get; set; } = new ItemCraftingTemplateVariables();
        
        /// <summary>
        /// The items required to craft this template
        /// </summary>
        public List<TradeSkillItemEntry> InputItems { get; set; } = new List<TradeSkillItemEntry>();
        
        /// <summary>
        /// The items output from this template
        /// </summary>
        public List<TradeSkillItemEntry> OutputItems { get; set; } = new List<TradeSkillItemEntry>();
    }
}