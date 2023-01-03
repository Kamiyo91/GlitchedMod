using System.Collections.Generic;
using BigDLL4221.Models;
using BigDLL4221.StageManagers;
using CustomMapUtility;

namespace GlitchedMod.GlitchedPeter
{
    public class EnemyTeamStageManager_Peter_21341 : EnemyTeamStageManager_BaseWithCMU_DLL4221
    {
        public override void OnWaveStart()
        {
            SetParameters(CustomMapHandler.GetCMU(GlitchedModParameters.PackageId),
                new GlitchedPeterUtil().PeterNpcUtil,
                new List<MapModel> { GlitchedModParameters.GlitchedPeterMapModel });
            base.OnWaveStart();
        }
    }
}