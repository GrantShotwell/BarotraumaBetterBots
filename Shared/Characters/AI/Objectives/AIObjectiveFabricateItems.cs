using Barotrauma;
using Barotrauma.Items.Components;

#if CLIENT
using Microsoft.Xna.Framework;
#endif

namespace BetterBots.Shared.Characters.AI.Objectives;

/// <summary>
/// Abstract implementation of <see cref="AIObjective"/> for fabricating a list of recipies.
/// </summary>
public abstract class AIObjectiveFabricateItems : AIObjective {

	/// <summary>
	/// The recipies to fabricate.
	/// </summary>
	public List<FabricationRecipe> Recipies { get; }

	/// <summary>
	/// The only fabrication station to use, if set. Otherwise, any can be used.
	/// </summary>
	public Fabricator? Fabricator { get; set; }

	/// <summary>
	/// Creates a new <see cref="AIObjectiveFabricate"/>.
	/// </summary>
	/// <inheritdoc/>
	public AIObjectiveFabricateItems(
		Character character,
		ICollection<FabricationRecipe> recipes,
		AIObjectiveManager manager,
		float priorityModifier
	) : base(
		character,
		manager,
		priorityModifier
	) {
		Recipies = new(recipes);
	}

	/// <inheritdoc/>
	public override void Act(float deltaTime) {
		// TODO
	}

	/// <inheritdoc/>
	public override bool CheckObjectiveSpecific() {
		return IsCompleted;
	}

	private void StartFabricateObjective(FabricationRecipe recipe) {
		AIObjectiveFabricate objective = new(this.character, recipe, this.objectiveManager, );
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="recipe"></param>
	/// <param name="remove"></param>
	protected abstract void HandleRecipeFabricated(FabricationRecipe recipe, out bool remove);

}
