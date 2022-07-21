using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string Name;
    public int Score;
    public string BestName;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.HighScore = Score;
        data.Name = BestName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score = data.HighScore;
            BestName = data.Name;
        }
    }
}
