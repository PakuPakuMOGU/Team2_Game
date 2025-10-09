using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovePingPong))]
public class MovePingPongEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MovePingPong script = (MovePingPong)target;

        script.moveDistance = EditorGUILayout.FloatField("移動距離（往復の片道分）", script.moveDistance);
        script.speed = EditorGUILayout.FloatField("移動スピード", script.speed);
        script.startDelay = EditorGUILayout.FloatField("動き出すまでの遅延時間（秒）", script.startDelay);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("移動方向（該当する方向にチェック）", EditorStyles.boldLabel);

        // X軸
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(script.moveXMinus);
        script.moveXPlus = EditorGUILayout.ToggleLeft("X+", script.moveXPlus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(script.moveXPlus);
        script.moveXMinus = EditorGUILayout.ToggleLeft("X-", script.moveXMinus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndHorizontal();

        // Y軸
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(script.moveYMinus);
        script.moveYPlus = EditorGUILayout.ToggleLeft("Y+", script.moveYPlus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(script.moveYPlus);
        script.moveYMinus = EditorGUILayout.ToggleLeft("Y-", script.moveYMinus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndHorizontal();

        // Z軸
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(script.moveZMinus);
        script.moveZPlus = EditorGUILayout.ToggleLeft("Z+", script.moveZPlus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(script.moveZPlus);
        script.moveZMinus = EditorGUILayout.ToggleLeft("Z-", script.moveZMinus, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(script);
        }
    }
}
