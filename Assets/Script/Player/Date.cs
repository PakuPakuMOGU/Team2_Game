using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public float time;
}

public class Date: MonoBehaviour
{
    public ClearTime timeSc;

    public void Save()
    {
        PlayerData data = new PlayerData();
        data.playerPosition = this.transform.position;
        data.time = timeSc.ReturnNowTime();

        string json = JsonUtility.ToJson(data, true); // 見やすい形式で
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Save!");
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            this.transform.position= data.playerPosition;
            timeSc.GiveNowTime(data.time);

            Debug.Log("Load!");
        }
        else
        {
            Debug.Log("セーブデータが見つかりませんでした");
        }
    }

    public void Reset()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("セーブデータを削除しました");
        }
        else
        {
            Debug.Log("削除対象のセーブデータが存在しません");
        }

        // プレイヤーの位置を初期化（例：原点に戻す）
        this.transform.position = Vector3.zero;

        // 時間を初期化
        if (timeSc != null)
        {
            timeSc.GiveNowTime(0f);
        }
    }
}