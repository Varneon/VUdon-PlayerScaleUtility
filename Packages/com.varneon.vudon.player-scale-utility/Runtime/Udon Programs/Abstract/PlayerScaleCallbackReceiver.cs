using UdonSharp;

namespace Varneon.VUdon.PlayerScaleUtility.Abstract
{
    /// <summary>
    /// Callback receiver for player's scale changes
    /// </summary>
    public abstract class PlayerScaleCallbackReceiver : UdonSharpBehaviour
    {
        /// <summary>
        /// Gets called when the player's scale changes
        /// </summary>
        /// <param name="newPlayerScale"> Scale of the player's avatar in relation to the player's real height
        /// <remarks>
        /// <para>(Avatar height / Player's real height)</para>
        /// <para>Example: 1.35 m (Avatar) / 1.8 m (Player) = 0.75 (Relative scale)</para>
        /// <para>Player's real height is 1.8 m and they're using smaller avatar, thus their camera scale is smaller, perceiving the world larger than they normally would</para>
        /// </remarks>
        /// </param>
        public abstract void OnPlayerScaleChanged(float newPlayerScale);
    }
}
