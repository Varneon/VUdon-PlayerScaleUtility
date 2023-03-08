using UnityEditor;

namespace Varneon.VUdon.PlayerScaleUtility.Editor
{
    [CustomEditor(typeof(PlayerScaleConstraint))]
    public class PlayerScaleConstraintEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("This object's local scale will be linked to local player's scale.", MessageType.Info);
        }
    }
}
