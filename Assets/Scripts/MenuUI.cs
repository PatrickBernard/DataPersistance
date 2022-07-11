using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] InputField playerName;


    private void Start()
    {
        if (ScoreKeeper.Instance.maxScorePlayerName != "")
        {
            string name = ScoreKeeper.Instance.maxScorePlayerName;
            int score = ScoreKeeper.Instance.maxScore;
            scoreText.text = $"Best Score by {name} : {score}";
        }
        else
        {
            scoreText.text = "";
        }
    }

    public void StartNew()
    {
        ScoreKeeper.Instance.newPlayerName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
