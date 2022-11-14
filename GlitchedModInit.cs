using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BigDLL4221.Enum;
using BigDLL4221.Models;
using BigDLL4221.Utils;
using LOR_DiceSystem;
using MonoMod.Utils;
using UnityEngine;

namespace GlitchedMod
{
    public class GlitchedModInit : ModInitializer
    {
        public override void OnInitializeMod()
        {
            OnInitParameters();
            ArtUtil.GetArtWorks(new DirectoryInfo(GlitchedModParameters.Path + "/ArtWork"));
            CardUtil.ChangeCardItem(ItemXmlDataList.instance, GlitchedModParameters.PackageId);
            PassiveUtil.ChangePassiveItem(GlitchedModParameters.PackageId);
            LocalizeUtil.AddGlobalLocalize(GlitchedModParameters.PackageId);
            ArtUtil.PreLoadBufIcons();
            LocalizeUtil.RemoveError();
            CardUtil.InitKeywordsList(new List<Assembly> { Assembly.GetExecutingAssembly() });
            ArtUtil.InitCustomEffects(new List<Assembly> { Assembly.GetExecutingAssembly() });
            CustomMapHandler.ModResources.CacheInit.InitCustomMapFiles(Assembly.GetExecutingAssembly());
        }

        private static void OnInitParameters()
        {
            ModParameters.PackageIds.Add(GlitchedModParameters.PackageId);
            GlitchedModParameters.Path = Path.GetDirectoryName(
                Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));
            ModParameters.Path.Add(GlitchedModParameters.PackageId, GlitchedModParameters.Path);
            ModParameters.DefaultKeyword.Add(GlitchedModParameters.PackageId, "GlitchedModPage_Re21341");
            OnInitSprites();
            OnInitSkins();
            OnInitKeypages();
            OnInitCards();
            OnInitDropBooks();
            OnInitPassives();
            OnInitRewards();
            OnInitStages();
            OnInitCredenza();
        }

        private static void OnInitRewards()
        {
            ModParameters.StartUpRewardOptions.Add(new RewardOptions(new Dictionary<LorId, int>
                {
                    { new LorId(GlitchedModParameters.PackageId, 3), 0 },
                    { new LorId(GlitchedModParameters.PackageId, 5), 0 }
                }
            ));
        }

        private static void OnInitCards()
        {
            ModParameters.CardOptions.Add(GlitchedModParameters.PackageId, new List<CardOptions>
            {
                new CardOptions(5, CardOption.OnlyPage, new List<string> { "GlitchedFinnPage_21341" },
                    new List<LorId> { new LorId(GlitchedModParameters.PackageId, 10000001) },
                    cardColorOptions: new CardColorOptions(new Color(0.86f, 0.86f, 86f),
                        customIconColor: new Color(0.86f, 0.86f, 86f), iconColor: HSVColors.White)),
                new CardOptions(12, CardOption.OnlyPage, new List<string> { "GlitchedJakePage_21341" },
                    new List<LorId> { new LorId(GlitchedModParameters.PackageId, 10000002) },
                    cardColorOptions: new CardColorOptions(new Color(0.86f, 0.86f, 86f),
                        customIconColor: new Color(0.86f, 0.86f, 86f), iconColor: HSVColors.White)),
                new CardOptions(4, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0.86f, 0.86f, 86f),
                        customIconColor: new Color(0.86f, 0.86f, 86f), iconColor: HSVColors.White)),
                new CardOptions(15, CardOption.Personal,
                    cardColorOptions: new CardColorOptions(new Color(0.86f, 0.86f, 86f),
                        customIconColor: new Color(0.86f, 0.86f, 86f), iconColor: HSVColors.White))
            });
        }

        private static void OnInitSkins()
        {
            ModParameters.SkinOptions.AddRange(new Dictionary<string, SkinOptions>
            {
                { "PeterPhase1_21341", new SkinOptions(GlitchedModParameters.PackageId, 250) },
                { "PeterPhase2_21341", new SkinOptions(GlitchedModParameters.PackageId, 500) }
            });
        }

        private static void OnInitKeypages()
        {
            ModParameters.KeypageOptions.Add(GlitchedModParameters.PackageId, new List<KeypageOptions>
            {
                new KeypageOptions(10000001,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new KeypageOptions(10000002,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 2),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new KeypageOptions(10000003,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 3, customFaceData: false,
                        originalSkin: "PeterPhase1_21341", egoSkin: new List<string> { "PeterPhase2_21341" }),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new KeypageOptions(1,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 1),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new KeypageOptions(2,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 2),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new KeypageOptions(3,
                    bookCustomOptions: new BookCustomOptions(nameTextId: 3, customFaceData: false,
                        originalSkin: "PeterPhase1_21341", egoSkin: new List<string> { "PeterPhase2_21341" }),
                    keypageColorOptions: new KeypageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f)))
            });
        }

        private static void OnInitCredenza()
        {
            ModParameters.CredenzaOptions.Add(GlitchedModParameters.PackageId,
                new CredenzaOptions(CredenzaEnum.ModifiedCredenza, credenzaNameId: GlitchedModParameters.PackageId,
                    customIconSpriteId: GlitchedModParameters.PackageId, credenzaBooksId: new List<int>
                    {
                        10000001, 10000002, 10000003
                    }));
        }

        private static void OnInitSprites()
        {
            ModParameters.SpriteOptions.Add(GlitchedModParameters.PackageId, new List<SpriteOptions>
            {
                new SpriteOptions(SpriteEnum.Custom, 10000001, "FinnDefault_21341"),
                new SpriteOptions(SpriteEnum.Custom, 10000002, "JakeDefault_21341"),
                new SpriteOptions(SpriteEnum.Custom, 10000003, "PeterDefault_21341")
            });
        }

        private static void OnInitStages()
        {
            ModParameters.StageOptions.Add(GlitchedModParameters.PackageId, new List<StageOptions>
            {
                new StageOptions(1,
                    stageColorOptions: new StageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new StageOptions(2,
                    stageColorOptions: new StageColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f)))
            });
        }

        private static void OnInitPassives()
        {
            ModParameters.PassiveOptions.Add(GlitchedModParameters.PackageId, new List<PassiveOptions>
            {
                new PassiveOptions(2, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new PassiveOptions(3, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f))),
                new PassiveOptions(12, false,
                    passiveColorOptions: new PassiveColorOptions(new Color(0.86f, 0.86f, 86f),
                        new Color(0.86f, 0.86f, 86f)))
            });
        }

        private static void OnInitDropBooks()
        {
            ModParameters.DropBookOptions.Add(GlitchedModParameters.PackageId, new List<DropBookOptions>
            {
                new DropBookOptions(1,
                    new DropBookColorOptions(new Color(0.86f, 0.86f, 86f), new Color(0.86f, 0.86f, 86f))),
                new DropBookOptions(2,
                    new DropBookColorOptions(new Color(0.86f, 0.86f, 86f), new Color(0.86f, 0.86f, 86f))),
                new DropBookOptions(4,
                    new DropBookColorOptions(new Color(0.86f, 0.86f, 86f), new Color(0.86f, 0.86f, 86f)))
            });
        }
    }
}