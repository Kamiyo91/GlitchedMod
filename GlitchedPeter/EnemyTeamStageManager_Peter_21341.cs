using CustomMapUtility;

namespace GlitchedMod.GlitchedPeter
{
    public class EnemyTeamStageManager_Peter_21341 : EnemyTeamStageManager
    {
        private readonly CustomMapHandler _cmh = CustomMapHandler.GetCMU(GlitchedModParameters.PackageId);

        public override void OnWaveStart()
        {
            _cmh.InitCustomMap<GlitchedPeter_21341MapManager>("GlitchedPeter_21341", false, true, 0.5f,
                0.55f);
            _cmh.EnforceMap();
            Singleton<StageController>.Instance.CheckMapChange();
        }

        public override void OnRoundStart()
        {
            _cmh.EnforceMap();
        }
    }
}