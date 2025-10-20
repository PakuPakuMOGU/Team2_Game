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
        Debug.Log("位置：" + data.playerPosition);
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

            Debug.Log("位置：" + data.playerPosition);
        }
        else
        {
            Debug.Log("セーブデータが見つかりませんでした");
        }
    }
}