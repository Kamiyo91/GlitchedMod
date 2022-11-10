using BigDLL4221.Passives;
using BigDLL4221.Utils;
using GlitchedMod.GlitchedPeter.Buffs;

namespace GlitchedMod.GlitchedPeter.Peter.Passives
{
    public class PassiveAbility_PeterNpc_21341 : PassiveAbility_NpcMechBase_DLL4221
    {
        private bool _filterCheck;

        public override void Init(BattleUnitModel self)
        {
            base.Init(self);
            SetUtil(new GlitchedPeterUtil().PeterNpcUtil);
        }

        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.view.ChangeHeight(250);
        }

        public override void OnRoundStartAfter()
        {
            base.OnRoundStartAfter();
            if (!owner.bufListDetail.HasBuf<BattleUnitBuf_FamilyGuyEgo_21341>()) return;
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