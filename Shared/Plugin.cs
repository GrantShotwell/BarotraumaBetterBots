using ModdingToolkit;
using System.Collections.Immutable;

namespace BetterBots;

public partial class Plugin : IAssemblyPlugin {

	public static ImmutableArray<string> Dependencies { get; } = ImmutableArray<string>.Empty;

	public static PluginInfo PluginInfo { get; } = new("GrantShotwell.BetterBots", "0.0.0", Dependencies);

	public PluginInfo GetPluginInfo() => PluginInfo;

}
