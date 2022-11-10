using BigDLL4221.Passives;
using BigDLL4221.Utils;
using GlitchedMod.GlitchedDuo.Buffs;

namespace GlitchedMod.GlitchedDuo.Passives
{
    public class PassiveAbility_GlitchedFinnNpc_21341 : PassiveAbility_NpcMechBase_DLL4221
    {
        private bool _filterCheck;

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new GlitchedFinnUtil().FinnNpcUtil);
        }

        public override void OnRoundStartAfter()
        {
            base.OnRoundStartAfter();
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_GlitchedFinnEgo_21341>()) return;
            _filterCheck = true;
            MapUtil.ActiveCreatureBattleCamFilterComponent();
        }

        public override void OnRoundEndTheLast_ignoreDead()
        {
            base.OnRoundEndTheLast_ignoreDead();
            if (!owner.IsDead() || !_filterCheck) return;
            _filterCheck = false;
            MapUtil.ActiveCreatureBattleCamFilterComponent(false);
        }
    }
}