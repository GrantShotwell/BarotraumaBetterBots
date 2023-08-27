using Barotrauma;
using ModdingToolkit;

#if CLIENT
using Microsoft.Xna.Framework;
#endif

namespace BetterBots.Shared.AI.Objectives;

class AIObjectiveSpeak : AIObjective {

	// Settings this property I think is redundant.
	public override Identifier Identifier { get; set; } = "speak".ToIdentifier();

	// These properties are required so the objective isn't skipped immediately.
	public override bool AllowInAnySub => false;

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
		this.character.Speak("I'm speaking!", Barotrauma.Networking.ChatMessageType.Radio);
#endif
	}

	public override float GetPriority() {
		Priority = 10f;
		return Priority;
	}

	public override bool CheckObjectiveSpecific() {
		IsCompleted = false;
		return IsCompleted;
	}

	public override void OnAbandon() {
		Utils.Logging.PrintMessage("Abandoned!");
		base.OnAbandon();
	}

	public override void OnCompleted() {
		Utils.Logging.PrintMessage("Completed!");
		base.OnCompleted();
	}

	public override void OnDeselected() {
		Utils.Logging.PrintMessage("Deselected!");
		base.OnDeselected();
	}

	public override void OnSelected() {
		Utils.Logging.PrintMessage("Selected!");
		base.OnSelected();
	}

}
