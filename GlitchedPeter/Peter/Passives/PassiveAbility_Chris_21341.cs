using BigDLL4221.Utils;

namespace GlitchedMod.GlitchedPeter.Peter.Passives
{
    public class PassiveAbility_Chris_21341 : PassiveAbilityBase
    {
        public override void OnStartBattle()
        {
            UnitUtil.ReadyCounterCard(owner, 20, GlitchedModParameters.PackageId);
        }

        public override void OnRoundStart()
        {
            owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Protection, 3, owner);
        }
    }
}