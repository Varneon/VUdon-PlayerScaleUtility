﻿using UdonSharp;
using UnityEngine;
using Varneon.VUdon.PlayerScaleUtility.Abstract;
using VRC.SDKBase;

namespace Varneon.VUdon.PlayerScaleUtility
{
    /// <summary>
    /// Utility class for dispatching player's relative scale on avatar height change
    /// </summary>
    [AddComponentMenu("")] // Do not show this component in Add Component menu, the provided prefab should always be used
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Camera))]
    [RequireComponent(typeof(AudioListener))]
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class PlayerScaleUtility : UdonSharpBehaviour
    {
        /// <summary>
        /// Array of transforms that should be always scaled according to player's scale
        /// </summary>
        [SerializeField, HideInInspector]
        internal Transform[] constrainedTransforms;

        /// <summary>
        /// Array of callback receivers for player scale changes
        /// </summary>
        [SerializeField, HideInInspector]
        internal PlayerScaleCallbackReceiver[] callbackReceivers;

        public float PlayerScale => relativeCameraScale;

        private float relativeCameraScale;

        public override void OnAvatarEyeHeightChanged(VRCPlayerApi player, float prevEyeHeightAsMeters)
        {
            if(player.isLocal)
            {
                relativeCameraScale = 1f / transform.localScale.x;

                Vector3 playerScale = new Vector3(relativeCameraScale, relativeCameraScale, relativeCameraScale);

                foreach (Transform t in constrainedTransforms)
                {
                    if (t == null) { continue; }

                    t.localScale = playerScale;
                }

                foreach (PlayerScaleCallbackReceiver callbackReceiver in callbackReceivers)
                {
                    if (callbackReceiver == null) { continue; }

                    callbackReceiver.OnPlayerScaleChanged(relativeCameraScale);
                }
            }
        }
    }
}
