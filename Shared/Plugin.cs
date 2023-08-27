using ModdingToolkit;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

// 'Barotrauma' makes client-side work.
[assembly: IgnoresAccessChecksTo("Barotrauma")]
// 'DedicatedServer' makes server-side work.
[assembly: IgnoresAccessChecksTo("DedicatedServer")]

namespace BetterBots;

public partial class Plugin : IAssemblyPlugin {

	public const string AuthorName = "GrantShotwell";

	public const string ModName = "BetterBots";

	public const string ModIdentifier = "GrantShotwell.BetterBots";

	public const string ModVersion = "0.0.0";

	public static ImmutableArray<string> Dependencies { get; } = ImmutableArray<string>.Empty;

	public static PluginInfo PluginInfo { get; } = new(ModIdentifier, ModVersion, Dependencies);

	public PluginInfo GetPluginInfo() => PluginInfo;

	private static void PatchShared() {
		HarmonyLib.Harmony harmony = new(ModIdentifier);
		harmony.PatchAll();
	}

}
