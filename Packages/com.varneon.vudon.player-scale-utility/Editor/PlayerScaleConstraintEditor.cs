using UnityEditor;

namespace Varneon.VUdon.PlayerScaleUtility.Editor
{
    [CustomEditor(typeof(PlayerScaleConstraint))]
    public class PlayerScaleConstraintEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("When the local player's height changes, this object's local scale will match the relative scale of the player, allowing them to perceive this object as being the same size regardless of their own height.", MessageType.Info);
        }
    }
}
