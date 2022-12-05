using System.Linq;
using BigDLL4221.Utils;

namespace GlitchedMod.GlitchedDuo.Passives
{
    public class PassiveAbility_BestDuo_21341 : PassiveAbilityBase
    {
        private bool _buffActive;

        public override void OnWaveStart()
        {
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                    .Count(x => x.passiveDetail.PassiveList.Any(y => y is PassiveAbility_BestDuo_21341)) == 2)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2);
                _buffActive = true;
            }
            else _buffActive = false;
        }

        public override void OnRoundEnd()
        {
            if (BattleObjectManager.instance.GetAliveList(owner.faction)
                    .Count(x => x.passiveDetail.PassiveList.Any(y => y is PassiveAbility_BestDuo_21341)) == 2)
            {
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2);
                owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2);
                _buffActive = true;
            }
            else _buffActive = false;
        }

        public bool GetBuffStatus()
        {
            return _buffActive;
        }
    }
}