using CustomMapUtility;
using UnityEngine;

namespace GlitchedMod.GlitchedDuo
{
    public class GlitchedDuo_21341MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs => new[] { "GlitchedDuo21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}