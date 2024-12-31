using Barotrauma;
using Barotrauma.Items.Components;

#if CLIENT
using Microsoft.Xna.Framework;
#endif

namespace BetterBots.Shared.Characters.AI.Objectives;

/// <summary>
/// Implementation of <see cref="AIObjective"/> for fabricating a specific recipie a set number of times.
/// </summary>
public sealed class AIObjectiveFabricate : AIObjective {

	/// <inheritdoc/>
	public override Identifier Identifier { get; set; } = "fabricate".ToIdentifier();

	/// <summary>
	/// The target station to fabricate the recipe at.
	/// </summary>
	public Fabricator? Fabricator { get; set; }

	/// <summary>
	/// The recipe to fabricate.
	/// </summary>
	public FabricationRecipe FabricationRecipe { get; init; }

	/// <summary>
	/// The number of times to fabricate the recipe.
	/// </summary>
	/// <seealso cref="FabricatedCount"/>
	public int FabricationCount { get; init; } = 1;

	/// <summary>
	/// The current number of times the recipie has been crafted by this objective.
	/// </summary>
	/// <seealso cref="FabricationCount"/>
	public int FabricatedCount { get; private set; } = 0;

	/// <summary>
	/// Creates a new <see cref="AIObjectiveFabricate"/>.
	/// </summary>
	/// <inheritdoc/>
	public AIObjectiveFabricate(
		Character character,
		FabricationRecipe recipe,
		AIObjectiveManager manager,
		float priorityModifier
	) : base(
		character,
		manager,
		priorityModifier
	) {
		FabricationRecipe = recipe;
	}

	/// <inheritdoc/>
	public override void Act(float deltaTime) {
		if (FabricatedCount >= FabricationCount) {
			IsCompleted = true;
			return;
		}
		var recipe = FabricationRecipe;
		var fabricator = Fabricator;
		if (fabricator == null) {
			Abandon = true;
			return;
		}
		if (!fabricator.CanBeFabricated(recipe, fabricator.availableIngredients, this.character)) {
			Abandon = true;
			return;
		}
		fabricator.StartFabricating(recipe, this.character);
	}

	/// <inheritdoc/>
	public override bool CheckObjectiveSpecific() {
		var recipe = FabricationRecipe;
		if (!CharacterUtil.IsSafeRecipe(this.character, recipe)) {
			Abandon = true;
			return false;
		}
		return IsCompleted;
	}

}
