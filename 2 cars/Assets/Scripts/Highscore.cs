using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI scoreText;
    int highscore;
    string highscoreKeyword;
    #endregion

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        highscoreKeyword = GameMode.CurrentGameMode + Consts.PlayerPrefs.Highscore;

        highscore = PlayerPrefs.GetInt(highscoreKeyword, 0);
        if (GameScore.CurrentGameScore > highscore) {
            highscore = GameScore.CurrentGameScore;
            PlayerPrefs.SetInt(highscoreKeyword, highscore);
        }
        scoreText.text = highscore.ToString();
    }
}
