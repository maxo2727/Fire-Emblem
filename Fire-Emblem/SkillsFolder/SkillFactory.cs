using Fire_Emblem_Models;
using Fire_Emblem_Models.ConditionsFolder;
using Fire_Emblem_Models.EffectsFolder;

namespace Fire_Emblem.SkillsFolder;

public class SkillFactory
{
    public static Skill CreateSkill(string name)
    {
        List<Effect> effects;
        List<ICondition> conditions;
        
        switch (name)
        {
            case "Attack +6":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects = new List<Effect> {new BonusEffect("Atk", 6)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Speed +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Spd", 5)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Defense +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Def", 5)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Resistance +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect> {new BonusEffect("Res", 5)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Atk/Def +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Def",5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Atk/Res +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Res",5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Atk/Spd + 5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Atk", 5), 
                    new BonusEffect("Spd",5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Spd/Res +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Res",5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Spd/Def +5":
                conditions = new List<ICondition> {new EmptyCondition()};
                effects =  new List<Effect>
                {
                    new BonusEffect("Spd", 5), 
                    new BonusEffect("Def",5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "HP +15":
                conditions = new List<ICondition>() {new EmptyCondition()};
                effects = new List<Effect>() {new BonusHPEffect(15)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Will to Win":
                conditions = new List<ICondition>() {new HPLessThanCondition(0.5)};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Fair Fight":
                conditions = new List<ICondition>() {new StartsCombatCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 6), new BonusRivalEffect("Atk", 6)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Single-Minded":
                conditions = new List<ICondition>() {new MostRecentRivalCondition()};
                effects = new List<Effect>() {new BonusEffect("Atk", 8)};
                return new Skill(name, conditions, effects);
                break;
            
            case "Ignis":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new BonusFirstAttackPercentageEffect("Atk", 0.5) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Perceptive":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12), 
                    new FractionalBonusEffect("Spd", 4)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Tome Precision":
                conditions = new List<ICondition>() { new WeaponNameCondition("Magic") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Wrath":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new ForeachHPLostBonusEffect("Atk", 1),
                    new ForeachHPLostBonusEffect("Spd", 1)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Resolve":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.75) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 7),
                    new BonusEffect("Res", 7)
                };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            case "Death Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Atk", 8) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Armored Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Def", 8) };
                return new Skill(name, conditions, effects);
                break;
                
            case "Darting Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Spd", 8) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Warding Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new BonusEffect("Res", 8) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Swift Sparrow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Spd", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Sturdy Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Mirror Strike":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Steady Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Def", 6)
                    
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Swift Strike":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 6),
                    new BonusEffect("Res", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Bracing Blow":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Atk/Spd":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Spd", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Atk/Def":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Def", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Atk/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new BonusEffect("Res", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Spd/Def":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Def", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Spd/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 10),
                    new BonusEffect("Res", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Brazen Def/Res":
                conditions = new List<ICondition>() { new HPLessThanCondition(0.8) };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 10),
                    new BonusEffect("Res", 10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Fire Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Atk", 6) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Wind Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Spd", 6) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Earth Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Def", 6) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Water Boost":
                conditions = new List<ICondition>() { new HPRivalComparisonCondition(3) };
                effects = new List<Effect>() { new BonusEffect("Res", 6) };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            case "Blinding Flash":
                conditions = new List<ICondition>() { new StartsCombatCondition() };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", -4) };
                return new Skill(name, conditions, effects);
                break; 
            
            case "Not *Quite*":
                conditions = new List<ICondition>() { new StartsCombatRivalCondition() };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", -4)  };
                return new Skill(name, conditions, effects);
                break;
            
            case "Stunning Smile":
                conditions = new List<ICondition>() { new GenderRivalCondition("Male") };
                effects = new List<Effect>() { new PenaltyRivalEffect("Spd", -8) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Disarming Sigh":
                conditions = new List<ICondition>() { new GenderRivalCondition("Male") };
                effects = new List<Effect>() { new PenaltyRivalEffect("Atk", -8) };
                return new Skill(name, conditions, effects);
                break;
            
            case "Charmer":
                conditions = new List<ICondition>() { new MostRecentRivalCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalEffect("Atk", -3),
                    new PenaltyRivalEffect("Spd", -3)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Luna":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new PenaltyRivalFirstAttackPercentageEffect("Def", 0.5),
                    new PenaltyRivalFirstAttackPercentageEffect("Res", 0.5)
                };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            case "Beorc's Blessing":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllBonusesRivalEffect()  };
                return new Skill(name, conditions, effects);
                break;
            
            case "Agnea's Arrow":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>() { new NeutralizeAllPenaltiesEffect()  };
                return new Skill(name, conditions, effects);
                break;
            
            case "Soulblade":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>() { new SoulbladeEffect() };
                return new Skill(name, conditions, effects);
                break;
            
            case "Sandstorm":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new SandstormEffect()
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Sword Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Lance Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Sword Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Bow Focus":
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", -10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Lance Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Lance") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Axe Power":
                conditions = new List<ICondition>() { new WeaponNameCondition("Axe") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Def", -10)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Bow Agility":
                conditions = new List<ICondition>() { new WeaponNameCondition("Bow") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Spd", 12),
                    new PenaltyEffect("Atk", -6)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Sword Focus":
                conditions = new List<ICondition>() { new WeaponNameCondition("Sword") };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 10),
                    new PenaltyEffect("Res", -10)
                };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            case "Fort. Def/Res":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Def", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Atk", -2)
                };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            case "Solid Ground":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Def", 6),
                    new PenaltyEffect("Res", -5)
                };
                return new Skill(name, conditions, effects);
                break;
            
            case "Still Water":
                conditions = new List<ICondition>() { new EmptyCondition() };
                effects = new List<Effect>()
                {
                    new BonusEffect("Atk", 6),
                    new BonusEffect("Res", 6),
                    new PenaltyEffect("Def", -5)
                };
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
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
                return new Skill(name, conditions, effects);
                break;
            
            default:
                conditions = new List<ICondition>() { };
                effects = new List<Effect>() {  };
                return new Skill(name, conditions, effects);
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