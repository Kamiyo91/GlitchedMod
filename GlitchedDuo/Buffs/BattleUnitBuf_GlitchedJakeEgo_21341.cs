using BigDLL4221.Buffs;

namespace GlitchedMod.GlitchedDuo.Buffs
{
    public class BattleUnitBuf_GlitchedJakeEgo_21341 : BattleUnitBuf_BaseBufChanged_DLL4221
    {
        public BattleUnitBuf_GlitchedJakeEgo_21341() : base(infinite: true, lastOneScene: false)
        {
        }

        public override bool isAssimilation => true;
        protected override string keywordId => "JakeEgo_21341";
        protected override string keywordIconId => "JakeEgo_21341";
        public override int MaxStack => 30;
        public override int MinStack => 1;
        public override int AdderStackEachScene => -3;

        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            behavior.ApplyDiceStatBonus(new DiceStatBonus { power = 1 });
        }

        public override void OnRoundEnd()
        {
            if (BattleObjectManager.instance.GetAliveList(_owner.faction)
                .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>()))
                _owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Quickness, 3);
        }

        public override void OnSuccessAttack(BattleDiceBehavior behavior)
        {
            if (!BattleObjectManager.instance.GetAliveList(_owner.faction)
                    .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>())) return;
            behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Vulnerable, 1, _owner);
            if (stack > 14)
                behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Binding, 1, _owner);
            if (stack > 29)
                behavior.card.target?.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Decay, 1, _owner);
            OnAddBuf(1);
        }
    }
}