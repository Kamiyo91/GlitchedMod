using BigDLL4221.Buffs;
using BigDLL4221.Utils;
using LOR_DiceSystem;

namespace GlitchedMod.GlitchedPeter.Buffs
{
    public class BattleUnitBuf_FamilyGuyEgo_21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_FamilyGuyEgo_21341() : base(infinite: true, lastOneScene: false)
        {
        }

        public override bool isAssimilation => true;
        protected override string keywordId => "PeterEgoBuff_21341";
        protected override string keywordIconId => "PeterEgoBuff_21341";
        public override int MaxStack => 15;
        public override int AdderStackEachScene => 1;

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = stack > 11 ? 2 : 1 });
        }

        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return detail == BehaviourDetail.None ? base.GetResistHP(origin, detail) : AtkResist.Endure;
        }

        public override void OnRoundStartAfter()
        {
            foreach (var unit in BattleObjectManager.instance.GetAliveList(
                         UnitUtil.ReturnOtherSideFaction(_owner.faction)))
            {
                if (stack > 2) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1, _owner);
                if (stack > 5) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Vulnerable, 1, _owner);
                if (stack > 8) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Disarm, 1, _owner);
                if (stack > 11) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Weak, 1, _owner);
                if (stack > 14) unit.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1, _owner);
            }
        }
    }
}