using Barotrauma;
using HarmonyLib;
using ModdingToolkit;

namespace BetterBots.Shared.AI.Objectives;

[HarmonyPatch(typeof(AIObjectiveManager), nameof(AIObjectiveManager.CreateObjective))]

public class AIObjectiveManager_CreateObjective {

	static void Postfix(AIObjectiveManager __instance, ref AIObjective? __result, Order order, float priorityModifier = 1f) {
		Utils.Logging.PrintMessage($"Identifier '{order.Identifier.Value.ToLowerInvariant()}'");
		// Look for orders from this mod.
		AIObjective? aiObjective = null;
		switch (order.Identifier.Value.ToLowerInvariant()) {
			case "speak": {
				aiObjective = new AIObjectiveSpeak(__instance.character, __instance, priorityModifier);
				break;
			}
		}
		if (aiObjective != null) {
			aiObjective.Identifier = order.Identifier;
			aiObjective.IgnoreAtOutpost = false;
			__result = aiObjective;
		}
	}

}
