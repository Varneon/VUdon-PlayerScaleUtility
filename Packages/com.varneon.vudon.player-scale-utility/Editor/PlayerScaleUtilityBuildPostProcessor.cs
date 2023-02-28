using JetBrains.Annotations;
using System.Linq;
using UnityEditor;
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
        private const string PREFAB_PATH = "Packages/com.varneon.vudon.player-scale-utility/Runtime/Prefabs/PlayerScaleUtility.prefab";

        /// <summary>
        /// Processes the PlayerScaleUtility on build
        /// </summary>
        [UsedImplicitly]
        [PostProcessScene(-1)]
        private static void PostProcessPlayerScaleUtility()
        {
            // Get the PlayerScaleUtility from the scene
            PlayerScaleUtility playerScaleUtility = Object.FindObjectOfType<PlayerScaleUtility>();

            // Find all PlayerScaleConstraints
            PlayerScaleConstraint[] playerScaleConstraints = Resources.FindObjectsOfTypeAll<PlayerScaleConstraint>();

            // Find all PlayerScaleCallbackReceivers
            PlayerScaleCallbackReceiver[] playerScaleCallbackReceivers = Resources.FindObjectsOfTypeAll<PlayerScaleCallbackReceiver>().Where(r => r.gameObject.scene.IsValid()).ToArray();

            // If there are no constraints or callback receivers, return
            if(playerScaleConstraints.Length == 0 && playerScaleCallbackReceivers.Length == 0)
            {
                return;
            }
            else if(playerScaleUtility == null) // If there are constraints and/or callback receivers, but the utility cannot be found, create one
            {
                playerScaleUtility = Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(PREFAB_PATH)).GetComponent<PlayerScaleUtility>();
            }

            // Get the Transforms from all constraints
            Transform[] playerScaleConstrainedTransforms = playerScaleConstraints.Where(c => c.gameObject.scene.IsValid()).Select(c => c.transform).ToArray();

            // Assign constrained transforms to the utility
            playerScaleUtility.constrainedTransforms = playerScaleConstrainedTransforms;

            // Assign callback receivers to the utility
            playerScaleUtility.callbackReceivers = playerScaleCallbackReceivers;

            // Destroy all constraint components
            foreach(PlayerScaleConstraint c in playerScaleConstraints)
            {
                Object.DestroyImmediate(c);
            }
        }
    }
}
