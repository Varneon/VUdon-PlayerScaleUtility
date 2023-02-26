using UdonSharp;

namespace Varneon.VUdon.PlayerScaleUtility.Abstract
{
    /// <summary>
    /// Callback receiver for player's scale changes
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public abstract class PlayerScaleCallbackReceiver : UdonSharpBehaviour
    {
        /// <summary>
        /// Gets called when the player's scale changes
        /// </summary>
        /// <param name="newPlayerScale">Player's new scale</param>
        public abstract void OnPlayerScaleChanged(float newPlayerScale);
    }
}
