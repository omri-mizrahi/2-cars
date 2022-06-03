using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    #region Variables
    TextMeshProUGUI scoreText;
    int highscore;
    #endregion

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        highscore = PlayerPrefs.GetInt(Consts.HighscorePlayerPref, 0);
        if (GameScore.CurrentGameScore > highscore) {
            highscore = GameScore.CurrentGameScore;
            PlayerPrefs.SetInt(Consts.HighscorePlayerPref, highscore);
        }
        scoreText.text = highscore.ToString();
    }
}
