namespace GlitchedMod.GlitchedPeter.Peter.Passives
{
    public class PassiveAbility_GlitchedField_21341 : PassiveAbilityBase
    {
        public override void AfterTakeDamage(BattleUnitModel attacker, int dmg)
        {
            attacker?.TakeDamage(3);
            attacker?.TakeBreakDamage(3);
        }
    }
}