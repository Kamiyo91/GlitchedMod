using BigDLL4221.Buffs;
using LOR_DiceSystem;

namespace GlitchedMod.GlitchedDuo.Buffs
{
    public class BattleUnitBuf_GlitchedFinnEgo_21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_GlitchedFinnEgo_21341() : base(infinite: true, lastOneScene: false)
        {
        }
        public override bool isAssimilation => true;
        protected override string keywordId => "FinnEgo_21341";
        protected override string keywordIconId => "FinnEgo_21341";
        public override int MaxStack => 30;
        public override int MinStack => 1;
        public override int AdderStackEachScene => -3;

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override AtkResist GetResistBP(AtkResist origin, BehaviourDetail detail)
        {
            return BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())
                ? AtkResist.Endure
                : AtkResist.Normal;
        }

        public override AtkResist GetResistHP(AtkResist origin, BehaviourDetail detail)
        {
            return BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())
                ? AtkResist.Endure
                : AtkResist.Normal;
        }

        public override void OnSuccessAttack(BattleDiceBehavior behavior)
        {
            if (!BattleObjectManager.instance.GetAliveList(_owner.faction)
                    .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())) return;
            behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Bleeding, 1, _owner);
            if (stack > 14)
                behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Disarm, 1, _owner);
            if (stack > 29)
                behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1, _owner);
            OnAddBuf(1);
        }
    }
}