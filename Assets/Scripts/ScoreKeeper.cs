using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreKeeper : MonoBehaviour
{

    public static ScoreKeeper Instance;
    public int maxScore;
    public string maxScorePlayerName;

    public string newPlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void newMax(int score)
    {
        maxScore = score;
        maxScorePlayerName = newPlayerName;
        Save();
    }

    [System.Serializable]
    class SaveData
    {
        public int score;
        public string name;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.score = maxScore;
        data.name = maxScorePlayerName;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScore = data.score;
            maxScorePlayerName = data.name;
        }
    }
}
