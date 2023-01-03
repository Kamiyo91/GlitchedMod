using System.Collections.Generic;
using BigDLL4221.Models;
using BigDLL4221.StageManagers;
using CustomMapUtility;

namespace GlitchedMod.GlitchedDuo
{
    public class EnemyTeamStageManager_GlitchedDuo_21341 : EnemyTeamStageManager_BaseWithCMU_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(CustomMapHandler.GetCMU(GlitchedModParameters.PackageId), new GlitchedFinnUtil().FinnNpcUtil,
                new List<MapModel> { GlitchedModParameters.GlitchedDuoMapModel });
            base.OnWaveStart();
        }

        public override void OnRoundStart_After()
        {
        }
    }
}