using Fire_Emblem_Models;
using Fire_Emblem_Models.ConditionsFolder;
using Fire_Emblem_Models.EffectsFolder;
using Fire_Emblem_Models.EffectsFolder.BonusEffects;
using Fire_Emblem_Models.EffectsFolder.CounterDenial;
using Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageExtra;
using Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReduction;
using Fire_Emblem_Models.EffectsFolder.DamageModifications.DamageReductionPercentage;
using Fire_Emblem_Models.EffectsFolder.Neutralizations;
using Fire_Emblem_Models.EffectsFolder.PenaltyEffects;
using static Fire_Emblem_Models.Functions.ComparisonFunctions;
using static Fire_Emblem_Models.Actions.HpInCombatActions;

namespace Fire_Emblem.SkillsFolder;

public class SkillCatalog
{
    public static List<ConditionalEffect> GetConditionalEffectsFromSkill(string name)
    {
        int priority;
        List<Effect> effects;
        List<ICondition> conditions;
        List<ConditionalEffect> conditionalEffects = new List<ConditionalEffect>();
        
        switch (name)
        {
            case "Attack +6":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects = new List<Effect> {new BonusEffect("Atk", 6)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Speed +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Spd", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Defense +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Def", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Resistance +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Res", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Def +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Def",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Res +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Res",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Spd + 5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Spd",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Spd/Res +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Res",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Spd/Def +5":
                priority = 1;
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Def",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "HP +15":
                priority = 1;
                conditions = new List<ICondition>() {new EmptyCondition()};
                effects = new List<Effect>() {new BonusHPEffect(15)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Will to Win":
                priority = 1;
                conditions = new List<ICondition>() {new HpPercentageComparisonCondition(0.5, FractionalLessThanOrEqualTo)};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Fair Fight":
                priority = 1;
                conditions = new List<ICondition>() {new StartsCombatCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 6), new BonusRivalEffect("Atk", 6)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Single-Minded":
                priority = 1;
                conditions = new List<ICondition>() {new MostRecentRivalCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Ignis":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new BonusFirstAttackPercentageEffect("Atk", 0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Perceptive":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12), 
                    new FractionalBonusEffect("Spd", 4)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Tome Precision":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Magic") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Wrath":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new ForeachHPLostBonusEffect("Atk", 1),
                    new ForeachHPLostBonusEffect("Spd", 1)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Resolve":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.75, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 7),
                    new BonusEffect("Res", 7)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Deadly Blade":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(), 
                    new WeaponNameCondition("Sword")
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 8),
                    new BonusEffect("Spd", 8)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Death Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Atk", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Armored Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Def", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
                
            case "Darting Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Spd", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Warding Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Res", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Swift Sparrow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sturdy Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Mirror Strike":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Steady Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6)
                    
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Swift Strike":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bracing Blow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Atk/Spd":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Spd", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Atk/Def":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Atk/Res":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Spd/Def":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Spd/Res":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Brazen Def/Res":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.8, FractionalLessThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Fire Boost":
                priority = 1;
                conditions = new List<ICondition>() { new HpComparisonWithRivalCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Atk", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Wind Boost":
                priority = 1;
                conditions = new List<ICondition>() { new HpComparisonWithRivalCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Spd", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Earth Boost":
                priority = 1;
                conditions = new List<ICondition>() { new HpComparisonWithRivalCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Def", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Water Boost":
                priority = 1;
                conditions = new List<ICondition>() { new HpComparisonWithRivalCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Res", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Chaos Style":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new OrCondition( new List<ICondition>()
                    {
                        new AndCondition(new List<ICondition>()
                        {
                            new StartsCombatCondition(),
                            new WeaponTypeCondition("Physical"),
                            new RivalCondition( new WeaponNameCondition("Magic") )
                        }),
                        new AndCondition(new List<ICondition>()
                        {
                            new StartsCombatCondition(),
                            new WeaponNameCondition("Magic"),
                            new RivalCondition( new WeaponTypeCondition("Physical") )
                        })
                    })
                };
                effects = new List<Effect>() { new BonusEffect("Spd", 3) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Blinding Flash":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", 4) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects; 
            
            case "Not *Quite*":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", 4)  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Stunning Smile":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new GenderCondition("Male") ) };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Disarming Sigh":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new GenderCondition("Male") ) };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Charmer":
                priority = 1;
                conditions = new List<ICondition>() { new MostRecentRivalCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 3),
                    new PenaltyRivalEffect("Spd", 3)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Luna":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalFirstAttackPercentageEffect("Def", 0.5),
                    new PenaltyRivalFirstAttackPercentageEffect("Res", 0.5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;  
            
            case "Belief in Love":
                priority = 1;
                conditions = new List<ICondition>() { 
                    new OrCondition(new List<ICondition>()
                    {
                        new RivalCondition( new StartsCombatCondition() ),
                        new RivalCondition( new HpPercentageComparisonCondition(1.0, FractionalEqualTo) )
                    }) 
                };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 5),
                    new PenaltyRivalEffect("Def", 5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Beorc's Blessing":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllBonusesRivalEffect()  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Agnea's Arrow":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllPenaltiesEffect()  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Soulblade":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>() { new SoulbladeEffect() };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sandstorm":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new SandstormEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sword Agility":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lance Power":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sword Power":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bow Focus":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lance Agility":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Axe Power":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Axe") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bow Agility":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sword Focus":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Close Def":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new RivalCondition( new StartsCombatCondition() ),
                    new OrCondition(new List<ICondition>()
                    {
                        new RivalCondition( new WeaponNameCondition("Sword") ),
                        new RivalCondition( new WeaponNameCondition("Lance") ),
                        new RivalCondition( new WeaponNameCondition("Axe") )
                    })
                        
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 8),
                    new BonusEffect("Res", 8),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Distant Def":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new RivalCondition( new StartsCombatCondition() ),
                    new OrCondition(new List<ICondition>()
                    {
                        new RivalCondition( new WeaponNameCondition("Magic") ),
                        new RivalCondition( new WeaponNameCondition("Bow") )
                    })
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 8),
                    new BonusEffect("Res", 8),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Atk/Spd":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 3),
                    new PenaltyRivalEffect("Spd", 3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Spd")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Atk/Def":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 3),
                    new PenaltyRivalEffect("Def", 3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Def")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Atk/Res":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 3),
                    new PenaltyRivalEffect("Res", 3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Spd/Def":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Spd", 3),
                    new PenaltyRivalEffect("Def", 3),
                    new NeutralizeBonusRivalEffect("Spd"),
                    new NeutralizeBonusRivalEffect("Def")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Spd/Res":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Spd", 3),
                    new PenaltyRivalEffect("Res", 3),
                    new NeutralizeBonusRivalEffect("Spd"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lull Def/Res":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Def", 3),
                    new PenaltyRivalEffect("Res", 3),
                    new NeutralizeBonusRivalEffect("Def"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Fort. Def/Res":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Atk", 2)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Life and Death":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6),
                    new PenaltyEffect("Def", 5),
                    new PenaltyEffect("Res", 5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Solid Ground":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6),
                    new PenaltyEffect("Res", 5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Still Water":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Def", 5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Dragonskin":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new OrCondition(new List<ICondition>()
                    {
                        new RivalCondition( new StartsCombatCondition() ),
                        new RivalCondition( new HpPercentageComparisonCondition(0.75, FractionalGreaterThanOrEqualTo) )
                    })
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Light and Dark":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", 5),
                    new PenaltyRivalEffect("Spd", 5),
                    new PenaltyRivalEffect("Def", 5),
                    new PenaltyRivalEffect("Res", 5),
                    new NeutralizeAllPenaltiesEffect(),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Back at You":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>() { new DamageExtraHPPercentageEffect(0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lunar Brace":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponTypeCondition("Physical")
                };
                effects = new List<Effect>() { new DamageExtraPercentageByRivalStatEffect("Def", 0.3) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bravery":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new DamageExtraEffect(5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Dragon Wall":
                priority = 2;
                conditions = new List<ICondition>() { new StatComparisonCondition("Res", GreaterThan) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageStatDifferenceBase("Res", 4) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Dodge":
                priority = 2;
                conditions = new List<ICondition>() { new StatComparisonCondition("Spd", GreaterThan) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageStatDifferenceBase("Spd", 4) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Golden Lotus":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new WeaponTypeCondition("Physical")) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Gentility":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5) )  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bow Guard":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new WeaponNameCondition("Bow") ) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5)) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Arms Shield":
                priority = 1;
                conditions = new List<ICondition>() { new AdvantageCondition() };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(7) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Axe Guard":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new WeaponNameCondition("Axe") ) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Magic Guard":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new WeaponNameCondition("Magic") ) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Lance Guard":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new WeaponNameCondition("Lance") ) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sympathetic":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new RivalCondition( new StartsCombatCondition() ),
                    new HpPercentageComparisonCondition(0.5, FractionalLessThanOrEqualTo)
                };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionEffect(5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bushido":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new DamageExtraEffect(7) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>() { new StatComparisonCondition("Spd", GreaterThan) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageStatDifferenceBase("Spd", 4) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Moon-Twin Wing":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new RivalEffect ( new PenaltyEffect("Atk", 5) ),
                    new RivalEffect ( new PenaltyEffect("Spd", 5) ),
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>()
                {
                    new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo),
                    new StatComparisonCondition("Spd", GreaterThan)
                };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageStatDifferenceBase("Spd", 4) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Blue Skies":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new DamageExtraEffect(5),
                    new RivalEffect( new DamageReductionEffect(5) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Aegis Shield":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 3),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.5) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Remote Sparrow":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Spd", 7),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Remote Mirror":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition()  };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Res", 10),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Remote Sturdy":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition()  };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Def", 10),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Fierce Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 8),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Darting Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 8),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Steady Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 8),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Warding Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Res", 8),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Kestrel Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sturdy Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Mirror Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Steady Posture":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Swift Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Res", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bracing Stance":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                    new RivalEffect( new DamageReductionPercentageFollowUpEffect(0.1) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Poetic Justice":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Spd", 4) ),
                    new DamageExtraPercentageByRivalStatEffect("Atk", 0.15)
                    
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Laguz Friend":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new RivalEffect( new DamageReductionPercentageEffect(0.5) ),
                    new NeutralizeBonusEffect("Def"),
                    new NeutralizeBonusEffect("Res"),
                    new PenaltyPercentageEffect("Def", 0.5),
                    new PenaltyPercentageEffect("Res", 0.5),
                    
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Chivalry":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new RivalCondition( new HpPercentageComparisonCondition(1.0, FractionalEqualTo) )
                };
                effects = new List<Effect>()
                {
                    new DamageExtraEffect(2),
                    new RivalEffect( new DamageReductionEffect(2) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Dragon's Wrath":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.25) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>() { new StatComparisonCondition("Atk", "Res", GreaterThan) };
                effects = new List<Effect>() { new DamageExtraFirstAttackPercentageDifferenceRivalStatEffect("Atk", "Res", 0.25) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Prescience":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Atk", 5) ),
                    new RivalEffect( new PenaltyEffect("Res", 5) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new OrCondition( new List<ICondition>()
                    {
                        new StartsCombatCondition(),
                        new OrCondition( new List<ICondition>()
                        {
                            new RivalCondition( new WeaponNameCondition("Magic") ),
                            new RivalCondition( new WeaponNameCondition("Bow") )
                        })
                    })
                    
                };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Extra Chivalry":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new HpPercentageComparisonCondition(0.5, FractionalGreaterThanOrEqualTo) )  };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Atk", 5) ),
                    new RivalEffect( new PenaltyEffect("Spd", 5) ),
                    new RivalEffect( new PenaltyEffect("Def", 5) )
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition()  };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageHPRival(0.5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
                
            case "Guard Bearing":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition()  };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Spd", 4) ),
                    new RivalEffect( new PenaltyEffect("Def", 4) ),
                    new GuardBearingEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Divine Recreation":
                priority = 1;
                conditions = new List<ICondition>() { new RivalCondition( new HpPercentageComparisonCondition(0.5, FractionalGreaterThanOrEqualTo) ) };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Atk", 4) ),
                    new RivalEffect( new PenaltyEffect("Spd", 4) ),
                    new RivalEffect( new PenaltyEffect("Def", 4) ),
                    new RivalEffect( new PenaltyEffect("Res", 4) ),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) ),
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 3;
                conditions = new List<ICondition>() { new RivalCondition( new HpPercentageComparisonCondition(0.5, FractionalGreaterThanOrEqualTo) ) };
                effects = new List<Effect>() { new DivineRecreationExtraDamageEffect() };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Sol":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new HealAfterAttackEffect(0.25) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Nosferatu":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Magic") };
                effects = new List<Effect>() { new HealAfterAttackEffect(0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Solar Brace":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new HealAfterAttackEffect(0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Windsweep":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponNameCondition("Sword"),
                    new RivalCondition( new WeaponNameCondition("Sword") )
                };
                effects = new List<Effect>() { new RivalEffect( new CounterDenialEffect() ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Surprise Attack":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponNameCondition("Bow"),
                    new RivalCondition( new WeaponNameCondition("Bow") )
                };
                effects = new List<Effect>() { new RivalEffect( new CounterDenialEffect() ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Hliðskjálf":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponNameCondition("Magic"),
                    new RivalCondition( new WeaponNameCondition("Magic") )
                };
                effects = new List<Effect>() { new RivalEffect( new CounterDenialEffect() ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Null C-Disrupt":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition()  };
                effects = new List<Effect>() { new CounterDenialNullEffect()  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Laws of Sacae":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition()  };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>() { 
                    new OrCondition(new List<ICondition>()
                    {
                        new RivalCondition( new WeaponNameCondition("Sword") ),
                        new RivalCondition( new WeaponNameCondition("Lance") ),
                        new RivalCondition( new WeaponNameCondition("Axe") ),
                    }),
                    new StatComparisonCondition("Spd", 5, GreaterThanOrEqualTo)
                };
                effects = new List<Effect>() { new RivalEffect( new CounterDenialEffect() ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Eclipse Brace":
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition(),  };
                effects = new List<Effect>() { new HealAfterAttackEffect(0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponTypeCondition("Physical")
                };
                effects = new List<Effect>()
                {
                    new DamageExtraPercentageByRivalStatEffect("Def", 0.3),
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Resonance":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new WeaponNameCondition("Magic"),
                    new HpFixedComparisonCondition(2, GreaterThanOrEqualTo)
                };
                effects = new List<Effect>()
                {
                    new HpBetweenCombatModificationEffect(1, DamageBeforeCombat),
                    new DamageExtraEffect(3)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Flare":
                priority = 1;
                conditions = new List<ICondition>() { new WeaponNameCondition("Magic") };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyPercentageEffect("Res", 0.2) ),
                    new HealAfterAttackEffect(0.5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Fury":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 4),
                    new BonusEffect("Spd", 4),
                    new BonusEffect("Def", 4),
                    new BonusEffect("Res", 4),
                    new HpBetweenCombatModificationEffect(8, DamageAfterCombat)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Mystic Boost":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new RivalEffect( new PenaltyEffect("Atk", 5) ),
                    new HpBetweenCombatModificationEffect(10, HealingAfterCombat)
                    
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Spd Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Spd", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Def Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Def", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Atk/Res Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 7),
                    new BonusEffect("Res", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Spd/Def Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 7),
                    new BonusEffect("Def", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
                
            case "Spd/Res Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 7),
                    new BonusEffect("Res", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Def/Res Push":
                priority = 1;
                conditions = new List<ICondition>() { new HpPercentageComparisonCondition(0.25, FractionalGreaterThanOrEqualTo) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 7),
                    new BonusEffect("Res", 7),
                    new HpBetweenCombatModificationEffect(5, DamageAfterCombatIfHasAttacked)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Scendscale":
                priority = 1;
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new DamageExtraPercentageByStatEffect("Atk", 0.25),
                    new HpBetweenCombatModificationEffect(7, DamageAfterCombatIfHasAttacked)
                        
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "True Dragon Wall":
                priority = 1;
                conditions = new List<ICondition>() { new IsWeaponInUnitCompanions("Magic") };
                effects = new List<Effect>() { new HpBetweenCombatModificationEffect(7, HealingAfterCombat) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>() { new StatComparisonCondition("Res", GreaterThan) };
                effects = new List<Effect>()
                {
                    new RivalEffect( new DamageReductionPercentageStatDifferenceFirstAttack("Res", 6) ),
                    new RivalEffect( new DamageReductionPercentageStatDifferenceFollowUp("Res", 4) ),
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Mastermind":
                priority = 1;
                conditions = new List<ICondition>() { new HpFixedComparisonCondition(2, GreaterThanOrEqualTo) };
                effects = new List<Effect>() { new HpBetweenCombatModificationEffect(1, DamageBeforeCombat) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 1;
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 9),
                    new BonusEffect("Spd", 9),
                    new DamageExtraSumOfAllBonusesAndPenalties(0.8)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            case "Bewitching Tome":
                priority = 1;
                conditions = new List<ICondition>()
                {
                    new OrCondition(new List<ICondition>()
                    {
                        new StartsCombatCondition(),
                        new OrCondition(new List<ICondition>()
                        {
                            new RivalCondition( new WeaponNameCondition("Bow") ),
                            new RivalCondition( new WeaponNameCondition("Magic") )
                        })
                    })
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk",5),
                    new BonusEffect("Spd",5),
                    new BonusEffect("Def",5),
                    new BonusEffect("Res",5),
                    new BonusEffectPercentageOfStat("Atk", 0.2, "Spd"),
                    new BonusEffectPercentageOfStat("Spd", 0.2, "Spd"),
                    new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.3) ),
                    new HpBetweenCombatModificationEffect(7, HealingAfterCombat)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                priority = 2;
                conditions = new List<ICondition>()
                {
                    new OrCondition(new List<ICondition>()
                    {
                        new StartsCombatCondition(),
                        new OrCondition(new List<ICondition>()
                        {
                            new RivalCondition( new WeaponNameCondition("Bow") ),
                            new RivalCondition( new WeaponNameCondition("Magic") )
                        })
                    })
                };
                effects = new List<Effect>()
                {
                    new HpBetweenCombanBewitchingTomeEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
            
            default:
                priority = 1;
                conditions = new List<ICondition>() {  };
                effects = new List<Effect>() {  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects, priority));
                return conditionalEffects;
        }
    }
}