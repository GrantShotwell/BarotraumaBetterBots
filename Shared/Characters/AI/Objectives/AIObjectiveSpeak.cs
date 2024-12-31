using Barotrauma;
using ModdingToolkit;

#if CLIENT
using Microsoft.Xna.Framework;
#endif

namespace BetterBots.Shared.Characters.AI.Objectives;

public sealed class AIObjectiveSpeak : AIObjective {

	// Setting this property I think is redundant.
	// The AIObjectiveManager sets the identifier in CreateObjective(...)
	public override Identifier Identifier { get; set; } = "speak".ToIdentifier();

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
		IsCompleted = true;
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
