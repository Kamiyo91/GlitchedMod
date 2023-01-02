using System.Linq;
using BigDLL4221.BaseClass;
using BigDLL4221.Extensions;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using GlitchedMod.GlitchedPeter.Peter.Passives;

namespace GlitchedMod.GlitchedPeter.Util21341.Extensions
{
    public class MechUtil_Peter : MechUtilBase
    {
        public MechUtil_Peter(MechUtilBaseModel model) : base(model, GlitchedModParameters.PackageId)
        {
        }

        public override bool EgoActive()
        {
            if (!Model.EgoOptions.TryGetValue(0, out var egoOptions)) return false;
            if (!base.EgoActive()) return false;
            var newPassiveDesc = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                .FirstOrDefault(x => x.Key.Equals("PeterEgoPassive_21341"));
            var passiveToChange = Model.Owner.GetActivePassive<PassiveAbility_PeterPlayer_21341>();
            passiveToChange.name = newPassiveDesc.Value.Name;
            passiveToChange.desc = newPassiveDesc.Value.Desc;
            if (!string.IsNullOrEmpty(egoOptions.EgoSkinName))
            {
                Model.Owner.UnitData.unitData.SetTempName(ModParameters.LocalizedItems[GlitchedModParameters.PackageId]
                    .EffectTexts
                    .FirstOrDefault(x => x.Key.Equals("PeterEgoName_21341")).Value.Name);
                UnitUtil.RefreshCombatUI();
            }

            if (!string.IsNullOrEmpty(egoOptions.EgoSkinName))
                Model.Owner.view.ChangeHeight(500);
            CameraFilterUtil.EarthQuake(0.08f, 0.02f, 50f, 0.3f);
            ArtUtil.BaseGameLoadPrefabEffect(Model.Owner,
                "Battle/CreatureEffect/New_IllusionCardFX/6_G/FX_IllusionCard_6_G_Shout", "Creature/Danggo_Lv2_Shout");
            ChangeDeck();
            return true;
        }

        private void ChangeDeck()
        {
            var changesCount = 0;
            foreach (var card in Model.Owner.allyCardDetail.GetHand().ToList()
                         .Where(card => card.GetID().packageId == GlitchedModParameters.PackageId))
                switch (card.GetID().id)
                {
                    case 16:
                        changesCount++;
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 24));
                        break;
                    case 17:
                        changesCount++;
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 21));
                        break;
                    case 18:
                        changesCount++;
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 22));
                        break;
                    case 19:
                        changesCount++;
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 23));
                        break;
                }

            foreach (var card in Model.Owner.allyCardDetail.GetAllDeck().ToList()
                         .Where(card => card.GetID().packageId == GlitchedModParameters.PackageId))
                switch (card.GetID().id)
                {
                    case 16:
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 24));
                        break;
                    case 17:
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 21));
                        break;
                    case 18:
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 22));
                        break;
                    case 19:
                        Model.Owner.allyCardDetail.ExhaustACardAnywhere(card);
                        Model.Owner.allyCardDetail.AddNewCardToDeck(new LorId(GlitchedModParameters.PackageId, 23));
                        break;
                }

            if (changesCount > 0) Model.Owner.allyCardDetail.DrawCards(changesCount);
        }
    }
}