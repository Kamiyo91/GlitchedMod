namespace GlitchedMod.GlitchedPeter.Buffs
{
    public class BattleUnitBuf_ShimmeringPeter_21341 : BattleUnitBuf
    {
        public override int GetCardCostAdder(BattleDiceCardModel card)
        {
            return -99;
        }

        public override void OnRoundStart()
        {
            _owner.allyCardDetail.DrawCards(8);
        }
    }
}