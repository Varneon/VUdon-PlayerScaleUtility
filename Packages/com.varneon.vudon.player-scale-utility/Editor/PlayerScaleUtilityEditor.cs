using UnityEditor;
using UnityEngine;

namespace Varneon.VUdon.PlayerScaleUtility.Editor
{
    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(PlayerScaleUtility))]
    public class PlayerScaleUtilityEditor : Editor
    {
        private void OnEnable()
        {
            PlayerScaleUtility utility = (PlayerScaleUtility)target;

            utility.GetComponent<Camera>().hideFlags = HideFlags.HideInInspector;
            utility.GetComponent<AudioListener>().hideFlags = HideFlags.HideInInspector;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This prefab is used to detect avatar changes on the local player and dispatch events with the scale of the player to callback receivers and player scale constraints.", MessageType.Info);
        }
    }
}
