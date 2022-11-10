using System.Linq;
using BigDLL4221.Utils;

namespace GlitchedMod.GlitchedDuo.Passives
{
    public class PassiveAbility_BestDuo_21341 : PassiveAbilityBase
    {
        private bool _buffActive;
        private int _memberCount;

        public override void OnWaveStart()
        {
            _memberCount = UnitUtil.SupportCharCheck(owner);
            if (_memberCount == 1 && BattleObjectManager.instance.GetAliveList(owner.faction)
                    .Count(x => x.passiveDetail.PassiveList.Any(y => y is PassiveAbility_BestDuo_21341)) == 2)
            {
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
                owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 2);
                _buffActive = true;
                return;
            }

            switch (_memberCount)
            {
                case 1:
                    if (BattleObjectManager.instance.GetAliveList(owner.faction)
                            .Count(x => x.passiveDetail.PassiveList.Any(y => y is PassiveAbility_BestDuo_21341)) == 2)
                    {
                        owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2);
                        owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2);
                        _buffActive = true;
                        break;
                    }

                    _buffActive = false;
                    break;
                case 2:
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 2);
                    owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 2);
                    _buffActive = true;
                    break;
                default:
                    _buffActive = false;
                    break;
            }
        }

        public override void OnRoundEnd()
        {
            _memberCount = UnitUtil.SupportCharCheck(owner);
            switch (_memberCount)
            {
                case 1:
                    if (BattleObjectManager.instance.GetAliveList(owner.faction)
                            .Count(x => x.passiveDetail.PassiveList.Any(y => y is PassiveAbility_BestDuo_21341)) == 2)
                    {
                        owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2);
                        owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2);
                        _buffActive = true;
                        break;
                    }

                    _buffActive = false;
                    break;
                case 2:
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2);
                    owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2);
                    _buffActive = true;
                    break;
                default:
                    _buffActive = false;
                    break;
            }
        }

        public bool GetBuffStatus()
        {
            return _buffActive;
        }
    }
}