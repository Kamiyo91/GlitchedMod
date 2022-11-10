using BigDLL4221.Utils;
using UnityEngine;

namespace GlitchedMod.GlitchedPeter
{
    public class GlitchedPeter_21341MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs => new[] { "GlitchedPeter21341.ogg" };

        public override void EnableMap(bool b)
        {
            sephirahColor = Color.black;
            base.EnableMap(b);
        }
    }
}