using System;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.IAmSpeed;

public class IAmSpeedModule : EverestModule {
    public static IAmSpeedModule Instance { get; private set; }

    public override Type SettingsType => typeof(IAmSpeedModuleSettings);
    public static IAmSpeedModuleSettings Settings => (IAmSpeedModuleSettings) Instance._Settings;

    public override Type SessionType => typeof(IAmSpeedModuleSession);
    public static IAmSpeedModuleSession Session => (IAmSpeedModuleSession) Instance._Session;

    public override Type SaveDataType => typeof(IAmSpeedModuleSaveData);
    public static IAmSpeedModuleSaveData SaveData => (IAmSpeedModuleSaveData) Instance._SaveData;

    public IAmSpeedModule() {
        Instance = this;
#if DEBUG
        // debug builds use verbose logging
        Logger.SetLogLevel(nameof(IAmSpeedModule), LogLevel.Verbose);
#else
        // release builds use info logging to reduce spam in log files
        Logger.SetLogLevel(nameof(IAmSpeedModule), LogLevel.Info);
#endif
    }

    public static void pc_load_letter(Level level) {
        level.Add(new Autosplit.Autosplit());
    }
    public override void Load() {
        // TODO: apply any hooks that should always be active
        Everest.Events.LevelLoader.OnLoadingThread += pc_load_letter;
    }

    public override void Unload() {
        // TODO: unapply any hooks applied in Load()
    }

}