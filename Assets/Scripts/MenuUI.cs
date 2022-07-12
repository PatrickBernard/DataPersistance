using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    [SerializeField] Text highScoreText;
    [SerializeField] InputField playerName;


    private void Start()
    {
        if (!string.IsNullOrEmpty(ScoreKeeper.Instance.maxScorePlayerName))
        {
            string name = ScoreKeeper.Instance.maxScorePlayerName;
            int score = ScoreKeeper.Instance.maxScore;
            highScoreText.gameObject.SetActive(true);
            highScoreText.text = $"Best Score by {name} : {score}";
        }
    }

    public void StartNew()
    {
        if (!string.IsNullOrEmpty(playerName.text))
        {
            ScoreKeeper.Instance.newPlayerName = playerName.text;
        }
        else 
        {
            ScoreKeeper.Instance.newPlayerName = "Anonymous";
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
