using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using GlitchedMod.GlitchedDuo.Buffs;

namespace GlitchedMod.GlitchedDuo.Util.Extension
{
    public class NpcMechUtil_Finn : NpcMechUtilBase
    {
        public NpcMechUtil_Finn(NpcMechUtilBaseModel model) : base(model, GlitchedModParameters.PackageId)
        {
        }

        public override void OnSelectCardPutMassAttack(ref BattleDiceCardModel origin)
        {
            if (!Model.MechOptions.TryGetValue(Model.Phase, out var mechOptions)) return;
            if (!BattleObjectManager.instance.GetAliveList()
                    .Exists(x => x.bufListDetail.HasBuf<BattleUnitBuf_GlitchedJakeEgo_21341>())) return;
            if (!Model.MassAttackStartCount || mechOptions.Counter < mechOptions.MaxCounter || Model.OneTurnCard)
                return;
            var card = RandomUtil.SelectOne(mechOptions.EgoMassAttackCardsOptions);
            origin = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(card.CardId));
            SetOneTurnCard(true);
        }
    }
}