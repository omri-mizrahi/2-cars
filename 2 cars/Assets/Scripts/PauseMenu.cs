using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Variables
    public GameObject pausePanel;

    bool isPaused = false;
    #endregion

    public void PauseButtonClick() {
        if(isPaused) {
            isPaused = false; 
            Resume();
        } else {
            isPaused = true;
            Pause();
        }
    }

    void Pause() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    void OnDestroy() {
        Time.timeScale = 1;
    }
}
