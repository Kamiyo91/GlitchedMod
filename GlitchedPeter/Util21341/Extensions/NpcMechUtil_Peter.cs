using System.Linq;
using BigDLL4221.BaseClass;
using BigDLL4221.Extensions;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using GlitchedMod.GlitchedPeter.Buffs;
using GlitchedMod.GlitchedPeter.Peter.Passives;

namespace GlitchedMod.GlitchedPeter.Util21341.Extensions
{
    public class NpcMechUtil_Peter : NpcMechUtilBase
    {
        public NpcMechUtil_Peter(NpcMechUtilBaseModel model) : base(model)
        {
        }

        public override bool EgoActive()
        {
            if (!base.EgoActive()) return false;
            var newPassiveDesc = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                .FirstOrDefault(x => x.Key.Equals("PeterEgoPassive_21341"));
            var passiveToChange = Model.Owner.GetActivePassive<PassiveAbility_PeterNpc_21341>();
            passiveToChange.name = newPassiveDesc.Value.Name;
            passiveToChange.desc = newPassiveDesc.Value.Desc;
            Model.Owner.bufListDetail.AddBuf(new BattleUnitBuf_ShimmeringPeter_21341());
            Model.Owner.UnitData.unitData.SetTempName(ModParameters.LocalizedItems[GlitchedModParameters.PackageId]
                .EffectTexts.FirstOrDefault(x => x.Key.Equals("PeterEgoName_21341")).Value.Name);
            UnitUtil.RefreshCombatUI();
            Model.Owner.view.ChangeHeight(500);
            CameraFilterUtil.EarthQuake(0.08f, 0.02f, 50f, 0.3f);
            ArtUtil.BaseGameLoadPrefabEffect(Model.Owner,
                "Battle/CreatureEffect/New_IllusionCardFX/6_G/FX_IllusionCard_6_G_Shout", "Creature/Danggo_Lv2_Shout");
            ChangeDeck();
            return true;
        }

        private void ChangeDeck()
        {
            var handCount = Model.Owner.allyCardDetail.GetHand().Count;
            Model.Owner.allyCardDetail.ExhaustAllCards();
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 24));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 24));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 24));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 23));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 23));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 21));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 21));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 22));
            Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 22));
            Model.Owner.allyCardDetail.DrawCards(handCount);
        }
    }
}