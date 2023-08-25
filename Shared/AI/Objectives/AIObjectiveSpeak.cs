using Barotrauma;
using Microsoft.Xna.Framework;
using ModdingToolkit;

namespace BetterBots.Server.AI.Objectives;

class AIObjectiveSpeak : AIObjective {

	public override Identifier Identifier { get; set; } = "speak".ToIdentifier();

	public AIObjectiveSpeak(
		Character character,
		AIObjectiveManager manager,
		float priorityModifier
	) : base(
		character,
		manager,
		priorityModifier
	) {
		//
	}

	public override void Act(float deltaTime) {
		Utils.Logging.PrintMessage("Spoken!");
#if CLIENT
		this.character.AddMessage("I'm speaking!", Color.Pink, true);
#endif
		IsCompleted = true;
	}

	public override bool CheckObjectiveSpecific() {
		return IsCompleted;
	}

}
