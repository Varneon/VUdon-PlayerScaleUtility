using UdonSharp;
using UnityEngine;
using Varneon.VUdon.PlayerScaleUtility.Abstract;

namespace Varneon.VUdon.PlayerScaleUtility
{
    /// <summary>
    /// Utility class for detecting the player's scale
    /// </summary>
    [AddComponentMenu("")] // Do not show this component in Add Component menu, the provided prefab should always be used
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

        /// <summary>
        /// Interval in seconds for detecting the player's scale
        /// </summary>
        [Tooltip("Interval in seconds for detecting the player's scale")]
        [SerializeField, Range(0f, 5f)]
        private float interval = 1f;

        private Vector3 CameraScale
        {
            get => cameraScale;
            set
            {
                if (cameraScale != value)
                {
                    cameraScale = value;

                    OnAvatarChanged();
                }
            }
        }

        private Vector3 cameraScale = Vector3.one;

        public float PlayerScale => relativeCameraScale;

        private float relativeCameraScale;

        private void Start()
        {
#if UNITY_EDITOR // Avatar change doesn't get triggered in editor, run it once to ensure that systems dependent on it will function properly
            SendCustomEventDelayedFrames(nameof(TriggerAvatarChangeInEditor), 0);
#else
            CheckScale();
#endif
        }

#if UNITY_EDITOR
        public void TriggerAvatarChangeInEditor()
        {
            OnAvatarChanged();
        }
#endif

        public void CheckScale()
        {
            CameraScale = transform.localScale;

            SendCustomEventDelayedSeconds(nameof(CheckScale), interval);
        }

        private void OnAvatarChanged()
        {
            relativeCameraScale = 1f / CameraScale.x;

            Vector3 playerScale = new Vector3(relativeCameraScale, relativeCameraScale, relativeCameraScale);

            foreach (Transform t in constrainedTransforms)
            {
                if(t == null) { continue; }

                t.localScale = playerScale;
            }

            foreach(PlayerScaleCallbackReceiver callbackReceiver in callbackReceivers)
            {
                if(callbackReceiver == null) { continue; }

                callbackReceiver.OnPlayerScaleChanged(relativeCameraScale);
            }
        }
    }
}
