using System.Collections;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 playerPosition;
    public Vector3 replayPosition;
    public float time;
    public bool[] checker;
}

public class Date: MonoBehaviour
{
    public ClearTime timeSc;
    public CheckPoint checkSc;


    private void Start()
    {
        StartCoroutine(LoadWithDelay());
    }

    private IEnumerator LoadWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Load();
    }


    // データをセーブ.
    public void Save()
    {
        PlayerData data = new PlayerData();
        data.checker = new bool[checkSc.checkPoints.Count];
        data.checker = new bool[checkSc.ListON.Length];
        for (int i = 0; i < checkSc.ListON.Length; i++)
        {
            data.checker[i] = checkSc.ListON[i];
        }
        data.playerPosition = this.transform.position;
        data.replayPosition = checkSc.playerPosition;
        data.time = timeSc.ReturnNowTime();

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
        Debug.Log("Save!");
    }

    // セーブデータをロード.
    public void Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            this.transform.position= data.playerPosition;
            timeSc.GiveNowTime(data.time);
            for (int i = 0; i < checkSc.ListON.Length; i++)
            {
                if (data.checker[i] == true) 
                {
                    checkSc.ListON[i] = true;
                    checkSc.StartTagCheck(i);
                }
            }
            checkSc.playerPosition = data.replayPosition;

            Debug.Log("Load!");
        }
        else
        {
            Debug.Log("セーブデータが見つかりませんでした");
        }
    }

    // セーブデータをリセット.
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

        // 時間を初期化
        if (timeSc != null)
        {
            timeSc.GiveNowTime(0f);
        }
    }
}