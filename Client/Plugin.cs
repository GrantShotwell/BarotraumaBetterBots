using ModdingToolkit;
using System.Runtime.CompilerServices;

[assembly: IgnoresAccessChecksTo("Barotrauma")]
[assembly: IgnoresAccessChecksTo("DedicatedServer")]

namespace BetterBots;

public partial class Plugin : IAssemblyPlugin {

	public void Initialize() {
		PatchShared();
		Utils.Logging.PrintMessage($"Initialized {PluginInfo.ModName}");
	}

	public void OnLoadCompleted() {
		Utils.Logging.PrintMessage($"Loaded {PluginInfo.ModName}");
	}

	public void Dispose() {
		Utils.Logging.PrintMessage($"Disposed {PluginInfo.ModName}");
	}

}
