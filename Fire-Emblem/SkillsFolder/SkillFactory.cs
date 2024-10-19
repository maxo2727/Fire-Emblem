using Fire_Emblem_Models;
using Fire_Emblem_Models.ConditionsFolder;
using Fire_Emblem_Models.EffectsFolder;

namespace Fire_Emblem.SkillsFolder;

public class SkillFactory
{
    public static List<ConditionalEffect> GetConditionalEffects(string name)
    {
        List<Effect> effects;
        List<ICondition> conditions;
        List<ConditionalEffect> conditionalEffects = new List<ConditionalEffect>();
        
        switch (name)
        {
            case "Attack +6":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects = new List<Effect> {new BonusEffect("Atk", 6)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Speed +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Spd", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Defense +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Def", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Resistance +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Res", 5)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Atk/Def +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Def",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Atk/Res +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Res",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Atk/Spd + 5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Spd",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Spd/Res +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Res",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Spd/Def +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Def",5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "HP +15":
                conditions = new List<ICondition>() {new EmptyCondition()};
                effects = new List<Effect>() {new BonusHPEffect(15)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Will to Win":
                conditions = new List<ICondition>() {new HPLessThanCondition(0.5)};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Fair Fight":
                conditions = new List<ICondition>() {new StartsCombatCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 6), new BonusRivalEffect("Atk", 6)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Single-Minded":
                conditions = new List<ICondition>() {new MostRecentRivalCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Ignis":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new BonusFirstAttackPercentageEffect("Atk", 0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Perceptive":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12), 
                    new FractionalBonusEffect("Spd", 4)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Tome Precision":
                conditions = new List<ICondition>() { new WeaponNameCondition("Magic") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Wrath":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new ForeachHPLostBonusEffect("Atk", 1),
                    new ForeachHPLostBonusEffect("Spd", 1)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Resolve":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.75) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 7),
                    new BonusEffect("Res", 7)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Deadly Blade":
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
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Death Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Atk", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Armored Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Def", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
                
            case "Darting Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Spd", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Warding Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Res", 8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Swift Sparrow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Sturdy Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Mirror Strike":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Steady Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6)
                    
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Swift Strike":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Bracing Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Atk/Spd":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Spd", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Atk/Def":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Atk/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Spd/Def":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Def", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Spd/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Brazen Def/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 10),
                    new BonusEffect("Res", 10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Fire Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Atk", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Wind Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Spd", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Earth Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Def", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Water Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Res", 6) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Chaos Style":
                conditions = new List<ICondition>()
                {
                    new OrCondition( new List<ICondition>()
                    {
                        new AndCondition(new List<ICondition>()
                        {
                            new StartsCombatCondition(),
                            new WeaponTypeCondition("Physical"),
                            new WeaponNameRivalCondition("Magic")
                        }),
                        new AndCondition(new List<ICondition>()
                        {
                            new StartsCombatCondition(),
                            new WeaponNameCondition("Magic"),
                            new WeaponTypeRivalCondition("Physical")
                        })
                    })
                };
                effects = new List<Effect>() { new BonusEffect("Spd", 3) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Blinding Flash":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", -4) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break; 
            
            case "Not *Quite*":
                conditions = new List<ICondition>() { new StartsCombatRivalCondition() };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", -4)  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Stunning Smile":
                conditions = new List<ICondition>() { new GenderRivalCondition("Male") };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", -8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Disarming Sigh":
                conditions = new List<ICondition>() { new GenderRivalCondition("Male") };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", -8) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Charmer":
                conditions = new List<ICondition>() { new MostRecentRivalCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -3),
                    new PenaltyRivalEffect("Spd", -3)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Luna":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalFirstAttackPercentageEffect("Def", 0.5),
                    new PenaltyRivalFirstAttackPercentageEffect("Res", 0.5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Belief in Love":
                conditions = new List<ICondition>() { 
                    new OrCondition(new List<ICondition>()
                    {
                        new StartsCombatRivalCondition(),
                        new HPRivalCondition(1.0)
                    }) 
                };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -5),
                    new PenaltyRivalEffect("Def", -5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Beorc's Blessing":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllBonusesRivalEffect()  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Agnea's Arrow":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllPenaltiesEffect()  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Soulblade":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>() { new SoulbladeEffect() };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Sandstorm":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new SandstormEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Sword Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lance Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Sword Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Bow Focus":
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", -10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lance Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Axe Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Axe") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Bow Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Sword Focus":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", -10)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Close Def":
                conditions = new List<ICondition>()
                {
                    new StartsCombatRivalCondition(),
                    new OrCondition(new List<ICondition>()
                    {
                        new WeaponNameRivalCondition("Sword"),
                        new WeaponNameRivalCondition("Lance"),
                        new WeaponNameRivalCondition("Axe")
                    })
                        
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 8),
                    new BonusEffect("Res", 8),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Distant Def":
                conditions = new List<ICondition>()
                {
                    new StartsCombatRivalCondition(),
                    new OrCondition(new List<ICondition>()
                    {
                        new WeaponNameRivalCondition("Magic"),
                        new WeaponNameRivalCondition("Bow")
                    })
                };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 8),
                    new BonusEffect("Res", 8),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Atk/Spd":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -3),
                    new PenaltyRivalEffect("Spd", -3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Spd")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Atk/Def":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -3),
                    new PenaltyRivalEffect("Def", -3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Def")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Atk/Res":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -3),
                    new PenaltyRivalEffect("Res", -3),
                    new NeutralizeBonusRivalEffect("Atk"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Spd/Def":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Spd", -3),
                    new PenaltyRivalEffect("Def", -3),
                    new NeutralizeBonusRivalEffect("Spd"),
                    new NeutralizeBonusRivalEffect("Def")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Spd/Res":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Spd", -3),
                    new PenaltyRivalEffect("Res", -3),
                    new NeutralizeBonusRivalEffect("Spd"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lull Def/Res":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Def", -3),
                    new PenaltyRivalEffect("Res", -3),
                    new NeutralizeBonusRivalEffect("Def"),
                    new NeutralizeBonusRivalEffect("Res")
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Fort. Def/Res":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Atk", -2)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Life and Death":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6),
                    new PenaltyEffect("Def", -5),
                    new PenaltyEffect("Res", -5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Solid Ground":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6),
                    new PenaltyEffect("Res", -5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Still Water":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Def", -5)
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Dragonskin":
                conditions = new List<ICondition>()
                {
                    new OrCondition(new List<ICondition>()
                    {
                        new StartsCombatRivalCondition(),
                        new HPRivalMoreThanCondition(0.75)
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
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Light and Dark":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -5),
                    new PenaltyRivalEffect("Spd", -5),
                    new PenaltyRivalEffect("Def", -5),
                    new PenaltyRivalEffect("Res", -5),
                    new NeutralizeAllPenaltiesEffect(),
                    new NeutralizeAllBonusesRivalEffect()
                };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Back at You":
                conditions = new List<ICondition>() { new RivalCondition( new StartsCombatCondition() ) };
                effects = new List<Effect>() { new DamageExtraHPPercentageEffect(0.5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Lunar Brace":
                conditions = new List<ICondition>()
                {
                    new StartsCombatCondition(),
                    new WeaponTypeCondition("Physical")
                };
                effects = new List<Effect>() { new DamageExtraPercentageRivalEffect("Def", 0.3) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Bravery":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new DamageExtraEffect(5) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Dragon Wall":
                conditions = new List<ICondition>() { };
                effects = new List<Effect>() {  };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            case "Golden Lotus":
                conditions = new List<ICondition>() { new RivalCondition( new WeaponTypeCondition("Physical")) };
                effects = new List<Effect>() { new RivalEffect( new DamageReductionPercentageFirstAttackEffect(0.5) ) };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
            
            
            
            default:
                conditions = new List<ICondition>() { };
                effects = new List<Effect>() {   };
                conditionalEffects.Add(new ConditionalEffect(conditions, effects));
                return conditionalEffects;
                break;
        }
    }
}

// todo Mejoras:
// - or and conditions: que conditions sera una sola, o que and no exista y sea una lista?
// - Ver tema de Hp: limpiar
// - Heredar efectos y condiciones similares
// - Limpiar flujo pelea con capitulos clean code
// Ojo, ver mis comentarios preguntas y resolverlas/borrarlas, o dejar los necesarios, tambien puede limpiar...!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

// Preguntas profe:
// train wreck son Hp y agregar habilidades -> Ley de demeter?
// Heredar efectos?