using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovePingPong))]
public class MovePingPongEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MovePingPong script = (MovePingPong)target;

        // ===== 移動設定 =====
        EditorGUILayout.LabelField("移動設定", EditorStyles.boldLabel);
        script.moveDistance = EditorGUILayout.FloatField("移動距離（往復の片道分）", script.moveDistance);
        script.speed = EditorGUILayout.FloatField("移動スピード", script.speed);
        script.startDelay = EditorGUILayout.FloatField("動き出すまでの遅延時間（秒）", script.startDelay);

        EditorGUILayout.Space();

        // ===== プレイヤー関係設定 =====
        EditorGUILayout.LabelField("プレイヤーとの連動", EditorStyles.boldLabel);
        script.startOnPlayer = EditorGUILayout.Toggle("プレイヤーが上にいる間だけ動く", script.startOnPlayer);

        if (script.startOnPlayer)
        {
            EditorGUI.indentLevel++;
            script.stopWhenPlayerLeaves = EditorGUILayout.Toggle("プレイヤーが降りたら止まる", script.stopWhenPlayerLeaves);
            script.stayActiveAfterLeave = EditorGUILayout.FloatField("離れても動き続ける時間（秒）", script.stayActiveAfterLeave);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        // ===== 移動方向設定 =====
        EditorGUILayout.LabelField("移動方向（該当する方向にチェック）", EditorStyles.boldLabel);

        // X軸
        kansu(script.moveXPlus, script.moveXMinus, "X");

        // Y軸
        kansu(script.moveYPlus, script.moveYMinus, "Y");

        // Z軸
        kansu(script.moveZPlus, script.moveZMinus, "Z");
        

        EditorGUILayout.Space();

        // ===== 保存 =====
        if (GUI.changed)
        {
            EditorUtility.SetDirty(script);
        }
    }

    private void kansu(bool a, bool b, string c)
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(b);
        a = EditorGUILayout.ToggleLeft(c + '+', a, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();

        EditorGUI.BeginDisabledGroup(a);
        b = EditorGUILayout.ToggleLeft(c + '-', b, GUILayout.Width(60));
        EditorGUI.EndDisabledGroup();
        EditorGUILayout.EndHorizontal();
    }
}
