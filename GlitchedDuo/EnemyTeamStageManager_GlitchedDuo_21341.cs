using CustomMapUtility;

namespace GlitchedMod.GlitchedDuo
{
    public class EnemyTeamStageManager_GlitchedDuo_21341 : EnemyTeamStageManager
    {
        private readonly CustomMapHandler _cmh = CustomMapHandler.GetCMU(GlitchedModParameters.PackageId);

        public override void OnWaveStart()
        {
            _cmh.InitCustomMap<GlitchedDuo_21341MapManager>("GlitchedDuo_21341", false, true, 0.5f, 0.55f);
            _cmh.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            _cmh.EnforceMap();
        }
    }
}