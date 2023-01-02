using System.Collections.Generic;
using System.Linq;
using BigDLL4221.BaseClass;
using BigDLL4221.Models;
using GlitchedMod.GlitchedDuo;
using GlitchedMod.GlitchedDuo.Buffs;
using GlitchedMod.GlitchedDuo.Util.Extension;
using GlitchedMod.GlitchedPeter.Buffs;
using GlitchedMod.GlitchedPeter.Util21341.Extensions;
using LOR_XML;

namespace GlitchedMod
{
    public static class GlitchedModParameters
    {
        public const string PackageId = "GlitchedMod21341.Mod";
        public static string Path = "";

        public static MapModel GlitchedDuoMapModel = new MapModel(typeof(GlitchedDuo_21341MapManager),
            "GlitchedDuo_21341", bgy: 0.55f, originalMapStageIds: new List<LorId> { new LorId(PackageId, 1) });
    }

    public class GlitchedFinnUtil
    {
        public NpcMechUtil_Finn FinnNpcUtil = new NpcMechUtil_Finn(new NpcMechUtilBaseModel("FinnPhaseData21341",
            mechOptions: new Dictionary<int, MechPhaseOptions>
            {
                { 0, new MechPhaseOptions(mechHp: 171, speedDieAdder: 1) },
                {
                    1,
                    new MechPhaseOptions(startMassAttack: true, speedDieAdder: 2, setCounterToMax: true, forceEgo: true,
                        egoMassAttackCardsOptions: new List<SpecialAttackCardOptions>
                            { new SpecialAttackCardOptions(new LorId(GlitchedModParameters.PackageId, 14)) })
                }
            }, egoMaps: new Dictionary<LorId, MapModel>
            {
                { new LorId(GlitchedModParameters.PackageId, 14), GlitchedModParameters.GlitchedDuoMapModel }
            }, egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_GlitchedFinnEgo_21341(),
                        egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Finn",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("FinnEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }, surviveAbDialogList: new List<AbnormalityCardDialog>
            {
                new AbnormalityCardDialog
                {
                    id = "Finn",
                    dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                        .FirstOrDefault(x => x.Key.Equals("FinnSurvive1_21341"))
                        .Value.Desc
                }
            }));

        public MechUtilBase FinnPlayerUtil = new MechUtilBase(new MechUtilBaseModel(
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(GlitchedModParameters.PackageId, 4), new PersonalCardOptions(true, activeEgoCard: true) },
                { new LorId(GlitchedModParameters.PackageId, 13), new PersonalCardOptions(true) }
            }, firstEgoFormCard: new LorId(GlitchedModParameters.PackageId, 4),
            egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_GlitchedFinnEgo_21341(),
                        egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Finn",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("FinnEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }, egoMaps: new Dictionary<LorId, MapModel>
            {
                { new LorId(GlitchedModParameters.PackageId, 13), GlitchedModParameters.GlitchedDuoMapModel }
            },
            surviveAbDialogList: new List<AbnormalityCardDialog>
            {
                new AbnormalityCardDialog
                {
                    id = "Finn",
                    dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                        .FirstOrDefault(x => x.Key.Equals("FinnEgoActive1_21341"))
                        .Value.Desc
                }
            }), GlitchedModParameters.PackageId);
    }

    public class GlitchedJakeUtil
    {
        public NpcMechUtilBase JakeNpcUtil = new NpcMechUtilBase(new NpcMechUtilBaseModel("JakePhaseData21341",
            mechOptions: new Dictionary<int, MechPhaseOptions>
            {
                { 0, new MechPhaseOptions(mechHp: 161, speedDieAdder: 1) },
                { 1, new MechPhaseOptions(2, forceEgo: true) }
            }, egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_GlitchedJakeEgo_21341(),
                        egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Jake",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("JakeEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }, surviveAbDialogList: new List<AbnormalityCardDialog>
            {
                new AbnormalityCardDialog
                {
                    id = "Jake",
                    dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                        .FirstOrDefault(x => x.Key.Equals("JakeSurvive1_21341"))
                        .Value.Desc
                }
            }), GlitchedModParameters.PackageId);

        public MechUtilBase JakePlayerUtil = new MechUtilBase(new MechUtilBaseModel(
            firstEgoFormCard: new LorId(GlitchedModParameters.PackageId, 4),
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(GlitchedModParameters.PackageId, 4), new PersonalCardOptions(true, activeEgoCard: true) }
            }, surviveAbDialogList: new List<AbnormalityCardDialog>
            {
                new AbnormalityCardDialog
                {
                    id = "Jake",
                    dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                        .FirstOrDefault(x => x.Key.Equals("JakeSurvive1_21341"))
                        .Value.Desc
                }
            }, egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_GlitchedJakeEgo_21341(),
                        egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Jake",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("JakeEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }), GlitchedModParameters.PackageId);
    }

    public class GlitchedPeterUtil
    {
        public NpcMechUtil_Peter PeterNpcUtil = new NpcMechUtil_Peter(new NpcMechUtilBaseModel("PeterPhase21341",
            originalSkinName: "PeterPhase1_21341", mechOptions: new Dictionary<int, MechPhaseOptions>
            {
                { 0, new MechPhaseOptions(mechHp: 502, speedDieAdder: 2) },
                {
                    1,
                    new MechPhaseOptions(forceEgo: true, speedDieAdder: 4,
                        additionalPassiveByIds: new List<LorId>
                        {
                            new LorId(GlitchedModParameters.PackageId, 8),
                            new LorId(GlitchedModParameters.PackageId, 9),
                            new LorId(GlitchedModParameters.PackageId, 10),
                            new LorId(GlitchedModParameters.PackageId, 11)
                        })
                }
            }, egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_FamilyGuyEgo_21341(), refreshUI: true,
                        egoSkinName: "PeterPhase2_21341", egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Peter",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("PeterEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }));

        public MechUtil_Peter PeterPlayerUtil = new MechUtil_Peter(new MechUtilBaseModel(
            firstEgoFormCard: new LorId(GlitchedModParameters.PackageId, 15),
            personalCards: new Dictionary<LorId, PersonalCardOptions>
            {
                { new LorId(GlitchedModParameters.PackageId, 15), new PersonalCardOptions(true, activeEgoCard: true) }
            },
            egoOptions: new Dictionary<int, EgoOptions>
            {
                {
                    0, new EgoOptions(new BattleUnitBuf_FamilyGuyEgo_21341(), "PeterPhase2_21341", true, new List<LorId>
                        {
                            new LorId(GlitchedModParameters.PackageId, 8),
                            new LorId(GlitchedModParameters.PackageId, 9),
                            new LorId(GlitchedModParameters.PackageId, 10),
                            new LorId(GlitchedModParameters.PackageId, 11)
                        }
                        , egoAbDialogList: new List<AbnormalityCardDialog>
                        {
                            new AbnormalityCardDialog
                            {
                                id = "Peter",
                                dialog = ModParameters.LocalizedItems[GlitchedModParameters.PackageId].EffectTexts
                                    .FirstOrDefault(x => x.Key.Equals("PeterEgoActive1_21341"))
                                    .Value.Desc
                            }
                        })
                }
            }));
    }
}