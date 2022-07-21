using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text inputName;
    public TMP_Text highScoreText;
    void Start()
    {
        if (PersistenceManager.Instance != null)
        {
            highScoreText.text = "Best Score: " + PersistenceManager.Instance.Score + " by: " + PersistenceManager.Instance.BestName;
        }
    }

    public void StartNew()
    {
        PersistenceManager.Instance.Name = inputName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        PersistenceManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        
    }
}
