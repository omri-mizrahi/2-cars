using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region Variables
    #endregion

    public void Retry() {
        GameScore.CurrentGameScore = 0;
        SceneManager.LoadScene(GameMode.CurrentGameMode);
    }

    public void BackToStart() {
        SceneManager.LoadScene(Consts.Scenes.StartMenu);
    }
}
