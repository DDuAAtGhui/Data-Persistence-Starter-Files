using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    string playerName;
    public int score;


    public string GetPlayerName() { return playerName; }
    public void SetPlayerName(string name) { playerName = name; }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();

        //���ӸŴ����� playername�� Ÿ��Ʋ���� ��ŸƮ ��ư �����¼��� ��ϵ�
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        string path = Application.dataPath + $"/SaveData/{playerName}.json";

        File.WriteAllText(path, json);
    }

    public void LoadPlayerData()
    {
        string path = Application.dataPath + $"/SaveData/{playerName}.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            score = data.score;
        }
    }
}
