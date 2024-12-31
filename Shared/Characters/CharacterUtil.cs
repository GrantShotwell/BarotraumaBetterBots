using Barotrauma;

namespace BetterBots.Shared.Characters.AI;

/// <summary>
/// 
/// </summary>
public static class CharacterUtil {

	/// <summary>
	/// Checks if a recipe is safe for a specific character to fabricate.
	/// </summary>
	/// <param name="character">The character to check against.</param>
	/// <param name="recipe">The recipe to check.</param>
	/// <returns>Returns <see langword="true"/> only if the character has the required/recommended skills and money.</returns>
	public static bool IsSafeRecipe(Character character, FabricationRecipe recipe) {
		return HasMoney(character, recipe.RequiredMoney) && HasSkills(character, recipe.RequiredSkills);
	}

	/// <summary>
	/// Checks if a character has the required skills.
	/// </summary>
	/// <param name="character">The character to check.</param>
	/// <param name="skills">The skills to check.</param>
	/// <returns>
	/// Whether each skill level in <paramref name="skills"/>
	/// is at least the matching skill level (by identifier) in <paramref name="character"/>.
	/// </returns>
	public static bool HasSkills(Character character, IReadOnlyCollection<Skill> skills) {
		foreach (var skill in skills) {
			if (character.GetSkillLevel(skill.Identifier) < skill.Level) {
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Checks if a character has access to at least a certain amount of money.
	/// </summary>
	/// <param name="character">The character to check.</param>
	/// <param name="money">The amount of money that is required.</param>
	/// <returns>Whether money is enabled, otherwise whether the character has access to at least <paramref name="money"/>.</returns>
	public static bool HasMoney(Character character, int money) {
		CampaignMode? campaign = GameMain.GameSession?.Campaign;
		if (campaign == null || money <= 0) return true;
#if SERVER
		if (campaign is MultiPlayerCampaign multiplayer) {
			var client = GameMain.Server.ConnectedClients.FirstOrDefault(item => item.Character == character);
			// Looked at source, and MultiPlayerCampaign.CanAfford throws an error when client is null.
			Wallet wallet = client == null ? multiplayer.Bank : multiplayer.GetWallet(client);
			return wallet.CanAfford(money);
		}
#endif
		return campaign.CanAfford(money);
	}

}
