using System;
using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;
using ResoniteHotReloadLib;

namespace ExampleMod;
public class ExampleMod : ResoniteMod {

    public override string Name => "ExampleMod";
    public override string Author => "John Example";
    public override string Version => "0.1.0";
    public override string Link => "https://github.com/WattleFoxxo/ResoniteModExample/";
    const string HarmonyId = "com.example.ExampleMod";

    [AutoRegisterConfigKey]
    private static readonly ModConfigurationKey<bool> enabled = new ModConfigurationKey<bool>("enabled", "Should the mod be enabled", () => true);
    private static ModConfiguration Config;

    public override void OnEngineInit() {
        HotReloader.RegisterForHotReload(this);
        Config = GetConfiguration();

        Setup();
    }

    static void BeforeHotReload() {
        Harmony harmony = new Harmony(HarmonyId);
        harmony.UnpatchAll(HarmonyId);
    }

    static void OnHotReload(ResoniteMod modInstance) {
        Config = modInstance.GetConfiguration();
        Setup();
    }

    static void Setup() {
        Harmony harmony = new Harmony(HarmonyId);
        harmony.PatchAll();

        Msg("Works on my machine :)");
    }
}

