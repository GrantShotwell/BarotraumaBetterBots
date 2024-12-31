using ModdingToolkit;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

// 'Barotrauma' makes client-side work.
[assembly: IgnoresAccessChecksTo("Barotrauma")]
// 'DedicatedServer' makes server-side work.
[assembly: IgnoresAccessChecksTo("DedicatedServer")]

namespace BetterBots;

public partial class Plugin : IAssemblyPlugin {

	/// <inheritdoc/>
	public const string AuthorName = "GrantShotwell";

	/// <inheritdoc/>
	public const string ModName = "BetterBots";

	/// <inheritdoc/>
	public const string ModIdentifier = "GrantShotwell.BetterBots";

	/// <inheritdoc/>
	public const string ModVersion = "0.0.0";

	/// <inheritdoc/>
	public static ImmutableArray<string> Dependencies { get; } = ImmutableArray<string>.Empty;

	/// <inheritdoc/>
	public static PluginInfo PluginInfo { get; } = new(ModIdentifier, ModVersion, Dependencies);

	/// <inheritdoc/>
	public PluginInfo GetPluginInfo() => PluginInfo;

	private static void PatchShared() {
		HarmonyLib.Harmony harmony = new(ModIdentifier);
		harmony.PatchAll();
	}

}
