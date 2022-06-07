using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    #region Variables
    #endregion

    public void Classic() {
        GameMode.CurrentGameMode = Consts.GameModes.TwoCars;
        SceneManager.LoadScene(Consts.Scenes.TwoCars);        
    }

    public void Hardcore() {
        GameMode.CurrentGameMode = Consts.GameModes.ThreeCars;
        SceneManager.LoadScene(Consts.Scenes.ThreeCars);
    }
}
