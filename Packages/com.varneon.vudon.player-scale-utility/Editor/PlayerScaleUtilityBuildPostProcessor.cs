using JetBrains.Annotations;
using System.Linq;
using UnityEditor.Callbacks;
using UnityEngine;
using Varneon.VUdon.PlayerScaleUtility.Abstract;

namespace Varneon.VUdon.PlayerScaleUtility.Editor
{
    /// <summary>
    /// Build postprocessor for PlayerScaleUtility
    /// </summary>
    public static class PlayerScaleUtilityBuildPostProcessor
    {
        /// <summary>
        /// Processes the PlayerScaleUtility on build
        /// </summary>
        [UsedImplicitly]
        [PostProcessScene(-1)]
        private static void PostProcessPlayerScaleUtility()
        {
            // Get the PlayerScaleUtility from the scene
            PlayerScaleUtility playerScaleUtility = Object.FindObjectOfType<PlayerScaleUtility>();

            // Find all objects with PlayerScaleConstraint
            Transform[] playerScaleConstrainedTransforms = Resources.FindObjectsOfTypeAll<PlayerScaleConstraint>().Where(c => c.gameObject.scene.IsValid()).Select(c => c.transform).ToArray();

            // Assign constrained transforms to the utility
            playerScaleUtility.constrainedTransforms = playerScaleConstrainedTransforms;

            // Find all PlayerScaleCallbackReceivers
            PlayerScaleCallbackReceiver[] playerScaleCallbackReceivers = Resources.FindObjectsOfTypeAll<PlayerScaleCallbackReceiver>().Where(r => r.gameObject.scene.IsValid()).ToArray();

            // Assign callback receivers to the utility
            playerScaleUtility.callbackReceivers = playerScaleCallbackReceivers;
        }
    }
}
